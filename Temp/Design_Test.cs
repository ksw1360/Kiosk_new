using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Kiosk.Temp
{
    public partial class Design_Test : Form
    {
        public Design_Test()
        {
            InitializeComponent();
        }

        private void Design_Test_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.Main화면;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            this.Load += TrayIcon_Load;

            //Tray_Icon.MouseDoubleClick += Tray_Icon_MouseDoubleClick;
            //toolStripMenuItem1.Click += ToolStripMenuItem1_Click;
            //toolStripMenuItem2.Click += ToolStripMenuItem2_Click;
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Visible = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void Tray_Icon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Visible = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void TrayIcon_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Show();
            //this.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
