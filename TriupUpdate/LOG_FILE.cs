using System;
using System.IO;

namespace Kiosk.TriupUpdate
{
    class LOG_FILE
    {
        internal static void LogWrite(string str)
        {
            string DirPath = Environment.CurrentDirectory + @"\Log";
            string FilePath = DirPath + "\\Log_" + DateTime.Today.ToString("yyyyMMdd") + ".log";
            string temp;

            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(FilePath);

            try
            {
                if (!di.Exists) Directory.CreateDirectory(DirPath);
                if (!fi.Exists)
                {
                    using (StreamWriter sw = new StreamWriter(FilePath))
                    {
                        temp = string.Format("[{0}] {1}", DateTime.Now, str);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(FilePath))
                    {
                        temp = string.Format("[{0}] {1}", DateTime.Now, str);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
            }
            catch
            {
            }
        }
    }
}
