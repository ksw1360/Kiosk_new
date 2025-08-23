using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.Popup
{
    public partial class ErrorPopupMessage : Form
    {
        public string Names { get; internal set; }
        public string message { get; internal set; }
        public string result { get; internal set; }

        public ErrorPopupMessage()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void ErrorPopupMessage_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;

            this.label1.MaximumSize = new Size(603, 223);
            this.label1.AutoSize = false;
            //this.textBox1.AutoEllipsis = true;
            //this.label1.WordWrap = true;

            this.label1.Text = result;            

            this.label1.AutoSize = false;
            this.label1.Font = new Font("Noto Sans KR Regular", 24, FontStyle.Regular);
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.label1.Dock = DockStyle.Fill;

            this.TopMost = true;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbThird_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
