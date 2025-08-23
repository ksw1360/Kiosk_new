using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class NewKeyboard : UserControl
    {
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte virtualKey, byte scanCode, uint flag, int extraInformation);

        #region 후킹 초기화 하기 - InitHook(controlHandle)

        /// <summary>
        /// 후킹 초기화 하기
        /// </summary>
        /// <param name="controlHandle">컨트롤 핸들</param>
        [DllImport("vkb.dll", CharSet = CharSet.Auto)]
        private static extern void InitHook(IntPtr controlHandle);

        #endregion
        #region 후킹 설치하기 - InstallHook()

        /// <summary>
        /// 후킹 설치하기
        /// </summary>
        [DllImport("vkb.dll", CharSet = CharSet.Auto)]
        private static extern void InstallHook();

        #endregion

        public event EventHandler DataRequest;
        public string message = string.Empty;
        public NewKeyboard()
        {
            InitializeComponent();
        }

        private void Initialize()
        {
            InitHook(this.panel1.Handle);

            InstallHook();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //message += button1.Text;
            //DataRequest?.Invoke(message, EventArgs.Empty);

            this.button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button == null)
            {
                return;
            }

            if (button == button1) // "1"
            {
                keybd_event((byte)Keys.D1, 0, 0, 0);
                keybd_event((byte)Keys.D1, 0, 0x02, 0);
            }

            if (button == this.button2) // "2"
            {
                keybd_event((byte)Keys.D2, 0, 0, 0);
                keybd_event((byte)Keys.D2, 0, 0x02, 0);
            }

            if (button == this.button3) // "3"
            {
                keybd_event((byte)Keys.D3, 0, 0, 0);
                keybd_event((byte)Keys.D3, 0, 0x02, 0);
            }

            if (button == this.button4) // "4"
            {
                keybd_event((byte)Keys.D4, 0, 0, 0);
                keybd_event((byte)Keys.D4, 0, 0x02, 0);
            }

            if (button == this.button5) // "5"
            {
                keybd_event((byte)Keys.D5, 0, 0, 0);
                keybd_event((byte)Keys.D5, 0, 0x02, 0);
            }

            if (button == this.button6) // "6"
            {
                keybd_event((byte)Keys.D6, 0, 0, 0);
                keybd_event((byte)Keys.D6, 0, 0x02, 0);
            }

            if (button == this.button7) // "7"
            {
                keybd_event((byte)Keys.D7, 0, 0, 0);
                keybd_event((byte)Keys.D7, 0, 0x02, 0);
            }

            if (button == this.button8) // "8"
            {
                keybd_event((byte)Keys.D8, 0, 0, 0);
                keybd_event((byte)Keys.D8, 0, 0x02, 0);
            }

            if (button == this.button9) // "9"
            {
                keybd_event((byte)Keys.D9, 0, 0, 0);
                keybd_event((byte)Keys.D9, 0, 0x02, 0);
            }

            if (button == this.button0) // "0"
            {
                keybd_event((byte)Keys.D0, 0, 0, 0);
                keybd_event((byte)Keys.D0, 0, 0x02, 0);
            }

            DataRequest?.Invoke(button.Text, EventArgs.Empty);
        }

        private void NewKeyboard_Load(object sender, EventArgs e)
        {
            Initialize();
        }
    }
}