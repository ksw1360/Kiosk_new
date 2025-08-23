using Kiosk.Class;
using System;
using System.Data;
using System.Windows.Forms;

namespace Kiosk.Popup
{
    public partial class PersonInfoRule : Form
    {
        public PersonInfoRule()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void PersonInfoRule_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            //this.label1.Font = new Font("NotoSansCJKKR-Bold", 27, FontStyle.Bold);
            //this.label1.ForeColor = Color.FromArgb(100, 114, 171);

            string strSQL = "";
            strSQL += Environment.NewLine + "SELECT PRIVACY_STRING";
            strSQL += Environment.NewLine + " FROM HOSP_INFO";
            strSQL += Environment.NewLine + " WHERE YKIHO = '" + Common.YKIHO + "'";
            DataTable dtRule = DBCommon.SelectData(strSQL);

            this.TxtPrivacy.Text = dtRule.Rows[0]["PRIVACY_STRING"].ToString();

            this.TopMost = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.DarkBlue, ButtonBorderStyle.Solid);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "개인정보 동의 내용을 초기화 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                TxtPrivacy.Text = "";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static bool UPDATE_PRIVACY(string con_)
        {
            bool chk = false;
            //string strSQL = "update HOSP_INFO set PRIVACY_STRING = '" + ComLib.SQLString(con_) + "' where  YKIHO = '" + Common.YKIHO + "'";
            string strSQL = "update HOSP_INFO set PRIVACY_STRING = '" + con_ + "' where  YKIHO = '" + Common.YKIHO + "'";
            int rows = DBCommon.UpdateQuery2(strSQL);
            if (rows > 0)
            {
                chk = true;
            }
            else
            {
                chk = false;
            }
            return chk;
        }
    }
}
