using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class BaseForm : Form
    {
        #region ini 입력 메소드
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion

        /// <summary>
        /// 키보드 이벤트 발생시키기
        /// </summary>
        /// <param name="virtualKey">가상 키</param>
        /// <param name="scanCode">스캔 코드</param>
        /// <param name="flag">플래그</param>
        /// <param name="extraInformation">추가 정보</param>
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

        #region Field

        /// <summary>
        /// 사운드 재생 여부
        /// </summary>
        private bool playSound = true;

        /// <summary>
        /// Caps Lock 버튼 눌림 여부
        /// </summary>
        private bool isPressedCAPSLOCK = false;

        /// <summary>
        /// Shift 버튼 눌림 여부
        /// </summary>
        private bool isPressedSHIFT = false;

        /// <summary>
        /// 한글 모드 여부
        /// </summary>
        private bool isHANGULMode = false;
        private int idx;

        #endregion

        #region imm32.dll :: Get_IME_Mode IME가져오기
        [DllImport("imm32.dll")]
        public static extern IntPtr ImmGetContext(IntPtr hWnd);
        [DllImport("imm32.dll")]
        public static extern Boolean ImmSetConversionStatus(IntPtr hIMC, Int32 fdwConversion, Int32 fdwSentence);
        [DllImport("imm32.dll")]
        private static extern IntPtr ImmGetDefaultIMEWnd(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr IParam);

        public const int IME_CMODE_ALPHANUMERIC = 0x0;   //영문
        public const int IME_CMODE_NATIVE = 0x1;         //한글
        #endregion

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public BaseForm()
        {
            InitializeComponent();
        }
    }
}