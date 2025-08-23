using Kiosk.Class;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Kiosk.Popup
{
    public partial class PopupContinue : Form
    {
        int sec = 15;

        public PopupContinue()
        {
            InitializeComponent();
        }

        private void PopupContinue_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            //this.BringToFront();
            this.button1.BackColor = Color.FromArgb(0, 0, 0, 0);
            this.button2.BackColor = Color.FromArgb(0, 0, 0, 0);
            timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (sec == 0)
            {
                timer1.Stop();

                //입력이 없음 메인으로 복귀

                //Common Init
                Common.Init();

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
                        Application.OpenForms[i].Hide();
                    }
                }
                //Common Init
                /*
                Common.Init();
                var findform = new Form();
                Form specificForm = Application.OpenForms.OfType<Main>().FirstOrDefault();
                if (specificForm != null)
                {
                    if (specificForm.Name == "Main")
                    {
                        //Main화면 열기
                        specificForm.Visible = true;
                        specificForm.WindowState = FormWindowState.Maximized;
                    }
                }

                // 다른 모든 폼을 닫습니다.
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    if (Application.OpenForms[i] != findform)
                    {
                        Application.OpenForms[i].Hide();
                    }
                }
                */

                //Common.TimerReset();
                DialogResult = DialogResult.OK;
            }

            label1.Text = Convert.ToString(sec);
            sec--;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}