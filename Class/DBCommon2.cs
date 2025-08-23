using Kiosk.TriupUpdate;
using log4net;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Kiosk.Class
{
    internal class DBCommon2
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Main));

        #region ini 입력 메소드
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion

        #region ConnectionString

        internal static string connectioninfo()
        {
            return DBContactor.SQL_CONN_QR;

            StringBuilder _ip = new StringBuilder();
            StringBuilder _port = new StringBuilder();
            StringBuilder _id = new StringBuilder();
            StringBuilder _password = new StringBuilder();
            StringBuilder _name = new StringBuilder();

            GetPrivateProfileString("DB접속정보", "IP", "", _ip, 32, Application.StartupPath + @"\DBConnect2.ini");
            GetPrivateProfileString("DB접속정보", "PORT", "", _port, 32, Application.StartupPath + @"\DBConnect2.ini");
            GetPrivateProfileString("DB접속정보", "ID", "", _id, 32, Application.StartupPath + @"\DBConnect2.ini");
            GetPrivateProfileString("DB접속정보", "PASSWORD", "", _password, 32, Application.StartupPath + @"\DBConnect2.ini");
            GetPrivateProfileString("DB접속정보", "NAME", "", _name, 32, Application.StartupPath + @"\DBConnect2.ini");

            //DB접속 ini File에서 읽어오는걸로 변경
            string ip = _ip.ToString();
            string port = _port.ToString();
            string id = _id.ToString();
            string password = _password.ToString();
            string name = _name.ToString();
            const string Charset = "utf8mb4";
            const bool UseConvertZeroDateTime = true;
            const bool UseAllowUserVariables = true;
            var connectinfo = $"server={ip};" +
                              $"UserId={id};" +
                              $"password={password};" +
                              $"database={name};" +
                              $"port={port};" +
                              $"charset={Charset};" +
                              $"convert zero datetime={UseConvertZeroDateTime};" +
                              $"Allow User Variables={UseAllowUserVariables};SSLMODE=NONE";

            return connectinfo;
        }
        #endregion

        #region Select Data
        internal static DataTable SelectData(string Query)
        {
            using (MySqlConnection connection = new MySqlConnection(connectioninfo()))
            {
                #region Select Data                
                try
                {
                    //int ret = 0;
                    DataTable result = new DataTable();
                    MySqlCommand command = new MySqlCommand(Query, connection);
                    connection.Open();
                    MySqlDataAdapter adapter = null;

                    command.Connection = connection;
                    command.CommandText = Query;
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    adapter = new MySqlDataAdapter(command);
                    adapter.Fill(result);

                    return result;
                }
                catch (Exception ex)
                {
                    log.Debug(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + ex.Message);
                    //Log.WriteLog(Log.enumLogLevel.MIDDLE, "Select Data", ex.Message);
                    return null;
                }
                finally
                {
                    connection.Dispose();
                }

                #endregion
            }
        }
        #endregion
    }
}