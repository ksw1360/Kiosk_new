using Kiosk.Popup;
using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.Data;
using System.IO.Ports;
using System.Linq;
using static Kiosk.Sub_NewPtnt;
using System.Activities;

namespace Kiosk.Class
{
    public class Common
    {
        #region ini 입력 메소드
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        public static List<string> List { get; internal set; } = new List<string>();

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion

        #region 키보드 이벤트
        /// <summary>
        /// 키보드 이벤트 발생시키기
        /// </summary>
        /// <param name="virtualKey">가상 키</param>
        /// <param name="scanCode">스캔 코드</param>
        /// <param name="flag">플래그</param>
        /// <param name="extraInformation">추가 정보</param>
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte virtualKey, byte scanCode, uint flag, int extraInformation);

        [DllImport("user32.dll")]
        public static extern short GetKeyState(int keyCode);
        #endregion

        public static Main Main = null;
        public static Sub_NewPtnt Sub_NewPtnt = null;
        public static InputMobileNo InputMobileNo = null;
        public static InputMobileNo_Add InputMobileNo_Add = null;
        public static InputPersonalNO InputPersonalNO = null;
        public static InputAddress InputAddress = null;
        public static SurgeryKind2 SurgeryKindForm = null;
        public static ReceiptInfo ReceiptInfo = null;


        internal static SerialPort serialPort = new SerialPort();

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static string Name { get; internal set; }
        public static string MobileNO { get; internal set; }
        public static string PersonalNO { get; internal set; }
        public static string Address { get; internal set; }
        public static string YKIHO { get; internal set; }
        public static int check { get; internal set; }
        public static string USER_ID { get; internal set; }
        public static string USER_NM { get; internal set; }
        public static bool ADMIN_YN { get; internal set; }
        public static object USER_BTH { get; internal set; }
        public static string DR_LCS_NO { get; internal set; }
        public static string SurgeryKind { get; internal set; }
        public static string Pat_No { get; internal set; }
        public static string VIST_SN { get; internal set; }
        public static string SMS_YN { get; internal set; }
        public static string Rules { get; internal set; }
        public static string Ptntinfo { get; internal set; }
        public static string Eventarl { get; internal set; }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GetFocus();

        //private System.Timers.Timer timer;
        //internal static Timer timer;
        internal static int testdata = 0;
        internal static Form _form;


        internal static void ReturnMain()
        {
            //Common Init
            Init();
            PageMove("Main", _form.Name, "1");
        }

        public static string userid = "키오스크";

        public static string Mobile_Message = "휴대폰 번호를 입력해 주세요.";
        internal static string input;


        public class SendPatientModel
        {
            private string m_PatNo;
            public string PatNo
            {
                get { return m_PatNo; }
                set { this.m_PatNo = value; }
            }

            private string m_MobileNo;
            public string MobileNo
            {
                get { return m_MobileNo; }
                set { this.m_MobileNo = value; }
            }

            private string m_PatName;
            public string PatName
            {
                get { return m_PatName; }
                set { this.m_PatName = value; }
            }

            private string m_VisitSn;
            public string VisitSn
            {
                get { return m_VisitSn; }
                set { this.m_VisitSn = value; }
            }
            //고객 내원일(예약일)
            private string m_ReserveDate;
            public string ReserveDate
            {
                get { return m_ReserveDate; }
                set { this.m_ReserveDate = value; }
            }
            //고객 내원시간(예약시간)
            private string m_ReserveTime;
            public string ReserveTime
            {
                get { return m_ReserveTime; }
                set { this.m_ReserveTime = value; }
            }

            //수동발송 기능과 환자별 특정시간을 지정해야 할때 사용
            private string m_SendDateTime;
            public string SendDateTime
            {
                get { return m_SendDateTime; }
                set { this.m_SendDateTime = value; }
            }
        }

