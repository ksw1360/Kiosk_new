using System.Runtime.InteropServices;
using System.Text;

namespace Kiosk.TriupUpdate
{
    public class DllClass
    {
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val,
                                                   string filePath);
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def,
                                            StringBuilder retVal, int size, string filePath);
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern System.IntPtr CreateRoundRectRgn
       (
          int nLeftRect, // x-coordinate of upper-left corner
          int nTopRect, // y-coordinate of upper-left corner
          int nRightRect, // x-coordinate of lower-right corner
          int nBottomRect, // y-coordinate of lower-right corner
          int nWidthEllipse, // height of ellipse
          int nHeightEllipse // width of ellipse
       );
        [DllImport("winspool.drv")]
        public static extern bool SetDefaultPrinter(string name);

        public static string Fetch_version;
    }
}
