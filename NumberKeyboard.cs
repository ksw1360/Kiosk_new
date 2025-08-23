using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class NumberKeyboard : UserControl
    {
        public event EventHandler DataRequest2;
        public string message = string.Empty;
        //private string mode;

        public static NumberKeyboard keyboard;

        public NumberKeyboard()
        {
            InitializeComponent();
            keyboard = this;
        }

        private void SetData(string text, string v)
        {
            if (v == "1")
            {
                message = message + text;
                textBox1.Text = message;
                DataRequest2?.Invoke(message, EventArgs.Empty);
            }
            else if (v == "2" || v == "3")
            {
                DataRequest2?.Invoke(message, EventArgs.Empty);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //message += button1.Text;
            //DataRequest2?.Invoke(message, EventArgs.Empty);
            SetData(button1.Text, "1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //message += button2.Text;
            //DataRequest2?.Invoke(message, EventArgs.Empty);
            SetData(button2.Text, "1");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //message += button3.Text;
            //textBox1.Text += message;
            //DataRequest2?.Invoke(message, EventArgs.Empty);
            SetData(button3.Text, "1");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //message += button6.Text;
            //textBox1.Text += message;
            //DataRequest2?.Invoke(message, EventArgs.Empty);
            SetData(button6.Text, "1");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //message += button5.Text;
            //textBox1.Text += message;
            //DataRequest2?.Invoke(message, EventArgs.Empty);
            SetData(button5.Text, "1");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //message += button4.Text;
            //textBox1.Text += message;
            //DataRequest2?.Invoke(message, EventArgs.Empty);
            SetData(button4.Text, "1");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //message += button9.Text;
            //textBox1.Text += message;
            //DataRequest2?.Invoke(message, EventArgs.Empty);
            SetData(button9.Text, "1");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //message += button8.Text;
            //textBox1.Text += message;
            //DataRequest2?.Invoke(message, EventArgs.Empty);
            SetData(button8.Text, "1");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //message += button7.Text;
            //textBox1.Text += message;
            //DataRequest2?.Invoke(message, EventArgs.Empty);
            SetData(button7.Text, "1");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //message += button11.Text;
            //textBox1.Text += message;
            //DataRequest2?.Invoke(message, EventArgs.Empty);
            SetData(button11.Text, "1");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            message = button10.Text + "-";
            textBox1.Text = message;
            //DataRequest2?.Invoke(message, EventArgs.Empty);
            SetData(message, "3");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                int startIndex = textBox1.Text.Length - 1;
                textBox1.Text = textBox1.Text.Remove(startIndex);
                message = textBox1.Text;
            }
            //DataRequest2?.Invoke(message, EventArgs.Empty);
            SetData(message, "2");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(message);
            /*
            textBox2.Text = Convert.ToString(textBox1.Text.Length);
            if (textBox1.Text.Length == 6)
            {
                string match = textBox1.Text.Substring(0, 3);
                if (match == "010")
                {
                    if (match.Length == 3)
                    {
                        textBox1.Text = textBox1.Text + "-";
                    }
                    else if (match.Length == 8)
                    {
                        textBox1.Text = textBox1.Text + "-";
                    }
                }
                else
                {
                    if (textBox1.Text.Length == 6)
                    {
                        textBox1.Text = textBox1.Text + "-";
                    }
                }
            }
            */
        }

        private void NumberKeyboard_Load(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                Button btn = c as Button;
                if (btn != null)
                {
                    btn.BackColor = Color.White;
                }
            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {

        }
    }
}