using System;
using System.Windows.Forms;

namespace Kiosk.Popup
{
    public partial class PopupMessageQuestion : Form
    {
        public string Names { get; internal set; }
        public string messages { get; internal set; }
        public string result { get; internal set; }

        public PopupMessageQuestion()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void PopupMessageQuestion_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;

            this.lbFirst.Text = Names;
            //this.lbFirst.AutoSize = false;
            //this.lbFirst.Font = new Font("Noto Sans KR Regular", 24, FontStyle.Regular);
            //this.lbFirst.TextAlign = ContentAlignment.MiddleCenter;
            //this.lbFirst.Dock = DockStyle.Fill;

            this.lbSecond.Text = messages;
            //this.lbSecond.Font = new Font("Noto Sans KR Bold", 37, FontStyle.Bold);
            //this.lbSecond.AutoSize = false;
            //this.lbSecond.TextAlign = ContentAlignment.MiddleCenter;
            //this.lbSecond.Dock = DockStyle.Fill;

            this.lbThird.Text = result;
            //this.lbThird.AutoSize = false;
            //this.lbThird.Font = new Font("Noto Sans KR Bold", 33, FontStyle.Bold);
            //this.lbThird.TextAlign = ContentAlignment.MiddleCenter;
            //this.lbThird.Dock = DockStyle.Fill;

            this.TopMost = true;


        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            //DialogResult = DialogResult.No;
            Close();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}