        #region Label Drawing Region 
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]            //Dll임포트
        private static extern IntPtr CreateRoundRectRgn                            //파라미터
    (
        int nLeftRect,      // x-coordinate of upper-left corner
        int nTopRect,       // y-coordinate of upper-left corner
        int nRightRect,     // x-coordinate of lower-right corner
        int nBottomRect,    // y-coordinate of lower-right corner
        int nWidthEllipse,  // height of ellipse
        int nHeightEllipse  // width of ellipse
    );
        #endregion

        #region QR code Reading Data 구환/신환 구분후 접수/창 이동
        internal static void ReadingQRcode(string text, string FormName)
        {
            try
            {
                text = text.Replace("\r", "");
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($" select qi.SERIAL_NO ");
                sb.AppendLine($"      , qi.YKIHO ");
                sb.AppendLine($"      , qi.PAT_NM ");
                sb.AppendLine($"      , qi.MOBILE_NO ");
                sb.AppendLine($"      , qi.QR_IMG ");
                sb.AppendLine($"      , qi.REG_DT ");
                sb.AppendLine($" from QR_INFO qi ");
                sb.AppendLine($" where SERIAL_NO = '{text}'");
                sb.AppendLine($" and   ykiho = '{Common.YKIHO}'");
                DataTable qrDT = DBCommon2.SelectData(sb.ToString());

                if (qrDT != null)
                {
                    if (qrDT.Rows.Count > 0)
                    {
                        #region 접수시작
                        Name = qrDT.Rows[0]["PAT_NM"].ToString();
                        MobileNO = qrDT.Rows[0]["MOBILE_NO"].ToString();
                        //string hpno = MobileNO.Substring(0, 3) + "-" + MobileNO.Substring(3, 4) + "-" + MobileNO.Substring(7, 4);
                        string hpno = MobileNO;
                        sb = new StringBuilder();
                        sb.AppendLine($" SELECT PAT_NO ");
                        sb.AppendLine($"      , PAT_NM ");
                        //sb.AppendLine($"      , REPLACE(PAT_NM, SUBSTRING(PAT_NM, 2, 1), '*') AS PAT_NM ");
                        sb.AppendLine($"      , PAT_BTH ");
                        //sb.AppendLine($"      , REPLACE(MOBILE_NO, SUBSTRING(MOBILE_NO, 5, 4), '****') AS MOBILE_NO ");
                        sb.AppendLine($"      , MOBILE_NO ");
                        sb.AppendLine($" FROM PTNT_INFO");
                        sb.AppendLine($" WHERE YKIHO = '{YKIHO}'");
                        sb.AppendLine($"   AND PAT_NM like '%{Name}%'");
                        //sb.AppendLine($"   AND MOBILE_NO = '{hpno}'");
                        sb.AppendLine($"AND REPLACE(MOBILE_NO,'-','') = '{hpno}'");
                        DataTable PtCntDT = DBCommon.SelectData(sb.ToString());
                        if (PtCntDT != null)
                        {
                            if (PtCntDT.Rows.Count > 0)
                            {
                                Ptnt_List_Popup ptnt_List_Popup = new Ptnt_List_Popup();
                                ptnt_List_Popup.dt = PtCntDT;
                                var dr = ptnt_List_Popup.ShowDialog();
                                if (dr == DialogResult.OK)
                                {
                                    bool chk = Receipt.SetReceipt(PtCntDT.Rows[0]["PAT_NM"].ToString()
                                             , PtCntDT.Rows[0]["PAT_BTH"].ToString()
                                             , PtCntDT.Rows[0]["MOBILE_NO"].ToString()
                                             , PtCntDT.Rows[0]["PAT_NO"].ToString());
                                    if (chk)
                                    {
                                        if (PtCntDT != null)
                                        {
                                            //SendSMS(chk, Common.Pat_No, Common.YKIHO);
                                            PopupMessage popupMessage = new PopupMessage();
                                            popupMessage.Names = Name;
                                            popupMessage.message = "접수되었습니다.";
                                            popupMessage.result = "대기해 주시면 순차적으로 안내 도와드리겠습니다.";
                                            popupMessage.StartPosition = FormStartPosition.CenterScreen;
                                            popupMessage.ShowDialog();
                                        }
                                    }
                                    else
                                    {
                                        PopupMessage popupMessage = new PopupMessage();
                                        popupMessage.Names = PtCntDT.Rows[0]["PAT_NO"].ToString();
                                        popupMessage.message = "접수중 오류가 발생하였습니다." + Environment.NewLine + "데스크에서 접수해주세요.";
                                        popupMessage.StartPosition = FormStartPosition.CenterScreen;
                                        popupMessage.ShowDialog();
                                    }
                                }
                            }
                            else
                            {
                                Common.check = 1;
                                //MessageBox.Show("환자 정보가 존재하지 않습니다."+Environment.NewLine+"신환으로 등록합니다." );
                                PopupMessage popupMessage = new PopupMessage();
                                popupMessage.Names = Name + " " + MobileNO.Substring(0, 3) + "-" + MobileNO.Substring(4, 4) + "-" + MobileNO.Substring(7, 4);
                                popupMessage.message = "데스크에서 접수해주세요.";
                                popupMessage.result = "고객님의 정보가 변경되어 접수에 실패했습니다.";
                                popupMessage.mode = 1;
                                popupMessage.ShowDialog();
                                PageMove("Sub_NewPtnt", FormName, "1");

                            }
                        }
                        else
                        {
                            PopupMessage popupMessage = new PopupMessage();
                            popupMessage.Names = Name + " " + MobileNO.Substring(0, 3) + "-" + MobileNO.Substring(4, 4) + "-" + MobileNO.Substring(7, 4);
                            popupMessage.message = "데스크에서 접수해주세요.";
                            popupMessage.result = "고객님의 정보가 변경되어 접수에 실패했습니다.";
                            popupMessage.mode = 1;
                            popupMessage.ShowDialog();
                            //신환
                            //Common.serialPort.Close();
                        }
                        #endregion
                    }
                    else
                    {
                        PopupMessage popupMessage = new PopupMessage();
                        popupMessage.Names = "";
                        popupMessage.message = "데스크에서 접수해주세요.";
                        popupMessage.result = "고객님의 정보가 변경되어 접수에 실패했습니다.";
                        popupMessage.ShowDialog();
                    }
                }
                else
                {
                    PopupMessage popupMessage = new PopupMessage();
                    popupMessage.Names = "";
                    popupMessage.message = "데스크에서 접수해주세요.";
                    popupMessage.result = "고객님의 정보가 변경되어 접수에 실패했습니다.";
                    popupMessage.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                SetLog(ex.Message, 4);
            }
        }

        #endregion

        public static void Init()
        {
            //Common Init
            Name = string.Empty;
            PersonalNO = string.Empty;
            SurgeryKind = string.Empty;
            MobileNO = string.Empty;
            Address = string.Empty;
            input = string.Empty;
            Rules = "0";
            Ptntinfo = "0";
            Eventarl = "0";
        }

        public class Road_Address
        {
            public string ZipCode { get; set; }
            public string RoadAddress { get; set; }
        }

        public class JsonAddress
        {
            public Road_Address road_address { get; set; }
            public List<Road_Address> _Address_List { get; set; }
        }

        public static void PageMove(string form, string PreviewForm, string chk)
        {
            try
            {
                Form fc = null;
                //foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
                //{
                //    if (t.Name == form)
                //    {
                //        object o = Activator.CreateInstance(t);
                //        fc = o as Form;
                //    }
                //}

                switch (form)
                {
                    case "Main":
                        fc = Common.Main;
                        Main.Init();
                        break;
                    case "Sub_NewPtnt":
                        fc = Common.Sub_NewPtnt;
                        sub_NewPtnt.initText();
                        Common.SetKbShift();
                        break;
                    case "InputMobileNo":
                        fc = Common.InputMobileNo;
                        InputMobileNo.initText();
                        break;
                    case "InputMobileNo_Add":
                        fc = Common.InputMobileNo_Add;
                        InputMobileNo_Add.initText();
                        break;
                    case "InputPersonalNO":
                        fc = Common.InputPersonalNO;
                        InputPersonalNO.initText();
                        break;
                    case "InputAddress":
                        fc = Common.InputAddress;
                        InputAddress.initText();
                        Common.SetKbShift();
                        break;
                    case "SurgeryKind":
                        fc = Common.SurgeryKindForm;
                        SurgeryKindForm.init();
                        break;
                    case "ReceiptInfo":
                        fc = Common.ReceiptInfo;
                        ReceiptInfo.initText();
                        ReceiptInfo.SetData();
                        break;
                    default:
                        break;
                }
                Form preform1 = Application.OpenForms[PreviewForm]; //현재 작업중인 폼
                if (fc != null) //호출해야 할 폼이 생성되어 있는지 확인
                {
                    //Common.SetLog(fc.Name + " 폼 생성", 2);
                    //fc.Opacity = 1;
                    //fc.ShowInTaskbar = true;
                    //fc.Visible = true; //호출해야 할 폼을 표출한다
                    //Form preform1 = Application.OpenForms[PreviewForm]; //현재 작업중인 폼                    
                    fc.Show();
                    fc.WindowState = FormWindowState.Maximized;

                    if (preform1 != null)
                    {
                        //preform1.Opacity = 0;
                        //preform1.ShowInTaskbar = false;
                        //preform1.Visible = false; //현재 작업중인 폼을 감춘다
                        preform1.Hide();
                        // 다른 모든 폼을 닫습니다.
                        //for (int i = 0; i < Application.OpenForms.Count; i++)
                        //{
                        //    if (Application.OpenForms[i] != fc)
                        //    {
                        //        Application.OpenForms[i].Hide();
                        //    }
                        //}
                    }
                    else
                    {
                        // 다른 모든 폼을 닫습니다.
                        for (int i = 0; i < Application.OpenForms.Count; i++)
                        {
                            if (Application.OpenForms[i] != fc)
                            {
                                Application.OpenForms[i].Hide();
                            }
                        }
                    }
                }
                else
                {
                    #region 사용안함
                    /*
                    switch (form) //폼 생성
                    {
                        case "InputAddress":
                            fc = new InputAddress();
                            break;
                        case "inputAddress":
                            fc = new InputAddress();
                            break;
                        case "InputMobileNo":
                            fc = new InputMobileNo();
                            break;
                        case "InputPersonalNO":
                            fc = new InputPersonalNO();
                            break;
                        case "Main":
                            fc = new Main();
                            break;
                        case "Sub_NewPtnt":
                            fc = new Sub_NewPtnt();
                            break;
                        case "SurgeryKind":
                            fc = new SurgeryKind();
                            break;
                        case "PopupAddressApi":
                            fc = new PopupAddressApi();
                            break;
                        case "ReceiptInfo":
                            fc = new ReceiptInfo();
                            break;
                        case "LogIn":
                            fc = new LogIn();
                            break;
                        case "InputMobileNo_Add":
                            fc = new InputMobileNo_Add();
                            break;
                    }
                    */
                    #endregion
                    fc.StartPosition = FormStartPosition.CenterScreen;
                    if (preform1 != null)
                    {
                        //preform1.Opacity = 0;
                        //preform1.ShowInTaskbar = false;
                        preform1.Hide();
                        //preform1.Visible = false; //현재 작업중인 폼을 감춘다
                    }
                    //fc.ShowDialog();
                    //fc.Opacity = 1;
                    //fc.ShowInTaskbar = true;
                    //fc.Visible = true; //호출해야 할 폼을 표출한다
                    fc.Show();
                    //Form preform1 =                     
                    fc.WindowState = FormWindowState.Maximized;
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Page Move Error " + ex.Message);
                ErrorPopupMessage popupMessage = new ErrorPopupMessage();
                popupMessage.result = ex.Message;
                popupMessage.ShowDialog();
                SetLog(ex.Message, 3);
            }
        }

        internal static void PageMove2(string form, string PreviewForm, string chk)
        {
            try
            {
                Form fc = null;
                switch (form)
                {
                    case "Main":
                        fc = Common.Main;
                        Main.Init();
                        break;
                    case "Sub_NewPtnt":
                        fc = Common.Sub_NewPtnt;
                        sub_NewPtnt.initText();
                        break;
                    case "InputMobileNo":
                        fc = Common.InputMobileNo;
                        InputMobileNo.initText();
                        break;
                    case "InputMobileNo_Add":
                        fc = Common.InputMobileNo_Add;
                        InputMobileNo_Add.initText();
                        break;
                    case "InputPersonalNO":
                        fc = Common.InputPersonalNO;
                        InputPersonalNO.initText();
                        break;
                    case "InputAddress":
                        fc = Common.InputAddress;
                        InputAddress.initText();
                        SetKbShift();
                        break;
                    case "SurgeryKind2":
                        fc = Common.SurgeryKindForm;
                        SurgeryKindForm.init();
                        break;
                    case "ReceiptInfo":
                        fc = Common.ReceiptInfo;
                        ReceiptInfo.initText();
                        ReceiptInfo.SetData();
                        break;
                    default:
                        break;
                }

                fc.Show();
                fc.WindowState = FormWindowState.Maximized;

                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    if (Application.OpenForms[i] != fc)
                    {
                        Application.OpenForms[i].Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Page Move Error " + ex.Message);
                ErrorPopupMessage popupMessage = new ErrorPopupMessage();
                popupMessage.result = ex.Message;
                popupMessage.ShowDialog();
                SetLog(ex.Message, 3);
            }
        }

        public static Form FindFormByString(string targetString)
        {
            // 모든 열린 폼을 가져옵니다.
            FormCollection openForms = Application.OpenForms;

            foreach (Form form in openForms)
            {
                // 각 폼에서 스트링값과 비교합니다.
                if (form.Text == targetString)
                {
                    return form; // 일치하는 폼을 반환합니다.
                }
            }

            return null; // 일치하는 폼을 찾지 못한 경우 null을 반환합니다.
        }

        internal static void SetLog(string message, int Lv)
        {
            if (Lv == 0)
            {
                log.Debug("Debug " + message);
            }
            else if (Lv == 1)
            {
                log.Info("Info " + message);
            }
            else if (Lv == 2)
            {
                log.Warn("Warn " + message);
            }
            else if (Lv == 3)
            {
                log.Error("Error " + message);
            }
            else if (Lv == 4)
            {
                log.Fatal("Fatal " + message);
            }
        }

        internal static void RoundButtonCorners(Button button, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90); // 왼쪽 위 모서리
            path.AddArc(button.Width - radius, 0, radius, radius, 270, 90); // 오른쪽 위 모서리
            path.AddArc(button.Width - radius, button.Height - radius, radius, radius, 0, 90); // 오른쪽 아래 모서리
            path.AddArc(0, button.Height - radius, radius, radius, 90, 90); // 왼쪽 아래 모서리
            path.CloseFigure();

            button.Region = new Region(path);
        }

        internal static bool send_SMS(bool v, string mobileNo, string pat_no, string vist_sn, string yKIHO)
        {
            try
            {
                bool ret = v;

                List<SendPatientModel> sendPatientList = new List<SendPatientModel>();
                SendPatientModel sendPatient = new SendPatientModel();

                sendPatient.MobileNo = mobileNo;
                sendPatient.PatName = Common.USER_NM;
                sendPatient.PatNo = Common.Pat_No;
                sendPatient.VisitSn = VIST_SN;
                sendPatient.ReserveDate = DateTime.Now.ToString("yyyyMMdd");
                sendPatient.ReserveTime = DateTime.Now.ToString("HHmm");

                sendPatientList.Add(sendPatient);
                Common commonSms = new CommonSms();

                string retMsg = commonSms.SendMsg(ret, sendPatientList);

                ret = retMsg == "1" ? true : false;
                return ret;
            }
            catch
            {
                return false;
            }
        }

        private string SendMsg(bool kinds_, List<SendPatientModel> sendPatientList)
        {
            int ret = 0;
            string Plan_CD = string.Empty;
            if (kinds_)
            {
                Plan_CD = "Accept";
            }

            CreatorSmsFactory creator = new CreatorSmsFactory();
            SendSms sendMsg = creator.CreateInstance(Plan_CD, sendPatientList); //작업중

            if (sendMsg != null)
                ret = sendMsg.Send();

            if (ret == 0)
                return "1";
            else
                return "-1";
        }

        internal static bool ConnectSerialPort()
        {
            bool chk = false;
            //serialPort 설정
            StringBuilder Port = new StringBuilder();
            GetPrivateProfileString("SerialPort", "PortName", "", Port, 64, Application.StartupPath + @"\SerialPort.ini");
            //SerialPort List 가져오기
            string portname = string.Empty;

            portname = Port.ToString();
            if (portname != "")
            {
                if (!serialPort.IsOpen)
                {
                    if (serialPort.PortName == portname)
                    {
                        serialPort.PortName = portname;
                        serialPort.BaudRate = 9600;
                        serialPort.DataBits = 8;
                        serialPort.StopBits = StopBits.One;
                        serialPort.Parity = Parity.None;
                        serialPort.Open();
                        if (serialPort.IsOpen)
                        {
                            chk = true;
                        }
                    }
                }
            }
            return chk;
        }

        internal static void PreLoading()
        {
            //Main
            //Main main = new Main();
            //main.Hide();
            //Common.forms.Add(main);
            ////이름입력
            //Sub_NewPtnt sub_NewPtnt = new Sub_NewPtnt();
            //sub_NewPtnt.Hide();
            //Common.forms.Add(sub_NewPtnt);
            ////핸드폰번호 입력
            //InputMobileNo inputMobileNo = new InputMobileNo();
            //inputMobileNo.Hide();
            //Common.forms.Add(inputMobileNo);
            //InputMobileNo_Add inputMobileNo_Add = new InputMobileNo_Add();
            //inputMobileNo_Add.Hide();
            //Common.forms.Add(inputMobileNo_Add);
            ////주민등록번호 입력
            //InputPersonalNO inputPersonalNO = new InputPersonalNO();
            //inputPersonalNO.Hide();
            //Common.forms.Add(inputPersonalNO);
            ////주소 입력
            //InputAddress inputAddress = new InputAddress();
            //inputAddress.Hide();
            //Common.forms.Add(inputAddress);
            ////시술 구분 입력
            //SurgeryKind surgeryKind = new SurgeryKind();
            //surgeryKind.Hide();
            //Common.forms.Add(surgeryKind);
            ////접수내역
            //ReceiptInfo receipt = new ReceiptInfo();
            //receipt.Hide();
            //Common.forms.Add(receipt);
        }

        public static int SetKbShift()
        {
            var test = (GetKeyState((int)Keys.CapsLock) & 0xffff);
            if (test != 0)
            {
                keybd_event((byte)Keys.CapsLock, (byte)0, 0, 0);
                keybd_event((byte)Keys.CapsLock, (byte)0, 2, 0);
            }

            var test2 = (GetKeyState((int)Keys.ShiftKey) & 0xffff);

            if (test2 != 0)
            {
                keybd_event((byte)Keys.ShiftKey, (byte)0, 0, 0);
                keybd_event((byte)Keys.ShiftKey, (byte)0, 2, 0);
            }
            //ChangeIME(true);
            /*            if (form.isHANGULMode == false) // "한/영 전환"
                        {
                            form.isHANGULMode = true;
                            Image image = Properties.Resources.key_특10;
                            form.radButton53.Image = image;
                            form.ChangeIME(true);
                        }*/

            return test;
        }
    }
}