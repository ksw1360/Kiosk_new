using Kiosk.Class;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kiosk.Popup
{
    public partial class PopupMessage : Form
    {
        internal int mode;
        int cnt = 0;

        public PopupMessage()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.timer1.Enabled = true;
        }

        public string Names { get; internal set; }
        public string message { get; internal set; }
        public string result { get; internal set; }

        private void PopupMessage_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;

            this.lbFirst.Text = Names;
            this.lbSecond.Text = message;
            this.lbThird.Text = result;

            this.lbThird.AutoSize = false;
            this.lbThird.Font = new Font("Noto Sans KR Regular", 24, FontStyle.Regular);
            this.lbThird.TextAlign = ContentAlignment.MiddleCenter;
            this.lbThird.Dock = DockStyle.Fill;

            this.TopMost = true;

            if(string.IsNullOrEmpty(lbFirst.Text) == true)
            {
                this.panel5.Visible = false;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.timer1.Enabled = false;
                //Common Init
                Common.Init();

                this.Close();
                Common.PageMove("Main", "ReceiptInfo", "1");

                /*
                Form specificForm = Application.OpenForms.OfType<Main>().FirstOrDefault();

                if (specificForm != null)
                {
                    //specificForm.Show();
                    specificForm.Visible = true;
                }

                // 다른 모든 폼을 닫습니다.
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    if (Application.OpenForms[i] != specificForm)
                    {
                        //Application.OpenForms[i].Hide();
                        Application.OpenForms[i].Opacity = 0;
                        Application.OpenForms[i].ShowInTaskbar = false;
                        Application.OpenForms[i].Visible = false; //호출해야 할 폼을 표출한다
                        Application.OpenForms[i].WindowState = FormWindowState.Minimized;
                    }
                }
                */
            }
            catch (Exception ex)
            {
                Common.SetLog(ex.Message, 3);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.radButton1.PerformClick();
        }
    }
}