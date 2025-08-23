using Kiosk.Class;
using log4net;
using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class Inherit : Form
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private Timer timer;
        private DateTime lastInputTime;

        // 윈도우 찾기
        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);

        // 윈도우 표시하기/숨기기
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int windowHandle, int command);

        public Inherit()
        {
            InitializeComponent();
            this.CenterToScreen();

            timer = new Timer();
            timer.Interval = 1000 * 60 * 2; //2분
            timer.Tick += Timer_Tick;
            //timer.Start();
        }

        #region 10분간 입력없을시 메인화면으로 이동하기

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Common Init
            Common.Init();

            this.Hide();

            Main main = new Main();

            // 모든 열린 폼을 확인하고 닫습니다.
            /*
            foreach (Form form in Application.OpenForms)
            {
                if (form != main)
                {
                    form.Close();
                }
            }
            */
            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name != "Main")
                {
                    Application.OpenForms[i].Hide();
                    Application.OpenForms[i].Close();
                }
            }

            main.ShowDialog();
        }

        private void ResetTimer()
        {
            timer.Stop();
            timer.Start();
        }

        #endregion

        // 필요한 위치에서 다음 프로시저를 호출
        private void Taskbar(string sts)
        {
            int hwnd = FindWindow("Shell_TrayWnd", "");
            if (sts == "Hide")
                ShowWindow(hwnd, 0);
            if (sts == "Show")
                ShowWindow(hwnd, 1);
        }

        private void Inherit_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1080, 1920);
            //this.TopMost = true;
            this.btnFatalClose.SendToBack();
            //Taskbar("Hide");
        }

        private void Inherit_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Taskbar("Show");
            //CloseAllForms();
            //this.Close();
        }

        private void CloseAllForms()
        {
            // 모든 열린 폼을 확인하고 닫습니다.
            try
            {
                if (Application.OpenForms.Count > 0)
                {
                    foreach (Form form in Application.OpenForms)
                    {
                        /*
                        if (form != this)
                        {
                            form.Close();
                        }
                        */
                    }
                }
            }
            catch (Exception ex)
            {
                Common.SetLog(ex.Message, 4);
            }
        }

        private void btnFatalClose_Click(object sender, EventArgs e)
        {
            Taskbar("Show");
            CloseAllForms();
            Common.SetLog("Program End", 1);
            Application.DoEvents();
            this.Close();
            Application.Exit();
        }

        private void Inherit_KeyDown(object sender, KeyEventArgs e)
        {
            lastInputTime = DateTime.Now;
        }

        private void btnFatalClose_MouseHover(object sender, EventArgs e)
        {
            this.btnFatalClose.BackColor = Color.White;
        }

        private void Inherit_MouseClick(object sender, MouseEventArgs e)
        {
            ResetTimer();
        }

        private void Inherit_MouseDown(object sender, MouseEventArgs e)
        {
            ResetTimer();
        }
    }
}