using Kiosk.Class;
using Kiosk.Popup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class PtntInfoShow : UserControl
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        internal string PtntInfo = string.Empty;
        private bool isColor1;

        internal List<string> List = new List<string>();
        internal DataTable dt;

        public string _names { get; internal set; }

        public event EventHandler Button_Event;

        public PtntInfoShow()
        {
            InitializeComponent();
        }

        private void PtntInfoShow_Load(object sender, EventArgs e)
        {
            init();
        }

        private void init()
        {
            radLabel1.BackColor = Color.White;
            radLabel1.ForeColor = Color.FromArgb(101, 101, 101);

            radLabel2.BackColor = Color.White;
            radLabel2.ForeColor = Color.FromArgb(101, 101, 101);

            radLabel3.BackColor = Color.White;
            radLabel3.ForeColor = Color.FromArgb(101, 101, 101);

            //radLabel1.ReadOnly = true;
            radLabel1.Enabled = true;
            radLabel1.TextAlignment = ContentAlignment.MiddleCenter;
            //.TextAlign = HorizontalAlignment.Center;
            //radLabel1.WordWrap = true;
            radLabel1.TabStop = false;
            radLabel1.Size = new System.Drawing.Size(288, 68);

            //radLabel2.ReadOnly = true;
            radLabel2.Enabled = true;
            //radLabel2.TextAlign = HorizontalAlignment.Center;
            //radLabel2.WordWrap = true;
            radLabel2.TabStop = false;
            radLabel2.Size = new System.Drawing.Size(225, 68);

            ////radLabel3.ReadOnly = true;
            //radLabel3.Enabled = true;
            ////radLabel3.TextAlign = HorizontalAlignment.Center;
            ////radLabel3.WordWrap = true;
            //radLabel3.TabStop = false;
            //radLabel3.Size = new System.Drawing.Size(288, 68);

            //radLabel5.ReadOnly = true;
            radLabel5.Enabled = true;
            //radLabel5.TextAlign = HorizontalAlignment.Center;
            //radLabel5.WordWrap = true;
            radLabel5.TabStop = false;
            radLabel5.Size = new System.Drawing.Size(288, 68);
        }

        private object radTextBox1_Click(object sender, EventArgs e)
        {
            List.Add(radLabel1.Text);
            List.Add(radLabel2.Text);
            List.Add(radLabel3.Text);
            List.Add(radLabel4.Text);

            Common.List = this.List;
            Ptnt_List_Popup.ptnt_list_popup.ptntInfo_Click(this, e);

            return e;
        }

        public void SetSelectColor()
        {
            this.panel1.BackColor = Color.FromArgb(255, 242, 243);
            this.radLabel1.BackColor = Color.FromArgb(255, 242, 243);
            this.radLabel2.BackColor = Color.FromArgb(255, 242, 243);
            this.radLabel3.BackColor = Color.FromArgb(255, 242, 243);
            this.radLabel5.BackColor = Color.FromArgb(255, 242, 243);
        }

        public void UnSetSelectColor()
        {
            this.panel1.BackColor = Color.White;
            this.radLabel1.BackColor = Color.White;
            this.radLabel2.BackColor = Color.White;
            this.radLabel3.BackColor = Color.White;
            this.radLabel5.BackColor = Color.White;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            List.Add(radLabel1.Text);
            List.Add(radLabel2.Text);
            List.Add(radLabel3.Text);
            List.Add(radLabel4.Text);

            Common.List = this.List;
            Ptnt_List_Popup.ptnt_list_popup.ptntInfo_Click(this, e);
        }

        private void radLabel3_TextChanged(object sender, EventArgs e)
        {
            if (this.radLabel3.Text.Length == 13)
            {
                string text = this.radLabel3.Text.ToString();
                this.radLabel5.Text = string.Format($"{text.Substring(0, 4)}****{text.Substring(8, 5)}");
            }
        }
    }
}