using System;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Security.Permissions;
using Kiosk.Class;

namespace Kiosk.Popup
{
    // 웹브라우저컨트롤을 위해서..
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]

    public partial class PopupAddressApi : Form
    {
        public string ZipCode = "";
        public string Address = "";

        public PopupAddressApi()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void PopupAddressApi_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            webBrowser1.Navigate("http://localhost/wwwroot/index2.html");
            webBrowser1.ObjectForScripting = this;

            this.Tag = null;

            this.TopMost = true;
        }

        public void CallForm(object sZipCode, object sAddress1)
        {
            try
            {
                ZipCode = (string)sZipCode;
                Address = (string)sAddress1;
                this.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                Common.SetLog(ex.Message, 3);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void gvAdrs_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Row is GridViewDataRowInfo)
            {
                GridViewDataRowInfo datarow = e.Row as GridViewDataRowInfo;

                string cellValue = datarow.Cells["ADDRESS"].Value.ToString();

                if (cellValue != "")
                {
                    Address = cellValue;
                }
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}