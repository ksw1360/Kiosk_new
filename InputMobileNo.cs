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
    public partial class InputMobileNo : Form
    {
        #region ini 입력 메소드
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion

        int hypen = 0;
        public System.Windows.Forms.Timer timer;

        public InputMobileNo()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            textBox1.AutoSize = false;
            textBox1.Height += 10;
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

        private void InputMobileNo_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            this.Size = new Size(1080, 1920);

            this.btnPreview.Visible = false;
            this.btnNext.Visible = false;

            this.btnPreview2.Visible = true;
            this.btnNext2.Visible = true;

            this.btnPreview2.Enabled = true;
            this.btnNext2.Enabled = false;

            this.btnPreview2.BackgroundImage = Properties.Resources.이전2;
            //this.panel6.Location = new Point(0, 1450);

            this.lbFirst.TextAlign = ContentAlignment.MiddleCenter;

            this.lbSecond.AutoSize = false;
            this.lbSecond.TextAlign = ContentAlignment.MiddleCenter;
            this.lbSecond.Dock = DockStyle.Fill;

            textBox1.MaxLength = 13;

            textBox1.Text = "";

            //serialPort 설정
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
                //textBox1.Text = serialPort.ReadExisting();
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

        private void textBox1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = string.Empty;
        }

        private void NumberKeyboard1_DataRequest(object sender, EventArgs e)
        {
            textBox1.Text = sender.ToString();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            Common.PageMove("Sub_NewPtnt", this.Name, "1");
            Sub_NewPtnt.sub_NewPtnt.initText();
        }

        /// <summary>
        /// 다음버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            Common.MobileNO = this.textBox1.Text;

            if (textBox1.Text.Length < 13)
            {
                //MessageBox.Show("핸드폰 번호를 확인바랍니다.");
                ErrorPopupMessage popupMessage = new ErrorPopupMessage();
                popupMessage.result = "핸드폰 번호를 확인바랍니다.";
                popupMessage.ShowDialog();
                return;
            }

            //this.Hide();
            //if (textBox1.Text.Length < 13)
            //{
            //    //MessageBox.Show("핸드폰 번호를 확인바랍니다.");
            //    ErrorPopupMessage popupMessage = new ErrorPopupMessage();
            //    popupMessage.result = "핸드폰 번호를 확인바랍니다.";
            //    popupMessage.ShowDialog();
            //    return;
            //}

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" SELECT COUNT(*) AS CNT ");
            sb.AppendLine($" FROM PTNT_INFO ");
            sb.AppendLine($" WHERE MOBILE_NO  like '%{textBox1.Text}%'");
            sb.AppendLine($"   AND YKIHO = '{Common.YKIHO}'");
            sb.AppendLine($"   AND PAT_NM LIKE '%{Common.Name}%'");
            DataTable Ptnt_Dt = DBCommon.SelectData(sb.ToString());

            int rows = Convert.ToInt32(Ptnt_Dt.Rows[0]["CNT"].ToString());

            if (rows > 0)
            {
                //접수하기
                //구환
                //전화번호로 검색된 구환
                Receipt.ReceiptContract(Common.Name, Common.PersonalNO, Common.SurgeryKind, Common.MobileNO, Common.Address, "", "0", "0", "0");
                textBox1.Text = string.Empty;
            }
            else
            {
                //Common.PageMove("InputPersonalNO", this.Name, "1");
                Common.PageMove("ReceiptInfo", this.Name, "1");
                textBox1.Text = string.Empty;
            }
        }

        private void numberKeyboard1_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = string.Empty;
            //numberKeyboard1.Visible = true;
            //numberKeyboard1.DataRequest2 += NumberKeyboard1_DataRequest;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
                    if (textBox1.Text.Length >= 13)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button2":                  //2
                    //textBox1.Text += button.Text;
                    message += button.Text;
                    if (textBox1.Text.Length >= 13)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button3":                  //3
                    //textBox1.Text += button.Text;
                    message += button.Text;
                    if (textBox1.Text.Length >= 13)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button6":                  //4
                    //textBox1.Text += button.Text;
                    message += button.Text;
                    if (textBox1.Text.Length >= 13)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button5":                  //5
                    //textBox1.Text += button.Text;
                    message += button.Text;
                    if (textBox1.Text.Length >= 13)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button4":                  //6
                    //textBox1.Text += button.Text;
                    message += button.Text;
                    if (textBox1.Text.Length >= 13)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button9":                  //7
                    //textBox1.Text += button.Text;
                    message += button.Text;
                    if (textBox1.Text.Length >= 13)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button8":                  //8
                    //textBox1.Text += button.Text;
                    message += button.Text;
                    if (textBox1.Text.Length >= 13)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button7":                  //9
                    //textBox1.Text += button.Text;
                    message += button.Text;
                    if (textBox1.Text.Length >= 13)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button11":                  //10
                    //textBox1.Text += button.Text;
                    message += button.Text;
                    if (textBox1.Text.Length >= 13)
                    {
                        return;
                    }
                    textBox1.Text += message;
                    break;
                case "button12":
                    if (textBox1.Text.Length > 0)
                    {

                        string test = this.textBox1.Text.Replace("-", "").ToString();

                        if (test.Length > 0)
                        {
                            this.textBox1.Text = test.Substring(0, test.Length - 1);
                            return;
                        }

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
                        if (textBox1.Text.Length >= 13)
                        {
                            //return;
                        }
                        textBox1.Text = Temp;
                        // = message;
                    }
                    break;
                case "button10":
                    hypen = 0;
                    //message = button.Text + "-";
                    message = button.Text;
                    textBox1.Text = message;
                    break;
            }
            if (button.Name == "button10")
            {
                textBox1.Text = message;
            }
            else if (button.Name == "button12")
            {

            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 13)
                {
                    return;
                }

                bool chk = Regex.IsMatch(this.textBox1.Text, @"[ㄱㅎ가힣]");

                if (chk)
                {
                    this.btnNext.BackgroundImage = Properties.Resources.다음1;
                }

                /*
                if (textBox1.Text.Length > 0 && textBox1.Text.Length < 13)
                {
                    int no = this.textBox1.Text.IndexOf('-');
                    if(no > 0)
                    {

                    }
                }
                */

                if (true)
                {
                    string test = textBox1.Text.Replace("-", "").ToString();

                    if (test.Length > 3 && test.Length < 8)
                    {
                        test = test.Insert(3, "-");
                    }
                    else if (test.Length >= 8)
                    {
                        test = test.Insert(3, "-");

                        test = test.Insert(8, "-");

                    }
                    textBox1.TextChanged -= textBox1_TextChanged_1;
                    textBox1.Text = test;
                    if (textBox1.Text.Length == 13)
                    {
                        btnNext2.Enabled = true;
                        btnNext2.BackgroundImage = Properties.Resources.다음2;
                    }
                    else
                    {
                        btnNext2.Enabled = false;
                        btnNext2.BackgroundImage = Properties.Resources.다음1;
                    }
                    textBox1.TextChanged += textBox1_TextChanged_1;
                    return;

                    #region 사용안함
                    /*if (textBox1.Text.Length == 3 || textBox1.Text.Length == 8)
                    {
                        if (textBox1.Text.EndsWith("-") == false)
                        {
                            textBox1.TextChanged -= textBox1_TextChanged_1;
                            textBox1.Text += "-";
                            textBox1.TextChanged += textBox1_TextChanged_1;
                            textBox1.SelectionStart = textBox1.Text.Length;
                        }
                    }
                    else
                    if (textBox1.Text.StartsWith("011") || textBox1.Text.StartsWith("010") ||
                       textBox1.Text.StartsWith("016") || textBox1.Text.StartsWith("017") ||
                       textBox1.Text.StartsWith("018") || textBox1.Text.StartsWith("019"))
                    {
                        if (textBox1.Text.Length == 4 || textBox1.Text.Length == 8)
                        {
                            textBox1.Text = textBox1.Text.Insert(textBox1.Text.Length - 1, "-");
                        }
                        else if (textBox1.Text.Length == 13)
                        {
                            textBox1.Text = Regex.Replace(textBox1.Text.Replace("-", string.Empty), @"(\d{3})(\d{4})(\d{4})", "$1-$2-$3");
                        }
                        else if (textBox1.Text.Length == 12)
                        {
                            textBox1.Text = Regex.Replace(textBox1.Text.Replace("-", string.Empty), @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");
                        }
                    }
                    else
                    {
                        if (textBox1.Text.Length == 4)
                        {
                            textBox1.Text = textBox1.Text.Insert(textBox1.Text.Length - 1, "-");
                        }
                        else if (textBox1.Text.Length == 9)
                        {
                            textBox1.Text = Regex.Replace(textBox1.Text.Replace("-", string.Empty), @"(\d{4})(\d{4})", "$1-$2");
                        }
                        else if (textBox1.Text.Length == 8)
                        {
                            textBox1.Text = Regex.Replace(textBox1.Text.Replace("-", string.Empty), @"(\d{3})(\d{4})", "$1-$2");
                        }
                    }
                    textBox1.SelectionStart = textBox1.Text.Length;*/
                    #endregion

                }

                /*
                else
                {
                    if (textBox1.Text.EndsWith("-"))
                    {
                        textBox1.Text = textBox1.Text.TrimEnd('-');
                    }
                }
                

                if (textBox1.Text.Length == 13)
                {
                    this.btnNext2.Enabled = true;
                    btnNext2.BackgroundImage = Properties.Resources.다음2;
                }
                else
                {
                    this.btnNext2.Enabled = false;
                    btnNext2.BackgroundImage = Properties.Resources.다음1;
                }
                */
            }
            catch (Exception ex)
            {
                Common.SetLog(ex.Message, 3);
            }
        }

        internal void initText()
        {
            this.textBox1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            bool chk = Regex.IsMatch(this.textBox1.Text, @"[ㄱㅎ가힣]");

            if (chk)
            {
                textBox1.Text = string.Empty;
            }

            if (textBox1.Text.Length < 13)
            {
                MessageBox.Show("핸드폰 번호를 확인바랍니다.");
                return;
            }
            */
        }

        private void btnPreview_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnPreview2.BackgroundImage = Properties.Resources.이전2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Common.Init();
            Common.PageMove("Main", this.Name, "1");
        }

        private void btnPreview2_MouseLeave(object sender, EventArgs e)
        {
            this.btnPreview2.BackgroundImage = Properties.Resources.이전1;
        }
    }
}