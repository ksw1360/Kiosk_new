using Kiosk.Popup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kiosk.Class
{
    internal class Receipt
    {
        //internal static StringBuilder sb = new StringBuilder();
        internal static void ReceiptContract(string name, string pat_jno2, string surgery, string mobile, string address, string kind, string SMS, string personalInfo, string rcvEventMsg)
        {
            //구환 접수
            //1. 환자 정보 조회
            //2. 접수
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($" SELECT PAT_NO , PAT_NM , PAT_BTH, MOBILE_NO");
                //sb.AppendLine($" , CONCAT(SUBSTRING(MOBILE_NO,1,3),'-',REPLACE(SUBSTRING(MOBILE_NO,5,4),SUBSTRING(MOBILE_NO,5,4),'****'),'-',SUBSTRING(MOBILE_NO,10,4)) as MOBILE_NO ");
                sb.AppendLine($" FROM PTNT_INFO ");
                sb.AppendLine($" WHERE PAT_NM LIKE '%{name}%'");
                if (string.IsNullOrEmpty(pat_jno2) == false)
                {
                    sb.AppendLine($" AND SUBSTR(PAT_JNO2,1,6) = '{pat_jno2}'");
                }
                else if (string.IsNullOrEmpty(mobile) == false)
                {
                    sb.AppendLine($" AND MOBILE_NO  like '%{mobile}%'");
                }

                DataTable Ptnt_Dt = DBCommon.SelectData(sb.ToString());

                //if (textBox1.Text.Length >= 4 && textBox1.Text.Length <= 13)
                if (Ptnt_Dt.Rows.Count > 0) //구환
                {
                    if (Ptnt_Dt.Rows.Count > 1)
                    {
                        using (var ptnt_List_Popup = new Ptnt_List_Popup())
                        {
                            ptnt_List_Popup.dt = Ptnt_Dt;
                            var dr = ptnt_List_Popup.ShowDialog();
                            if (dr == DialogResult.OK)
                            {
                                var Ptnt_List = ptnt_List_Popup.List;
                                //접수
                                bool chk = SetReceipt(Ptnt_List[0], Ptnt_List[1], Ptnt_List[2], Ptnt_List[3]);//이름,생일,모바일,Pat_No
                                if (chk)
                                {
                                    //접수 완료 메세지창
                                    if (Ptnt_List != null) // <- 수정예정
                                    {
                                        //접수완료시 문자 전송
                                        //SendSMS(chk, Ptnt_List[3], Common.YKIHO);
                                        PopupMessage popupMessage = new PopupMessage();
                                        popupMessage.Names = name;
                                        popupMessage.message = "접수되었습니다.";
                                        popupMessage.result = "대기해 주시면 순차적으로 안내 도와드리겠습니다.";
                                        popupMessage.StartPosition = FormStartPosition.CenterScreen;
                                        popupMessage.ShowDialog();
                                    }
                                }
                                else
                                {
                                    PopupMessage popupMessage = new PopupMessage();
                                    popupMessage.Names = Ptnt_List[0];
                                    popupMessage.message = "접수중 오류가 발생하였습니다.";
                                    popupMessage.StartPosition = FormStartPosition.CenterScreen;
                                    popupMessage.ShowDialog();

                                }
                            }
                        }
                    }
                    else if (Ptnt_Dt.Rows.Count < 2)
                    {
                        string modifiedText = string.Empty;
                        PopupMessageQuestion popup = new PopupMessageQuestion();
                        popup.panel4.Visible = true;
                        popup.Names = "입력하신 정보가 존재합니다.";
                        string _names = Ptnt_Dt.Rows[0]["PAT_NM"].ToString();
                        string _mobile = Ptnt_Dt.Rows[0]["MOBILE_NO"].ToString();
                        modifiedText = _names;
                        //if (_names.Length >= 3)
                        //{
                        //    modifiedText = _names.Substring(0, 1) + "*" + _names.Substring(2, 1);
                        //}
                        //else if (_names.Length <= 3)
                        //{
                        //    modifiedText = _names.Substring(0, 1) + "*";
                        //}
                        ////CONCAT(SUBSTRING(MOBILE_NO,1,3),'-',REPLACE(SUBSTRING(MOBILE_NO,5,4),SUBSTRING(MOBILE_NO,5,4),'****'),'-',SUBSTRING(MOBILE_NO,10,4))
                        //_mobile = _mobile.Substring(1, 3) 
                        //        + "-" 
                        //        + _mobile.Substring(1, 3).Replace(_mobile.Substring(5, 4), "****") 
                        //        + "-" 
                        //        + _mobile.Substring(10, 4);
                        popup.messages = modifiedText + " " + _mobile;
                            //Ptnt_Dt.Rows[0]["MOBILE_NO"].ToString();
                        popup.result = "으로 접수하시겠습니까?";
                        DialogResult dr = popup.ShowDialog();
                        if (dr == DialogResult.OK)
                        {
                            bool chk = SetReceipt(Ptnt_Dt.Rows[0]["PAT_NM"].ToString()
                                     , Ptnt_Dt.Rows[0]["PAT_BTH"].ToString()
                                     , Ptnt_Dt.Rows[0]["MOBILE_NO"].ToString()
                                     , Ptnt_Dt.Rows[0]["PAT_NO"].ToString());
                            if (chk)
                            {
                                if (Ptnt_Dt != null)
                                {
                                    //SendSMS(chk, Common.Pat_No, Common.YKIHO);
                                    PopupMessage popupMessage = new PopupMessage();
                                    popupMessage.Names = name;
                                    popupMessage.message = "접수되었습니다.";
                                    popupMessage.result = "대기해 주시면 순차적으로 안내 도와드리겠습니다.";
                                    popupMessage.StartPosition = FormStartPosition.CenterScreen;
                                    popupMessage.ShowDialog();
                                }
                            }
                            else
                            {
                                PopupMessage popupMessage = new PopupMessage();
                                popupMessage.Names = Ptnt_Dt.Rows[0]["PAT_NO"].ToString();
                                popupMessage.message = "접수중 오류가 발생하였습니다.";
                                popupMessage.StartPosition = FormStartPosition.CenterScreen;
                                popupMessage.ShowDialog();
                            }
                        }
                        else
                        {
                            //MessageBox.Show("취소되었습니다.");
                        }
                    }
                }
                else
                {
                    //신환 접수
                    //1. 신환 등록
                    //2. 신환 접수
                    //Common.PageMove("InputPersonalNO", "InputMobileNo", "1");
                    var _chk = SetPtntInfo(name, pat_jno2, surgery, mobile, address, kind, SMS, personalInfo, rcvEventMsg);
                    if (!_chk) //신환 등록
                    {
                        //SendSMS(_chk, Common.Pat_No, Common.YKIHO);
                        PopupMessage popupMessage = new PopupMessage();
                        popupMessage.Names = Ptnt_Dt.Rows[0]["PAT_NM"].ToString();
                        popupMessage.message = "신규 등록중 오류가 발생하였습니다.";
                        popupMessage.StartPosition = FormStartPosition.CenterScreen;
                        popupMessage.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.SetLog(ex.Message, 3);
                //MessageBox.Show(ex.Message);
            }
        }

        internal static bool SetPtntInfo(string name, string pat_jno2, string surgery, string mobile, string address, string kind, string sMS, string personalInfo, string rcvEventMsg)
        {
            bool chk = true;
            StringBuilder sb = new StringBuilder();
            try
            {
                //수진자번호(PAT_NO) 생성하기
                sb.AppendLine($" SELECT LPAD(IFNULL(MAX(PAT_NO) + 1, 1), 10, 0) AS PAT_NO ");
                sb.AppendLine($"   FROM PTNT_INFO ");
                sb.AppendLine($"  WHERE YKIHO = '{Common.YKIHO}' ");
                sb.AppendLine($"    AND SUBSTRING(PAT_NO, 1, 1) <> '6' ");
                DataTable dt = DBCommon.SelectData(sb.ToString());
                string pat_no = dt.Rows[0]["PAT_NO"].ToString();
                if (pat_no != "")
                {
                    Common.Pat_No = pat_no;
                }
                else
                {
                    MessageBox.Show("수진자번호 생성을 실패하였습니다.");
                    chk = false;
                }

                //신규차트번호
                sb = new StringBuilder();
                sb.AppendLine($" SELECT LPAD(IFNULL(MAX(RCNT_CHART_NO + 1), 0), 10, 0) AS CHART_NO FROM HOSP_INFO WHERE YKIHO = '{Common.YKIHO}' ");
                DataTable dt20 = new DataTable();
                dt20 = DBCommon.SelectData(sb.ToString());
                string cahrt_no = string.Join(Environment.NewLine, dt20.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));
                //신환 등록
                sb = new StringBuilder();
                sb.AppendLine($" INSERT INTO PTNT_INFO (YKIHO, PAT_NO, PAT_NM, CHART_NO, PAT_JNO2, MOBILE_NO, ADDR, SMS_AGR_YN, AD_SMS_AGR_YN, PRSN_INFO_AGR_YN, FRST_REG_ID, FRST_REG_DT, LAST_MOD_ID, LAST_MOD_DT)");
                sb.AppendLine($" VALUES (");
                sb.AppendLine($"   '{Common.YKIHO}'");
                sb.AppendLine($" , '{Common.Pat_No}'");
                sb.AppendLine($" , '{name}'");
                sb.AppendLine($" , '{cahrt_no}'");
                sb.AppendLine($" , '{pat_jno2.Replace("*", "")}'");
                sb.AppendLine($" , '{mobile}'");
                sb.AppendLine($" , '{address}'");
                sb.AppendLine($" , '{sMS}'");
                sb.AppendLine($" , '{personalInfo}'");
                sb.AppendLine($" , '{rcvEventMsg}'");
                sb.AppendLine($" , '{Common.USER_ID}'");
                sb.AppendLine($" , Now()");
                sb.AppendLine($" , '{Common.USER_ID}'");
                sb.AppendLine($" , Now()");
                sb.AppendLine($" ) ON DUPLICATE KEY UPDATE LAST_MOD_ID = '{Common.USER_ID}'");
                sb.AppendLine($" , LAST_MOD_DT = NOW()");
                int rowAffected = DBCommon.InsertIF(sb.ToString());

                // 차트 병원번호 업데이트
                sb = new StringBuilder();
                sb.AppendLine($"UPDATE HOSP_INFO SET");
                sb.AppendLine($"           RCNT_CHART_NO='{cahrt_no}'");
                sb.AppendLine($"          , LAST_MOD_ID='{Common.userid}'");
                sb.AppendLine($"          , LAST_MOD_DT=NOW() WHERE YKIHO='{Common.YKIHO}'");
                int hospUpdate = DBCommon.InsertIF(sb.ToString());

                if (rowAffected > 0)
                {
                    //신환 등록후 재조회
                    sb = new StringBuilder();
                    sb.AppendLine($" SELECT PAT_NO , PAT_NM , PAT_BTH , MOBILE_NO ");
                    sb.AppendLine($" FROM PTNT_INFO ");
                    sb.AppendLine($" WHERE MOBILE_NO  like '%{mobile}%'");
                    DataTable Ptnt_Dt = DBCommon.SelectData(sb.ToString());

                    if (Ptnt_Dt.Rows.Count > 0) //정상등록시
                    {
                        chk = SetReceipt(name, pat_jno2, mobile, Common.Pat_No);
                        if (chk)
                        {
                            SendSMS(chk, Common.Pat_No, Common.YKIHO);
                            PopupMessage popupMessage = new PopupMessage();
                            popupMessage.Names = name + " " + mobile;
                            popupMessage.message = "신규 고객 등록 및 접수되었습니다.";
                            popupMessage.result = "대기해 주시면 순차적으로 안내 도와드리겠습니다.";
                            popupMessage.StartPosition = FormStartPosition.CenterScreen;
                            popupMessage.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.SetLog(ex.Message, 3);
                MessageBox.Show(ex.Message);
                chk = false;
            }

            return chk;
        }

        /// <summary>
        /// 접수하기
        /// </summary>
        //internal static bool SetReceipt(string name, string birthday, string mobile, string PAT_NO)
        //{
        //    bool chk = false;
        //    StringBuilder sb = new StringBuilder();
        //    int ret = 0;
        //    string today = DateTime.Now.ToString("yyyyMMdd");
        //    sb.AppendLine($"  SELECT PAT_NO ");
        //    sb.AppendLine($"  FROM PTNT_DETL ");
        //    sb.AppendLine($"  WHERE YKIHO = '{Common.YKIHO}' ");
        //    sb.AppendLine($"    AND PAT_NO = '{PAT_NO}' ");
        //    sb.AppendLine($"    AND ACPT_DD = '{today}' ");
        //    sb.AppendLine($"    AND PRGR_STAT_CD NOT IN('A', 'F') ");
        //    DataTable dt10 = DBCommon.SelectData(sb.ToString());

        //    if (dt10.Rows.Count > 0)
        //    {
        //        if (MessageBox.Show("해당 일자에 접수된 기록이 있습니다.", "접수하시겠습니까?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            //보험처리
        //            //접수
        //            if ((ret = SaveAcpt(Common.YKIHO, PAT_NO)) != 0)
        //            {
        //                chk = true;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        //접수
        //        if ((ret = SaveAcpt(Common.YKIHO, PAT_NO)) != 0)
        //        {
        //            chk = true;
        //        }
        //    }
        //    return chk;
        //}

        internal static bool SetReceipt(string name, string birthday, string mobile, string PAT_NO)
        {
            bool chk = true;
            StringBuilder sb = new StringBuilder();
            int ret = 0;
            string today = DateTime.Now.ToString("yyyyMMdd");
            string vist_sn = string.Empty;

            // 금일날짜로 예약or부도 건 있는지 조회.
            sb.AppendLine($"SELECT  *");
            sb.AppendLine($"FROM    PTNT_DETL");
            sb.AppendLine($"WHERE   YKIHO = '{Common.YKIHO}'");
            sb.AppendLine($"AND     PAT_NO = '{PAT_NO}'");
            sb.AppendLine($"AND     RSRV_DD = '{today}'");
            sb.AppendLine($"AND     PRGR_STAT_CD IN ('A','F')");
            sb.AppendLine($"ORDER BY PRGR_STAT_CD");

            DataTable dt10 = DBCommon.SelectData(sb.ToString());

            if (dt10.Rows.Count > 0)
            {
                vist_sn = dt10.Rows[0]["VIST_SN"].ToString();

                // detl 업데이트
                if ((ret = UpdateAcpt(Common.YKIHO, PAT_NO, vist_sn)) != 0)
                {
                    chk = false;
                }
            }
            else
            {
                // 없으니 생접수
                if ((ret = SaveAcpt(Common.YKIHO, PAT_NO)) != 0)
                {
                    chk = false;
                }
            }
            return chk;
        }

        internal static int UpdateAcpt(string ykiho, string pat_no, string vist_sn)
        {
            int ret = 0;
            List<string> lstStrSql = new List<string>();

            StringBuilder sb = new StringBuilder();
            string today = DateTime.Now.ToString("yyyyMMdd");
            string time = DateTime.Now.ToString("HHmm");

            sb.AppendLine($"UPDATE  PTNT_DETL");
            sb.AppendLine($"SET     PRGR_STAT_CD = 'B'");
            sb.AppendLine($"        ,ACPT_DD = '{today}'");
            sb.AppendLine($"        ,ACPT_TM = '{time}'");
            sb.AppendLine($"        ,ACPT_CFR_ID = '{Common.userid}'");
            sb.AppendLine($"        ,RSRV_CNCL_YN=0");
            sb.AppendLine($"        ,ACPT_CNCL_YN=0");
            sb.AppendLine($"        ,INSU_KND_CD= 'B01'");
            sb.AppendLine($"        ,STATUS_BOARD_CD ='A'");
            sb.AppendLine($"        ,STATUS_TIME= NOW()");
            sb.AppendLine($"        ,LAST_MOD_ID='{Common.userid}'");
            sb.AppendLine($"        ,LAST_MOD_DT=NOW()");
            sb.AppendLine($"WHERE   YKIHO='{ykiho}'");
            sb.AppendLine($"AND     PAT_NO='{pat_no}'");
            sb.AppendLine($"AND     VIST_SN='{vist_sn}'");
            //lstStrSql.Add(sb.ToString());
            if ((ret = DBCommon.ExecSQLRsltCnt(sb.ToString())) != 0) return ret;

            sb = new StringBuilder();
            sb.AppendLine($"UPDATE  PTNT_INFO");
            sb.AppendLine($"SET     INSU_KND_CD = 'BO1'");
            sb.AppendLine($"        ,RCNT_VST_DD = '{today}'");
            sb.AppendLine($"        ,LAST_MOD_ID = '{Common.userid}'");
            sb.AppendLine($"        ,LAST_MOD_DT = NOW()");
            sb.AppendLine($"WHERE   YKIHO = '{ykiho}'");
            sb.AppendLine($"AND     PAT_NO = '{pat_no}'");
            lstStrSql.Add(sb.ToString());
            if ((ret = DBCommon.ExecSQLRsltCnt(sb.ToString())) != 0) return ret;

            //if ((ret = DBCommon.GetSQLMultiResult(lstStrSql)) != 0) return ret;

            return ret;
        }

        internal static int SaveAcpt(string yKIHO, string pAT_NO)
        {
            int ret = 0;
            int val = 0;
            string today = DateTime.Now.ToString("yyyyMMdd");
            string currenttime = DateTime.Now.ToString("HHmm");
            List<string> lstStrSQL = new List<string>();
            DataTable table = new DataTable();
            bool late_ = false; // 지연설정 
            //string strSQL = "";
            string insu_Knd_Cd = string.Empty;
            string rcntVstDd = string.Empty;
            string diagTpCd = "C01";
            string vistsn = string.Empty;

            try
            {
                insu_Knd_Cd = "B01";

                #region 기존

                //StringBuilder sb = new StringBuilder();
                //int cnt = CheckPatRegvInfo(yKIHO, pAT_NO, ref vistsn);
                //if (cnt > 0)
                //{
                //    sb.AppendLine($" SELECT MAX(ACPT_DD) AS MAX_ACPT_DD, PAT_NO");
                //    sb.AppendLine($"   FROM PTNT_DETL");
                //    sb.AppendLine($"  WHERE YKIHO = '{yKIHO}'");
                //    sb.AppendLine($"    AND PAT_NO = '{pAT_NO}'");
                //    sb.AppendLine($"    AND PRGR_STAT_CD NOT IN ('A', 'F')");
                //    sb.AppendLine($"    AND RSRV_CNCL_YN = FALSE");
                //    sb.AppendLine($"    AND DEL_YN = FALSE");
                //    var _dt40 = DBCommon.SelectData(sb.ToString());

                //    string Temp = _dt40.Rows[0]["PAT_NO"].ToString();
                //    if (Temp != "")
                //    {
                //        string MAX_ACPT_DD = _dt40.Rows[0]["MAX_ACPT_DD"].ToString();
                //        //int res = Convert.ToInt32();

                //        sb = new StringBuilder();
                //        //sb.AppendLine($" SELECT LPAD(IFNULL(MAX(VIST_SN) + 1, 1), 5, 0) FROM PTNT_DETL WHERE YKIHO='{yKIHO}' AND PAT_NO = '{pAT_NO}'");                  
                //        //sb.AppendLine($" SELECT LPAD(IFNULL(MAX(VIST_SN) , 1), 5, 0) AS VIST_SN FROM PTNT_DETL WHERE YKIHO='{yKIHO}' AND PAT_NO = '{pAT_NO}'");
                //        //var dt30 = DBCommon.SelectData(sb.ToString());
                //        rcntVstDd = _dt40.Rows[0]["MAX_ACPT_DD"].ToString();
                //        //vistsn = dt10.Rows[0]["VIST_SN"].ToString();

                //        vistsn = DBCommon.ChkVISTNum(yKIHO, pAT_NO);
                //        //dt30.Rows[0]["VIST_SN"].ToString();
                //        //DBCommon.ChkVISTNum(yKIHO, pAT_NO);

                //        rcntVstDd = today;
                //        //string.Join(Environment.NewLine, dt10.Rows.OfType<DataRow>().Select(x => string.Join(" ; ", x.ItemArray)));

                //        /*
                //        if (!string.IsNullOrEmpty(rcntVstDd))
                //        {
                //            diagTpCd = "C02";
                //            if (DateTime.Compare(Convert.ToDateTime(today), DateTime.ParseExact(rcntVstDd, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None)) > 0)
                //            {
                //                rcntVstDd = today;
                //            }
                //        }
                //        */

                //        #region PTNT_DETL(INSERT, UPDATE)
                //        sb = new StringBuilder();
                //        sb.AppendLine($" UPDATE PTNT_DETL ");
                //        sb.AppendLine($" SET ");
                //        sb.AppendLine($"    PRGR_STAT_CD = 'B' ");

                //        string strSQL10 = "/* queryID : 환자정보 조회 쌩접수 */";
                //        strSQL10 += Environment.NewLine + "SELECT ACPT_DD";
                //        strSQL10 += Environment.NewLine + "  FROM PTNT_DETL";
                //        strSQL10 += Environment.NewLine + " WHERE YKIHO    = '" + Common.YKIHO + "'";
                //        strSQL10 += Environment.NewLine + "   AND PAT_NO   = '" + pAT_NO + "'";
                //        strSQL10 += Environment.NewLine + "   AND VIST_SN   = '" + vistsn + "'";
                //        DataTable dt40 = new DataTable();
                //        var dt10 = DBCommon.SelectData(strSQL10);

                //        //접수기록이 없을때만 업데이트
                //        //if (string.IsNullOrEmpty(dt10.Rows[0]["ACPT_DD"].ToString()))
                //        if (dt10.Rows.Count == 0)
                //        {
                //            sb.AppendLine($" ,  ACPT_DD = '{today}'");        //접수일자 
                //            sb.AppendLine($" ,  ACPT_TM = '{currenttime}'");  //접수시간
                //            late_ = true;
                //        }
                //        sb.AppendLine($" , RSRV_CNCL_YN=0");                  //예약취소여부(0:false, 1:true
                //        sb.AppendLine($" , ACPT_CNCL_YN=0");                  //접수취소여부(0:false, 1:true)
                //        sb.AppendLine($" , INSU_KND_CD= '{insu_Knd_Cd}'");    //보험종류코드
                //        sb.AppendLine($" , STATUS_BOARD_CD ='A'");
                //        sb.AppendLine($" , STATUS_TIME= NOW()");
                //        sb.AppendLine($" , LAST_MOD_ID='{Common.userid}'");
                //        sb.AppendLine($" , LAST_MOD_DT=NOW()");
                //        sb.AppendLine($" WHERE YKIHO='{yKIHO}'");
                //        sb.AppendLine($"   AND PAT_NO='{pAT_NO}'");
                //        sb.AppendLine($"   AND VIST_SN='{vistsn}'");
                //        val = DBCommon.UpdateQuery2(sb.ToString());

                //        sb = new StringBuilder();
                //        sb.AppendLine($" UPDATE PTNT_INFO SET");
                //        sb.AppendLine($"    INSU_KND_CD='BO1'");              //보험종류코드
                //        sb.AppendLine($"  , RCNT_VST_DD='{rcntVstDd}'");      //최근내원일자
                //        sb.AppendLine($"  , LAST_MOD_ID='{Common.userid}'"); //최종수정자ID
                //        sb.AppendLine($"  , LAST_MOD_DT=NOW() ");
                //        sb.AppendLine($" WHERE YKIHO='{yKIHO}'");
                //        sb.AppendLine($"   AND PAT_NO='{pAT_NO}'");           //최종수정일
                //        val = val + DBCommon.UpdateQuery2(sb.ToString());

                //        if (val == 2)
                //        {
                //            ret = 1;
                //        }
                //        #endregion
                //    }
                //}
                //else
                //{
                //    if (string.IsNullOrEmpty(vistsn))
                //    {
                //        vistsn = "00001";
                //    }
                //    sb = new StringBuilder();
                //    sb.AppendLine($" INSERT INTO PTNT_DETL(YKIHO, PAT_NO, VIST_SN, PRGR_STAT_CD, ACPT_DD, RSRV_DD, RSRV_TM, RSRV_CNCL_YN, FRST_REG_ID, FRST_REG_DT, LAST_MOD_ID, LAST_MOD_DT)");
                //    sb.AppendLine($" VALUES(");
                //    sb.AppendLine($"   '{yKIHO}'");
                //    sb.AppendLine($" , '{pAT_NO}'");
                //    sb.AppendLine($" , '{vistsn}'");
                //    sb.AppendLine($" , 'B'");
                //    sb.AppendLine($" , '{today}'");
                //    sb.AppendLine($" , '{today}'");
                //    sb.AppendLine($" , '{currenttime.Replace(":", "")}'");
                //    sb.AppendLine($" , '0'");
                //    sb.AppendLine($" , '{Common.userid}'");
                //    sb.AppendLine($" , NOW()");
                //    sb.AppendLine($" , '{Common.userid}'");
                //    sb.AppendLine($" , NOW()");
                //    //sb.AppendLine($" , '{}'");
                //    sb.AppendLine($" ) ON DUPLICATE KEY UPDATE ");
                //    sb.AppendLine($"   PRGR_STAT_CD='B'");
                //    sb.AppendLine($" , ACPT_DD = '{today}'");
                //    sb.AppendLine($" , ACPT_TM = '{currenttime.Replace(":", "")}'");
                //    sb.AppendLine($" , ACPT_CNCL_YN = '0' ");
                //    //sb.AppendLine($"   FRST_REG_ID = 'App'");
                //    //sb.AppendLine($"   FRST_REG_DT = NOW()");
                //    sb.AppendLine($" , LAST_MOD_ID = '{Common.userid}'");
                //    sb.AppendLine($" , LAST_MOD_DT = NOW()");
                //    ret = DBCommon.InsertIF(sb.ToString());

                //}
                #endregion

                #region 변경
                vistsn = DBCommon.ChkVISTNum(yKIHO, pAT_NO);
                StringBuilder sb = new StringBuilder();
                sb = new StringBuilder();
                sb.AppendLine($" INSERT INTO PTNT_DETL(YKIHO, PAT_NO, VIST_SN, PRGR_STAT_CD, ACPT_DD, RSRV_DD, RSRV_TM, RSRV_CNCL_YN, FRST_REG_ID, FRST_REG_DT, LAST_MOD_ID, LAST_MOD_DT)");
                sb.AppendLine($" VALUES(");
                sb.AppendLine($"   '{yKIHO}'");
                sb.AppendLine($" , '{pAT_NO}'");
                sb.AppendLine($" , '{vistsn}'");
                sb.AppendLine($" , 'B'");
                sb.AppendLine($" , '{today}'");
                sb.AppendLine($" , '{today}'");
                sb.AppendLine($" , '{currenttime}'");
                sb.AppendLine($" , '0'");
                sb.AppendLine($" , '{Common.userid}'");
                sb.AppendLine($" , NOW()");
                sb.AppendLine($" , '{Common.userid}'");
                sb.AppendLine($" , NOW()");
                sb.AppendLine($" ) ON DUPLICATE KEY UPDATE ");
                sb.AppendLine($"   PRGR_STAT_CD='B'");
                sb.AppendLine($" , ACPT_DD = '{today}'");
                sb.AppendLine($" , ACPT_TM = '{currenttime}'");
                sb.AppendLine($" , ACPT_CNCL_YN = '0' ");
                //sb.AppendLine($"   FRST_REG_ID = '{Common.userid}'");
                //sb.AppendLine($"   FRST_REG_DT = NOW()");
                sb.AppendLine($" , LAST_MOD_ID = '{Common.userid}'");
                sb.AppendLine($" , LAST_MOD_DT = NOW()");
                if ((ret = DBCommon.ExecSQLRsltCnt(sb.ToString())) != 0) return ret;
                #endregion
            }
            catch (Exception ex)
            {
                Common.SetLog(ex.Message, 3);
                MessageBox.Show(ex.Message);
                ret = -1;
            }

            return ret;
        }

        internal static int CheckPatRegvInfo(string yKIHO, string pAT_NO, ref string vist_sn)
        {
            int ret = 0;
            vist_sn = DBCommon.ChkVISTNum(yKIHO, pAT_NO);
            StringBuilder sb = new StringBuilder();
            DataTable table;

            sb.AppendLine($"SELECT RSRV_DD");
            sb.AppendLine($"     , RSRV_TM");
            sb.AppendLine($"     , PRGR_STAT_CD");
            sb.AppendLine($"  FROM PTNT_DETL");
            sb.AppendLine($" WHERE YKIHO = '{yKIHO}'");
            sb.AppendLine($"   AND PAT_NO = '{pAT_NO}'");
            sb.AppendLine($"   AND VIST_SN = '{vist_sn}'");
            sb.AppendLine($"   AND DEL_YN = FALSE");

            //if ((ret = DBCommon.SelectData(sb.ToString(), DBContactor.SQL_CONN_MOTION, out table)) != 0) return -1;
            DataTable getdata = DBCommon.SelectData(sb.ToString());
            //string acptDate = DateTime.Now.ToString("yyyyMMdd");
            ret = getdata.Rows.Count;
            DateTime acptDate = DateTime.Now;
            if (getdata.Rows.Count > 0)
            {
                if (getdata.Rows[0]["RSRV_TM"].ToString() == "0000")
                    return ret;

                //DateTime reservationDate = DateTime.ParseExact($"{table.Rows[0]["RSRV_DD"]}", "yyyyMMdd", null);

                if (DateTime.TryParseExact(getdata.Rows[0]["RSRV_DD"].ToString(), "yyyyMMdd", null, DateTimeStyles.None, out DateTime dateTime))
                {
                    if (DateTime.Compare(acptDate.Date, dateTime.Date) < 0)
                    {
                        return -1;
                    }
                }
            }

            return ret;
        }

        internal static void SendSMS(bool late_, string pAT_NO, string yKIHO)
        {
            //SMS 전송 부분 키오스크에서 접수시 문자 수신 여부 
            //기획에게 문의후 작업 예정
            string message_ = "[접수안내]\r\n접수 완료 되었습니다.\r\n[CRM안내]\r\n전송된 결과가 없습니다.";
            string AC_Me = "";
            string LA_Me = "";
            StringBuilder sb = new StringBuilder();
            if (late_)
            {
                //접수발송
                bool send_AcptSMS = false;
                sb.AppendLine($" SELECT IFNULL(pi2.SMS_AGR_YN, '0') AS SMS_AGR_YN");
                sb.AppendLine($"      , pi2.MOBILE_NO");
                sb.AppendLine($"      , pi2.PAT_NM");
                sb.AppendLine($"      , pi2.PAT_NO");
                sb.AppendLine($"      , (select max(pd.VIST_SN) as VIST_SN from PTNT_DETL pd where pd.PAT_NO = pi2.PAT_NO and pd.YKIHO = pi2.YKIHO) as VIST_SN");
                sb.AppendLine($" FROM PTNT_INFO pi2");
                sb.AppendLine($" WHERE PAT_NO = '{pAT_NO}'");
                sb.AppendLine($" AND YKIHO = '{yKIHO}'");
                var dt20 = DBCommon.SelectData(sb.ToString());
                string MobileNo = dt20.Rows[0]["MOBILE_NO"].ToString();
                string Pat_no = dt20.Rows[0]["PAT_NO"].ToString();
                string Pat_nm = dt20.Rows[0]["PAT_NM"].ToString();
                string Vist_sn = dt20.Rows[0]["VIST_SN"].ToString();
                //bool ret = retMsg == "1" ? true : false;
                bool Accept = dt20.Rows[0]["SMS_AGR_YN"].ToString() == "0" ? true : false;
                send_AcptSMS = Common.send_SMS(Accept, MobileNo, Pat_no, Vist_sn, yKIHO);
                if (send_AcptSMS)
                {
                    message_ = "[접수안내]\r\n접수 완료 되었습니다.\r\n[CRM안내]\r\n";
                    AC_Me = "[접수 CRM] = 발송되었습니다.\r\n";
                }
                /*
                PopupMessage popupMessage = new PopupMessage();
                popupMessage.Name = Pat_nm;
                popupMessage.message = message_;
                popupMessage.result = AC_Me;
                popupMessage.ShowDialog();
                */
            }
        }
    }
}