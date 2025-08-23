using System.Text;

namespace Kiosk.TriupUpdate
{
    public class INI_File
    {
        #region INI
        internal static void WriteIniFile(string section, string key, string value, string path)
        {
            DllClass.WritePrivateProfileString(section, key, value, path);
        }
        internal static string ReadIniFile(string section, string key, string path)
        {
            StringBuilder sb = new StringBuilder(255);
            DllClass.GetPrivateProfileString(section, key, "", sb, sb.Capacity, path);
            return sb.ToString();
        }
        #endregion
    }
}
