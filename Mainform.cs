using Kiosk.Class;
using Kiosk.Popup;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class Main : Form
    {
        #region ini 입력 메소드
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion

        //SerialPort serialPort = new SerialPort();

        public static Main form1;
        public static int check = 0;

        public Main()
        {
            InitializeComponent();
            form1 = this;
            this.CenterToScreen();
            //this.Size = new Size(420, 570);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
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

        private void Main_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1080, 1920);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point(0, 0);
            this.FormBorderStyle = FormBorderStyle.None;

            this.lbSecond.Text = "안녕하세요";
            this.lbSecond.AutoSize = false;
            this.lbSecond.TextAlign = ContentAlignment.MiddleCenter;
            this.lbSecond.Dock = DockStyle.Fill;
            //this.lbSecond.Font = new Font("Arial", 30, FontStyle.Regular);

            //this.lbFirst.Text = "내원 여부 선택";
            //this.lbFirst.Font = new Font("Arial", 40, FontStyle.Bold);
            //this.lbFirst.AutoSize = false;
            //this.lbFirst.TextAlign = ContentAlignment.MiddleCenter;
            //this.lbFirst.Dock = DockStyle.Fill;

            //모든폼 미리 생성해놓기
            this.BringToFront();
            this.TopMost = true;
            //이름입력
            //Sub_NewPtnt sub_NewPtnt = new Sub_NewPtnt();
            //sub_NewPtnt.Hide();

            //serialPort 설정
            if (Common.ConnectSerialPort())
            {
                Common.serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            }

            //미입력시 메인화면으로 복귀 타이머 시작
            //Common.StartTimer(form1);

            Init();

            lbFirst.Focus();
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
                ErrorPopupMessage popupMessage = new ErrorPopupMessage();
                popupMessage.result = ex.Message;
                popupMessage.ShowDialog();
                //MessageBox.Show(ex.Message);
            }
        }

        private void MySerialReceived(object sender, EventArgs e)
        {
            try
            {
                //textBox1.Text = serialPort.ReadExisting();
                if (Common.serialPort.IsOpen)
                {
                    string Data = Common.serialPort.ReadExisting();

                    if (Data != null)
                    {
                        Common.ReadingQRcode(Data, this.Name);
                    }
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

        private void btnNewPtnt_Click(object sender, EventArgs e)
        {
            Common.check = 1;
            Common.PageMove("Sub_NewPtnt", this.Name, "1");
            Sub_NewPtnt.sub_NewPtnt.chgTxt();
            Sub_NewPtnt.sub_NewPtnt.initText();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Common.serialPort.Close();
            Common.serialPort.Dispose();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            //Common.PageMove("Sub_NewPtnt", this.Name, "1");
            Common.PageMove("LogIn", this.Name, "1");
        }

        private void btnPrePtnt_Click(object sender, EventArgs e)
        {
            Common.check = 2;
            Common.PageMove("Sub_NewPtnt", this.Name, "1");
            Sub_NewPtnt.sub_NewPtnt.chgTxt();
            Sub_NewPtnt.sub_NewPtnt.initText();
        }

        private void btnPreview_Click_1(object sender, EventArgs e)
        {
            Application.DoEvents();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Common.SetLog("Program End", 1);
            //MessageBox.Show(ex.Message);
            Application.DoEvents();
            this.Close();
            Application.Exit();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Normal;
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Visible = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnPreview_MouseMove(object sender, MouseEventArgs e)
        {
            this.btnPreview.BackgroundImage = Properties.Resources.이전2;
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            ErrorPopupMessage popupMessage = new ErrorPopupMessage();
            popupMessage.result = "사용자 정보가 2건 이상 조회되었습니다. 관리자에게 문의하세요";
            popupMessage.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Common.SetLog("Program End", 1);
            //MessageBox.Show(ex.Message);
            Application.DoEvents();
            this.Close();
            Application.Exit();
        }

        internal void Init()
        {
            if (this.btnNewPtnt.Focusable)
            {
                this.btnNewPtnt.ButtonElement.FocusBorderColor = Color.White;
                this.btnNewPtnt.ButtonElement.ShowBorder = false;

                this.btnPrePtnt.ButtonElement.FocusBorderColor = Color.White;
                this.btnPrePtnt.ButtonElement.ShowBorder = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}