using Kiosk.Class;
using Kiosk.Popup;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Kiosk
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (IsExistProcess(Process.GetCurrentProcess().ProcessName))
            {
                //MessageBox.Show("이미실행중입니다.");
                ErrorPopupMessage popupMessage = new ErrorPopupMessage();
                popupMessage.result = " 프로그램이 이미 실행중입니다." + Environment.NewLine + "프로세스를 확인바랍니다.";
                popupMessage.ShowDialog();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ko-KR"));

                //Common.PreLoading();

                Common.SetKbShift();

                //Application.Run(new LogIn());
                Application.Run(new CommonForm());
            }
            
        }

        static bool IsExistProcess(string processName)
        {
            Process[] process = Process.GetProcesses();
            int cnt = 0;

            //프로세스명으로 확인해서 동일한 프로세스 개수가 2개이상인지 확인합니다. 
            //현재실행하는 프로세스도 포함되기때문에 1보다커야합니다.
            foreach (var p in process)
            {
                if (p.ProcessName == processName)
                    cnt++;
                if (cnt > 1)
                    return true;
            }
            return false;
        }
    }
}
