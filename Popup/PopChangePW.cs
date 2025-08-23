using CommonLib;
using Kiosk.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Kiosk.Popup
{
    public partial class PopChangePW : Form
    {
        public string old_password { get; internal set; }

        //SHA256 sha256 = new SHA256Managed();

        public PopChangePW()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnChangePW_Click(object sender, EventArgs e)
        {
            //# 사용자 체크
            string strSQL = "/* queryID : 사용자 체크 */";
            strSQL += Environment.NewLine + "SELECT USER_ID";
            strSQL += Environment.NewLine + "     , USER_PW";
            strSQL += Environment.NewLine + "  FROM USER_INFO";
            strSQL += Environment.NewLine + " WHERE YKIHO   = '" + Common.YKIHO + "'";
            strSQL += Environment.NewLine + "   AND USER_ID = '" + txtUserID.Text + "'";

            DataTable dtUser = DBCommon.SelectData(strSQL);
            if (dtUser.Rows.Count == 0)
            {
                //MessageBox.Show(this, "존재하지 않는 사용자입니다.", "", MessageBoxButtons.OK);
                ErrorPopupMessage popupMessage = new ErrorPopupMessage();
                popupMessage.result = "존재하지 않는 사용자입니다.";
                popupMessage.ShowDialog();
                return;
            }

            //# 비밀번호 체크
            //비밀번호 암호화 부분 - 수정예정
            string encPW = ComLib.SHA256(txtUserPW.Text);
            //string encPW = txtUserPW.Text;
            /*
            byte[] hash = sha256.ComputeHash(Encoding.ASCII.GetBytes(txtUserPW.Text));
            StringBuilder sb = new StringBuilder();

            foreach (byte b in hash)
            {
                sb.AppendFormat("{0:x02}", b);
            }

            string encPW = sb.ToString();
            */
            string old_PW = dtUser.Rows[0]["USER_PW"].ToString();
            if (encPW != old_PW)
            {
                //MessageBox.Show(this, "기존 비밀번호가 올바르지 않습니다.", "", MessageBoxButtons.OK);
                ErrorPopupMessage popupMessage = new ErrorPopupMessage();
                popupMessage.result = "기존 비밀번호가 올바르지 않습니다.";
                popupMessage.ShowDialog();
                txtUserPW.Focus();
                txtUserPW.SelectAll();
                return;
            }

            //# 비밀번호 Validation 체크
            if (!ChkPwdValidation(txtNewPw.Text))
            {
                return;
            }

            //# 새 비밀번호 update
            UpdateNewPw();

            this.TopMost = true;
        }

        private void UpdateNewPw()
        {
            List<string> lstStrSQL = new List<string>();
            string strSQL = "/* queryID : UpdateNewPw - 새 비밀번호 update */";
            strSQL += Environment.NewLine + "UPDATE USER_INFO";
            strSQL += Environment.NewLine + "   SET USER_PW     = '" + ComLib.SHA256(txtNewPw.Text) + "'"; //# 비밀번호
            strSQL += Environment.NewLine + "     , PW_ERR_CNT  = 0";                                      //# 비밀번호오류횟수
            strSQL += Environment.NewLine + "     , PW_INIT_YN  = FALSE";                                  //# 비밀번호초기화여부
            strSQL += Environment.NewLine + "     , PW_CHG_DT   =  NOW()";                                 //# 비밀번호수정일시
            strSQL += Environment.NewLine + "     , LAST_MOD_ID = '" + Common.USER_ID + "'";          //# 최종수정자ID
            strSQL += Environment.NewLine + "     , LAST_MOD_DT = NOW()";                                  //# 최종수정일시
            strSQL += Environment.NewLine + " WHERE YKIHO   = '" + Common.YKIHO + "'";
            strSQL += Environment.NewLine + "   AND USER_ID = '" + txtUserID.Text + "'";
            int cntUpdate = DBCommon.UpdateQuery2(strSQL);            

            //lstStrSQL.Add(strSQL);
            //string strSQL1 = "";
            strSQL = "/* queryID : UpdateNewPw - 비밀번호 이력 insert */";
            strSQL += Environment.NewLine + "INSERT INTO USER_PWCHG_HIST";
            strSQL += Environment.NewLine + "          ( YKIHO";
            strSQL += Environment.NewLine + "          , USER_ID";
            strSQL += Environment.NewLine + "          , HIST_NO";
            strSQL += Environment.NewLine + "          , USER_BF_PW";
            strSQL += Environment.NewLine + "          , FRST_REG_ID";
            strSQL += Environment.NewLine + "          , FRST_REG_DT";
            strSQL += Environment.NewLine + "          , LAST_MOD_ID";
            strSQL += Environment.NewLine + "          , LAST_MOD_DT";
            strSQL += Environment.NewLine + "          )";
            strSQL += Environment.NewLine + "   VALUES ( '" + Common.YKIHO + "'";
            strSQL += Environment.NewLine + "          , '" + txtUserID.Text + "'";
            strSQL += Environment.NewLine + "          , (SELECT IFNULL(MAX(HIST.HIST_NO)+ 1, 1) HIST_NO";
            strSQL += Environment.NewLine + "               FROM USER_PWCHG_HIST HIST";
            strSQL += Environment.NewLine + "              WHERE HIST.YKIHO   = '" + Common.YKIHO + "'";
            strSQL += Environment.NewLine + "                AND HIST.USER_ID = '" + Common.USER_ID + "')";
            strSQL += Environment.NewLine + "          , '" + ComLib.SHA256(txtNewPw.Text) + "'";
            strSQL += Environment.NewLine + "          , '" + Common.USER_ID + "'";
            strSQL += Environment.NewLine + "          , NOW()";
            strSQL += Environment.NewLine + "          , '" + Common.USER_ID + "'";
            strSQL += Environment.NewLine + "          , NOW()";
            strSQL += Environment.NewLine + "          )";
            DBCommon.UpdateQuery(strSQL);
            //lstStrSQL.Add(strSQL);

            //int cntUpdate = DBCommon.UpdateQuery2(lstStrSQL);

            if (cntUpdate == 0)
            {
                //MessageBox.Show(this, "비밀번호 변경에 실패하였습니다.", "", MessageBoxButtons.OK);
                ErrorPopupMessage popupMessage = new ErrorPopupMessage();
                popupMessage.result = "비밀번호 변경에 실패하였습니다.";
                popupMessage.ShowDialog();
            }
            else
            {
                //MessageBox.Show(this, "비밀번호를 변경하였습니다. 다시 로그인해주세요.", "", MessageBoxButtons.OK);
                ErrorPopupMessage popupMessage = new ErrorPopupMessage();
                popupMessage.result = "비밀번호를 변경하였습니다."
                                    + Environment.NewLine
                                    + "다시 로그인해주세요.";
                popupMessage.ShowDialog();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ChkPwdValidation(string pPwd)
        {
            if (txtNewPw.Text == txtUserPW.Text)
            {
                //MessageBox.Show(this, "현재 비밀번호와 동일하게 변경할 수 없습니다.", "", MessageBoxButtons.OK);
                ErrorPopupMessage popupMessage = new ErrorPopupMessage();
                popupMessage.result = "현재 비밀번호와 동일하게 변경할 수 없습니다.";
                popupMessage.ShowDialog();
                txtNewPw.Focus();
                txtNewPw.SelectAll();
                return false;
            }

            //# 직전 비밀번호 체크
            string bfPw = GetBfPw();
            if (!string.IsNullOrEmpty(bfPw))
            {
                //if (txtNewPw.Text == bfPw)
                //비밀번호 암호화 부분 - 수정예정
                if (ComLib.SHA256(txtNewPw.Text) == bfPw)
                {
                    //MessageBox.Show(this, "직전 비밀번호는 사용할 수 없습니다.", "", MessageBoxButtons.OK);
                    ErrorPopupMessage popupMessage = new ErrorPopupMessage();
                    popupMessage.result = "직전 비밀번호는 사용할 수 없습니다.";
                    popupMessage.ShowDialog();
                    txtNewPw.Focus();
                    txtNewPw.SelectAll();
                    return false;
                }
            }

            //# 정규식 - 숫자1이상, 영문자1이상, 특수문자 1이상, 글자수 8자리 이상
            Regex rxPassword = new Regex(@"^(?=.*?[a-zA-Z])(?=.*?[0-9])(?=.*?[`~!@#$%^&*()-_=+]).{8,}$", RegexOptions.IgnorePatternWhitespace);
            if (!rxPassword.IsMatch(pPwd))
            {
                //MessageBox.Show(this, "새 비밀번호가 비밀번호 규칙에 맞지 않습니다.", "", MessageBoxButtons.OK);
                ErrorPopupMessage popupMessage = new ErrorPopupMessage();
                popupMessage.result = "새 비밀번호가 비밀번호 규칙에 맞지 않습니다.";
                popupMessage.ShowDialog();
                txtNewPw.Focus();
                txtNewPw.SelectAll();
                return false;
            }

            if (txtNewPw.Text != txtNewPwChk.Text)
            {
                //MessageBox.Show(this, "새 비밀번호와 비밀번호 확인이 다릅니다.", "", MessageBoxButtons.OK);
                ErrorPopupMessage popupMessage = new ErrorPopupMessage();
                popupMessage.result = "새 비밀번호와 비밀번호 확인이 다릅니다.";
                popupMessage.ShowDialog();
                txtNewPwChk.Focus();
                txtNewPwChk.SelectAll();
                return false;
            }

            return true;
        }

        private string GetBfPw()
        {
            string strSQL = "/* queryID : GetBfPw - 직전 비밀번호 조회 */";
            strSQL += Environment.NewLine + "SELECT INFO.PW_INIT_YN";
            strSQL += Environment.NewLine + "     , HIST.USER_BF_PW";
            strSQL += Environment.NewLine + "  FROM USER_INFO       INFO";
            strSQL += Environment.NewLine + "     , USER_PWCHG_HIST HIST";
            strSQL += Environment.NewLine + " WHERE INFO.YKIHO   = '" + Common.YKIHO + "'";
            strSQL += Environment.NewLine + "   AND INFO.USER_ID = '" + txtUserID.Text + "'";
            strSQL += Environment.NewLine + "   AND HIST.YKIHO   = INFO.YKIHO";
            strSQL += Environment.NewLine + "   AND HIST.USER_ID = INFO.USER_ID";
            strSQL += Environment.NewLine + " ORDER BY HIST.HIST_NO DESC LIMIT 2";

            string rtnBfPw = string.Empty;
            DataTable dtPw = DBCommon.SelectData(strSQL);
            if (dtPw.Rows.Count == 1)
            {
                rtnBfPw = dtPw.Rows[0]["USER_BF_PW"].ToString();
            }
            else if (dtPw.Rows.Count == 2)
            {
                //# 초기화 되었을 경우에는 0, 나머지는 1
                if (Convert.ToBoolean(dtPw.Rows[1]["PW_INIT_YN"]))
                {
                    rtnBfPw = dtPw.Rows[0]["USER_BF_PW"].ToString();
                }
                else
                {
                    rtnBfPw = dtPw.Rows[1]["USER_BF_PW"].ToString();
                }
            }

            return rtnBfPw;
        }

        private void PopChangePW_Load(object sender, EventArgs e)
        {
            txtUserID.Text = Common.USER_ID;
            txtUserPW.Text = old_password;
            txtNewPw.Focus();
        }
    }
}
