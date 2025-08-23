using Kiosk.Class;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Kiosk.Popup
{
    public partial class ykihoInput : Form
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);

        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder reVal, int size, string filepath);

        TextBox[] textBox = new TextBox[] { };

        public ykihoInput()
        {
            InitializeComponent();
            this.CenterToScreen();

            textBox1.AutoSize = false;
            textBox1.Height += 10;

            textBox2.AutoSize = false;
            textBox2.Height += 10;

            textBox3.AutoSize = false;
            textBox3.Height += 10;

            textBox4.AutoSize = false;
            textBox4.Height += 10;

            textBox5.AutoSize = false;
            textBox5.Height += 10;

            textBox6.AutoSize = false;
            textBox6.Height += 10;

            textBox7.AutoSize = false;
            textBox7.Height += 10;

            textBox8.AutoSize = false;
            textBox8.Height += 10;

            textBox = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };

            for (int idx = 0; idx < textBox.Length; idx++)
            {
                textBox[idx].BackColor = Color.White;
                textBox[idx].ForeColor = Color.Black;
            }

            this.TopMost = true;
        }

        private void ykihoInput_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;

            this.Location = new Point(514, 320);

            this.lbSecond.Text = "요양기관기호 등록";
            this.lbSecond.Font = new Font("NotoSansCJKKR-Bold", 33, FontStyle.Bold);
            this.lbSecond.AutoSize = false;
            this.lbSecond.TextAlign = ContentAlignment.MiddleCenter;
            this.lbSecond.Dock = DockStyle.Fill;

            this.lbFirst.Text = "요양기관기호를 입력해 주세요";
            this.lbFirst.Font = new Font("NotoSansCJKKR-Regular", 24, FontStyle.Regular);
            this.lbFirst.AutoSize = false;
            this.lbFirst.TextAlign = ContentAlignment.MiddleCenter;
            this.lbFirst.Dock = DockStyle.Fill;

            for (int idx = 0; idx < textBox.Length; idx++)
            {
                if (textBox[idx] != null)
                {
                    textBox[idx].Size = new System.Drawing.Size(60, 80);
                    textBox[idx].Font = new Font("Roboto-Medium", 37, FontStyle.Regular);
                    textBox[idx].TextAlign = HorizontalAlignment.Center;
                    textBox[idx].MaxLength = 1;
                }
            }

            this.btnCancel.Font = new Font("NotoSansCJKKR-Medium", 24, FontStyle.Regular);
            this.btnConfirm.Font = new Font("NotoSansCJKKR-Medium", 24, FontStyle.Regular);

            this.button7.Enabled = false;
            this.button14.Enabled = false;
            this.button15.Enabled = false;

            StringBuilder sb = new StringBuilder();
            GetPrivateProfileString("YKIHO", "ykiho", "", sb, sb.Capacity, Application.StartupPath + @"\YKIHO.ini");

            textBox = new TextBox[] { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8 };

            if (File.Exists(Application.StartupPath + @"\YKIHO.ini"))
            {
                for (int idx = 0; idx < textBox.Length; idx++)
                {
                    textBox[idx].Text = sb.ToString().Substring(idx, 1);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                for (int idx = 0; idx < textBox.Length; idx++)
                {
                    if (textBox[idx].Text.Length == 1)
                    {
                        textBox[idx].BackColor = Color.FromArgb(223, 227, 243);
                        textBox[idx].ForeColor = Color.FromArgb(100, 114, 171);
                        textBox[idx + 1].Focus();
                    }
                    else
                    {
                        textBox[idx].BackColor = Color.White;
                        textBox[idx].ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                Common.SetLog(ex.Message, 3);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string ykiho = textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text + textBox5.Text + textBox6.Text + textBox7.Text + textBox8.Text;
            if (string.IsNullOrEmpty(ykiho) == false)
            {
                Common.YKIHO = ykiho;
                string path = Application.StartupPath + @"\YKIHO.ini";
                WritePrivateProfileString("YKIHO", "ykiho", ykiho, path);
            }

            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            for (int idx = 0; idx < textBox.Length; idx++)
            {
                if (textBox[idx].Text.Length == 0)
                {
                    textBox[idx].Text = button.Text;
                    break;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = textBox.Length - 1; i > -1; i--)
            {
                if (textBox[i].Text.Length == 1)
                {
                    textBox[i].Text = "";
                    if (i == 0)
                    {
                        textBox[0].Focus();
                        break;
                    }
                    textBox[i - 1].Focus();
                    break;
                }
                else
                {
                    textBox[i].Focus();
                }
            }
        }
    }
}