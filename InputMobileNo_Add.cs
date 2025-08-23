using Kiosk.Class;
using Kiosk.Popup;
using System;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class InputMobileNo_Add : Form
    {
        #region ini 입력 메소드
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion

        //SerialPort serialPort = new SerialPort();

        #region imm32.dll :: Get_IME_Mode IME가져오기
        [DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hWnd);
        [DllImport("imm32.dll")]
        public static extern Boolean ImmSetConversionStatus(IntPtr hIMC, Int32 fdwConversion, Int32 fdwSentence);
        [DllImport("imm32.dll")]
        private static extern IntPtr ImmGetDefaultIMEWnd(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr IParam);

        public const int IME_CMODE_ALPHANUMERIC = 0x0;   //영문
        public const int IME_CMODE_NATIVE = 0x1;         //한글
        #endregion

        private int hypen;
        public System.Windows.Forms.Timer timer;

        public InputMobileNo_Add()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            //textBox1.AutoSize = false;
            //textBox1.Height += 10;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public void initText()
        {
            this.textBox1.Text = "";
            //ChangeIME(true);
        }

        private void InputMobileNo_Add_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(1080, 1920);
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;

            this.textBox1.Text = lbFirst.Text;

            this.btnPreview.Visible = false;
            this.btnNext.Visible = false;

            this.btnPreview2.Visible = true;
            this.btnNext2.Visible = true;

            this.btnPreview2.Enabled = true;
            this.btnNext2.Enabled = false;

            this.btnPreview2.BackgroundImage = Properties.Resources.이전2;

            this.panel6.Location = new Point(0, 1450);

            this.lbFirst.AutoSize = false;
            this.lbFirst.TextAlign = ContentAlignment.MiddleCenter;
            this.lbFirst.Dock = DockStyle.Fill;

            textBox1.MaxLength = 13;

            textBox1.Text = "";

            if (Common.ConnectSerialPort())
            {
                Common.serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                this.Invoke(new EventHandler(MySerialReceived));
            }
            catch (Exception ex)
            {
                Common.SetLog(ex.Message, 4);
                //MessageBox.Show(ex.Message);
                ErrorPopupMessage popupMessage = new ErrorPopupMessage();
                popupMessage.result = ex.Message;
                popupMessage.ShowDialog();
            }
        }

        private void MySerialReceived(object sender, EventArgs e)
        {
            try
            {
                string Data = Common.serialPort.ReadExisting();

                if (Data != "")
                {
                    Common.ReadingQRcode(Data.Substring(0, 25), this.Name);
                }
            }
            catch (Exception ex)
            {
                Common.SetLog(ex.Message, 4);
                //MessageBox.Show(ex.Message);
                ErrorPopupMessage popupMessage = new ErrorPopupMessage();
                popupMessage.result = ex.Message;
                popupMessage.ShowDialog();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            bool chk = Regex.IsMatch(this.textBox1.Text, @"[ㄱ-ㅎ가-힣]");

            if (chk)
            {
                textBox1.Text = string.Empty;
            }

            Button button = (Button)sender;
            switch (button.Name)
            {
                case "button13":                  //1
                    //textBox1.Text += button.Text;
                    message += button.Text;
                    if (textBox1.Text.Length >= 14)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button2":                  //2
                    //textBox1.Text += button.Text;
                    message += button.Text;
                    if (textBox1.Text.Length >= 14)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button3":                  //3
                    //textBox1.Text += button.Text;
                    message += button.Text;
                    if (textBox1.Text.Length >= 14)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button6":                  //4
                    //textBox1.Text += button.Text;
                    message += button.Text;
                    if (textBox1.Text.Length >= 14)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button5":                  //5
                    //textBox1.Text += button.Text;
                    message += button.Text;
                    if (textBox1.Text.Length >= 14)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button4":                  //6
                    //textBox1.Text += button.Text;
                    message += button.Text;
                    if (textBox1.Text.Length >= 14)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button9":                  //7
                    //textBox1.Text += button.Text;
                    message += button.Text;
                    if (textBox1.Text.Length >= 14)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button8":                  //8
                    //textBox1.Text += button.Text;
                    message += button.Text;
                    if (textBox1.Text.Length >= 14)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button7":                  //9
                    //textBox1.Text += button.Text;
                    message += button.Text;
                    if (textBox1.Text.Length >= 14)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button11":                  //10
                    //textBox1.Text += button.Text;
                    message += button.Text;
                    if (textBox1.Text.Length >= 14)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button12":
                    if (textBox1.Text.Length > 0)
                    {
                        hypen = 1;
                        string Temp = string.Empty;
                        bool chk2 = false;
                        int startIndex = textBox1.Text.Length - 1;
                        if (textBox1.Text.Substring(textBox1.Text.Length - 1, 1) == "-")
                        {
                            chk2 = false;
                        }
                        else
                        {
                            chk2 = true;
                        }
                        //bool chk2 = Regex.IsMatch(this.textBox1.Text, @"[ㄱ-ㅎ가-힣]");
                        if (chk2)
                        {
                            Temp = textBox1.Text.Remove(startIndex);
                        }
                        else
                        {
                            Temp = textBox1.Text.TrimEnd('-');
                            //RemoveSpecialCharacter(textBox1.Text, startIndex);
                        }
                        if (textBox1.Text.Length >= 14)
                        {
                            return;
                        }
                        textBox1.Text = Temp;
                        hypen = 0;
                        // = message;
                    }
                    break;
                case "button10":
                    hypen = 0;
                    message = button.Text + "-";
                    textBox1.Text = message;
                    break;
            }
            if (button.Name == "button10")
            {
                textBox1.Text = "";
            }
            else if (button.Name == "button12")
            {

            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Common.PageMove("Sub_NewPtnt", this.Name, "1");
            Sub_NewPtnt.sub_NewPtnt.initText();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Common.PersonalNO = "";
            Common.MobileNO = "";

            string personalNO = string.Empty;
            string mobileNO = string.Empty;

            if (textBox1.Text.Contains("-"))
            {
                if (textBox1.Text.Length != 13)
                {
                    //MessageBox.Show("핸드폰 번호를 확인바랍니다.");
                    ErrorPopupMessage popupMessage = new ErrorPopupMessage();
                    popupMessage.result = "핸드폰 번호를 확인바랍니다.";
                    popupMessage.ShowDialog();
                    return;
                }

                mobileNO = textBox1.Text.ToString();
            }
            else
            {
                if (textBox1.Text.Length != 6)
                {
                    ErrorPopupMessage popupMessage = new ErrorPopupMessage();
                    popupMessage.result = "생년월일 6자리를 입력해주세요.";
                    popupMessage.ShowDialog();
                    return;
                }

                personalNO = textBox1.Text.ToString();
            }


            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" SELECT PAT_NO , PAT_NM , PAT_BTH , MOBILE_NO ");
            sb.AppendLine($" FROM PTNT_INFO ");
            sb.AppendLine($" WHERE PAT_NM LIKE '%{Common.Name}%'");

            if (!string.IsNullOrEmpty(mobileNO))
            {
                sb.AppendLine($" AND REPLACE(MOBILE_NO,'-','')  like '%{mobileNO.Replace("-", "")}%'");
            }
            else
            {
                sb.AppendLine($" AND SUBSTR(PAT_JNO2,1,6) = '{personalNO}'");
            }

            //if (textBox1.Text.Length == 6)
            //{
            //    sb.AppendLine($" AND SUBSTR(PAT_JNO2,1,6) = '{textBox1.Text}'");
            //    Common.PersonalNO = textBox1.Text;
            //}
            //else if (textBox1.Text.Length == 4 || textBox1.Text.Length >= 13)
            //{
            //    sb.AppendLine($" AND MOBILE_NO  like '%{textBox1.Text}%'");
            //    Common.MobileNO = textBox1.Text;
            //}

            DataTable Ptnt_Dt = DBCommon.SelectData(sb.ToString());
            if (Ptnt_Dt.Rows.Count > 0)
            {
                //Receipt.ReceiptContract(Common.Name, Common.PersonalNO, "", Common.MobileNO, "", "", "", "", "");
                Receipt.ReceiptContract(Common.Name, personalNO, "", mobileNO, "", "", "", "", "");
                textBox1.Text = string.Empty;
            }
            else
            {
                PopupMessageQuestion popupMessage = new PopupMessageQuestion();
                popupMessage.panel4.BackColor = Color.White;
                popupMessage.Names = "";
                popupMessage.messages = "고객정보가 존재하지 않습니다.";
                popupMessage.result = "신규접수 하시겠습니까?";
                DialogResult dr = popupMessage.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Common.check = 1;
                    Common.PageMove("Sub_NewPtnt", this.Name, "1"); //고객 정보가 없을시 이름넣는곳으로 전환
                    textBox1.Text = string.Empty;
                    Sub_NewPtnt.sub_NewPtnt.textBox1.Text = Common.Name;

                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("010"))
            {
                if (textBox1.Text.Length > 13)
                {
                    return;
                }
            }
            else
            {
                if (textBox1.Text.Length > 14)
                {
                    return;
                }
            }
            /*
            else if (textBox1.Text.Length == 0)
            {
                textBox1.Text = "휴대폰 번호를 입력해 주세요.";
            }
            */
            bool chk = Regex.IsMatch(this.textBox1.Text, @"[ㄱ-ㅎ가-힣]");

            if (chk)
            {
                textBox1.Text = string.Empty;
            }

            if (hypen == 0)
            {
                if (textBox1.Text.Length > 2)
                {
                    if (textBox1.Text.Contains("010"))
                    {
                        if (textBox1.Text.Length == 3 || textBox1.Text.Length == 8)
                        {
                            textBox1.Text += "-";
                            textBox1.SelectionStart = textBox1.Text.Length;
                        }
                    }
                }
            }
            else
            {
                if (textBox1.Text.EndsWith("-"))
                {
                    //Temp = textBox1.Text.TrimEnd('-');
                    textBox1.Text = textBox1.Text.TrimEnd('-');
                    //RemoveSpecialCharacter(textBox1.Text, textBox1.Text.Length - 1);
                }
            }

            try
            {
                if (textBox1.Text.Length > 0)
                {
                    this.btnNext2.Enabled = true;
                    btnNext2.BackgroundImage = Properties.Resources.다음2;
                }
                else
                {
                    //
                    this.btnNext2.Enabled = false;
                    btnNext2.BackgroundImage = Properties.Resources.다음1;
                }
            }
            catch (Exception ex)
            {
                Common.SetLog(ex.Message, 3);
            }
        }

        private void btnPreview_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnPreview.BackgroundImage = Properties.Resources.이전2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Common.Init();
            Common.PageMove("Main", this.Name, "1");
        }

        #region User_Fn
        /// <summary>
        /// [한/영]전환 true=한글, false=영어
        /// </summary>
        /// <param name="b_toggle"></param>
        private void ChangeIME(bool b_toggle)
        {
            IntPtr hwnd = ImmGetContext(this.Handle);  //C# WindowForm만 적용됨.
            // [한/영]전환 b_toggle : true=한글, false=영어
            Int32 dwConversion = (b_toggle == true ? IME_CMODE_NATIVE : IME_CMODE_ALPHANUMERIC);
            ImmSetConversionStatus(hwnd, dwConversion, 0);
        }
        #endregion

        private void btnPreview2_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnPreview2.BackgroundImage = Properties.Resources.이전2;
        }

        private void btnPreview2_MouseLeave(object sender, EventArgs e)
        {
            this.btnPreview2.BackgroundImage = Properties.Resources.이전1;
        }
    }
}