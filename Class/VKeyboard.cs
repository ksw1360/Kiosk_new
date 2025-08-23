using log4net;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace formsApp
{
    class VKeyboard
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Kiosk.Main));
        [DllImport("User32.DLL")]
        public static extern Boolean PostMessage(Int32 hWnd, Int32 Msg, Int32 wParam, Int32 lParam);
        public const Int32 WM_USER = 1024;
        public const Int32 WM_CSKEYBOARD = WM_USER + 192;
        public const Int32 WM_CSKEYBOARDMOVE = WM_USER + 193;
        public const Int32 WM_CSKEYBOARDRESIZE = WM_USER + 197;

        static Process keyboardPs = null;

        public static void showKeyboard()
        {
            try
            {
                if (keyboardPs == null)
                {
                    string filePath;
                    if (Environment.Is64BitOperatingSystem)
                    {
                        filePath = Path.Combine(Directory.GetDirectories(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "winsxs"),
                            "amd64_microsoft-windows-osk_*")[0],
                            "osk.exe");
                    }
                    else
                    {
                        filePath = @"C:\windows\system32\osk.exe";
                    }
                    if (File.Exists(filePath))
                    {
                        keyboardPs = Process.Start(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Debug(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + ex.Message);
            }
        }
        public static void hideKeyboard()
        {
            try
            {
                if (keyboardPs != null)
                {
                    keyboardPs.Kill();
                    keyboardPs = null;
                }
            }
            catch (Exception ex)
            {
                log.Debug(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + ex.Message);
            }
        }

        public static void moveWindow(int x, int y, int w, int h)
        {
            try
            {
                if (keyboardPs.Handle != null)
                {
                    PostMessage(keyboardPs.Handle.ToInt32(), WM_CSKEYBOARDMOVE, x, y); // Move to 0, 0
                    PostMessage(keyboardPs.Handle.ToInt32(), WM_CSKEYBOARDRESIZE, w, h); // Resize to 600, 300
                }
            }
            catch (Exception ex)
            {
                log.Debug(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + ex.Message);
            }
        }
    }
}