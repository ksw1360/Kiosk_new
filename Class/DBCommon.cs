using Kiosk.TriupUpdate;
using log4net;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Kiosk.Class
{
    internal class DBCommon
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Main));

        internal static DataTable GetFIXSMSInfo(object planCode)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("/* queryId - 호출하기 양식조회 */");
            sb.Append(" \r\n SELECT * ");
            sb.Append(" \r\n FROM  SMS_FIX_PLAN_INFO");
            sb.Append($" \r\n WHERE YKIHO = '{Common.YKIHO}' AND PLAN_CD = '{planCode}';");
            return SelectData(sb.ToString());
        }
        #region ini 입력 메소드
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion

        internal static bool reply;

        public static string BLDNG_NO { get; internal set; }
        public static string ROAD_NM { get; internal set; }
        public static string BLDNG_NO_2 { get; internal set; }
        public static string CITY_NM { get; internal set; }
        public static string CITY_BLDNG_NM { get; internal set; }

        internal static string connectioninfo()
        {
            return DBContactor.SQL_CONN_MOTION;

            StringBuilder _ip = new StringBuilder();
            StringBuilder _port = new StringBuilder();
            StringBuilder _id = new StringBuilder();
            StringBuilder _password = new StringBuilder();
            StringBuilder _name = new StringBuilder();

            GetPrivateProfileString("DB접속정보", "IP", "", _ip, 32, Application.StartupPath + @"\DBConnect.ini");
            GetPrivateProfileString("DB접속정보", "PORT", "", _port, 32, Application.StartupPath + @"\DBConnect.ini");
            GetPrivateProfileString("DB접속정보", "ID", "", _id, 32, Application.StartupPath + @"\DBConnect.ini");
            GetPrivateProfileString("DB접속정보", "PASSWORD", "", _password, 32, Application.StartupPath + @"\DBConnect.ini");
            GetPrivateProfileString("DB접속정보", "NAME", "", _name, 32, Application.StartupPath + @"\DBConnect.ini");

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

        internal static DataTable getDgamtList(string address)
        {
            string strSQL10 = "/* 주소 DB 조회 */";
            strSQL10 += Environment.NewLine + "SELECT DISTINCT ";
            strSQL10 += Environment.NewLine + "     ADDRESS_DETL.ZIP_NO,";           //우편번호
            strSQL10 += Environment.NewLine + "     CONCAT(ADDRESS_ALL.STAT_NM,' '"; //주소
            strSQL10 += Environment.NewLine + "     ,ADDRESS_ALL.CUNTY_NM,' '";
            strSQL10 += Environment.NewLine + "     ,IF(ADDRESS_NO.TOWN_NM='','',ADDRESS_NO.CITY_NM),''";
            strSQL10 += Environment.NewLine + "     ,ADDRESS_ALL.ROAD_NM,' '";
            strSQL10 += Environment.NewLine + "     ,IF(ADDRESS_RD.UNDRG_YN,'지하','')";
            strSQL10 += Environment.NewLine + "     ,ADDRESS_RD.BLDNG_NO";
            strSQL10 += Environment.NewLine + "     ,IF(ADDRESS_RD.BLDNG_BNO='','',CONCAT('-',ADDRESS_RD.BLDNG_BNO)),' '";
            strSQL10 += Environment.NewLine + "     ,IF(ADDRESS_NO.TOWN_NM='',CONCAT('(',ADDRESS_NO.CITY_NM,  IF(ADDRESS_DETL.APRT_YN, CONCAT(', ',ADDRESS_DETL.CITY_BLDNG_NM),''),')'),'')";
            strSQL10 += Environment.NewLine + "     ,'\n'";
            strSQL10 += Environment.NewLine + "     ,ADDRESS_ALL.STAT_NM,' '";
            strSQL10 += Environment.NewLine + "     ,ADDRESS_ALL.CUNTY_NM,' '";
            strSQL10 += Environment.NewLine + "     ,ADDRESS_NO.CITY_NM,' '";
            strSQL10 += Environment.NewLine + "     ,ADDRESS_NO.LOT_NBR_N";
            strSQL10 += Environment.NewLine + "     ,IF(ADDRESS_NO.LOT_NBR_H='','',CONCAT('-',ADDRESS_NO.LOT_NBR_H)),' '";
            strSQL10 += Environment.NewLine + "     ,ADDRESS_DETL.CITY_BLDNG_NM) AS ADDRESS";
            strSQL10 += Environment.NewLine + "     FROM COMMON_DB.ADDRESS_ALL JOIN COMMON_DB.ADDRESS_RD ON  ADDRESS_ALL.ROAD_CD=ADDRESS_RD.ROAD_CD AND ADDRESS_ALL.CITY_NO=ADDRESS_RD.CITY_NO";
            strSQL10 += Environment.NewLine + "     JOIN COMMON_DB.ADDRESS_NO  ON ADDRESS_RD.MNGMN_NO=ADDRESS_NO.MNGMN_NO AND ADDRESS_RD.CITY_NO=ADDRESS_ALL.CITY_NO";
            strSQL10 += Environment.NewLine + "     JOIN COMMON_DB.ADDRESS_DETL ON ADDRESS_RD.MNGMN_NO=ADDRESS_DETL.MNGMN_NO ";
            strSQL10 += Environment.NewLine + "     WHERE";

            if (!string.IsNullOrEmpty(BLDNG_NO)) //지번
            {
                if (strSQL10.EndsWith("WHERE"))
                {
                    strSQL10 += Environment.NewLine + "     (ADDRESS_RD.BLDNG_NO LIKE '%" + BLDNG_NO + "%' OR ADDRESS_NO.LOT_NBR_N LIKE '%" + BLDNG_NO + "%')";
                }
                else
                {
                    strSQL10 += Environment.NewLine + "     AND";
                    strSQL10 += Environment.NewLine + "     (ADDRESS_RD.BLDNG_NO LIKE '%" + BLDNG_NO + "%' OR ADDRESS_NO.LOT_NBR_N LIKE '%" + BLDNG_NO + "%')";
                }
            }

            if (!string.IsNullOrEmpty(ROAD_NM)) //도로명 로/길
            {
                if (strSQL10.EndsWith("WHERE"))
                {
                    strSQL10 += Environment.NewLine + "     ADDRESS_ALL.ROAD_NM LIKE '%" + ROAD_NM + "%' ";
                }
                else
                {
                    strSQL10 += Environment.NewLine + "     AND";
                    strSQL10 += Environment.NewLine + "    ADDRESS_ALL.ROAD_NM LIKE '%" + ROAD_NM + "%' ";
                }
            }

            if (!string.IsNullOrEmpty(CITY_NM)) //동명

            {
                if (strSQL10.EndsWith("WHERE"))
                {
                    strSQL10 += Environment.NewLine + "     ADDRESS_ALL.CITY_NM LIKE '%" + CITY_NM + "%' ";
                }
                else
                {
                    strSQL10 += Environment.NewLine + "     AND";
                    strSQL10 += Environment.NewLine + "   ADDRESS_ALL.CITY_NM LIKE '%" + CITY_NM + "%' ";
                }
            }

            if (!string.IsNullOrEmpty(CITY_BLDNG_NM)) //건물명
            {
                if (strSQL10.EndsWith("WHERE"))
                {
                    strSQL10 += Environment.NewLine + "     ADDRESS_DETL.CITY_BLDNG_NM  LIKE '%" + CITY_BLDNG_NM + "%' ";
                }
                else
                {
                    strSQL10 += Environment.NewLine + "     AND";
                    strSQL10 += Environment.NewLine + "   ADDRESS_DETL.CITY_BLDNG_NM LIKE '%" + CITY_BLDNG_NM + "%' ";
                }
            }

            DataTable dt10 = new DataTable();
            dt10 = SelectData(strSQL10);
            //dt10 = DBConnection.GetSQLRslt(strSQL10);
            //DBContactor.GetSQLResult(strSQL10, DBContactor.SQL_CONN_MOTION, out dt10);

            //radLabel3.Text = "(" + dt10.Rows.Count + "건)";
            //gvAdrs.TableElement.RowHeight = 60;

            return dt10;
        }

        /// <summary>
        /// 내원일련번호 최대값
        /// </summary>
        /// <param name="Patno"></param>
        /// <returns></returns>
        internal static string ChkVISTNum(string YKIHO, string Patno)
        {
            string strSQL3 = "SELECT LPAD(IFNULL(MAX(VIST_SN) + 1, 1), 5, 0) FROM PTNT_DETL WHERE YKIHO='" + YKIHO + "' AND PAT_NO = '" + Patno + "'";
            DataTable dt3 = new DataTable();
            dt3 = SelectData(strSQL3);
            return dt3.Rows[0][0].ToString();
        }

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

        internal static int SelectCount(string Query)
        {
            int Rows = 0;
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

                    if (result.Rows.Count > 0)
                    {
                        Rows = Convert.ToInt32(result.Rows[0]["SEQ"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    log.Debug(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + ex.Message);
                    //Log.WriteLog(Log.enumLogLevel.MIDDLE, "Select Data", ex.Message);
                    return Rows;
                }
                finally
                {
                    connection.Dispose();
                }
                return Rows;
                #endregion
            }
        }

        public static int ExecSQLRsltCnt(string query)
        {
            int ret = 0;
            using (MySqlConnection connection = new MySqlConnection(connectioninfo()))
            {
                #region Select Data                
                try
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    log.Debug(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + ex.Message);
                    return -1;
                }
                finally
                {
                    connection.Dispose();
                }

                return ret;
                #endregion
            }
        }

        public static int GetSQLMultiResult(List<string> datas)
        {
            int ret = 0;
            using (MySqlConnection connection = new MySqlConnection(connectioninfo()))
            {
                MySqlTransaction transaction = null;
                #region Select Data                
                try
                {
                    MySqlCommand command = new MySqlCommand();
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    foreach (string sqlStr in datas)
                    {
                        command = new MySqlCommand(sqlStr, connection);
                        command.CommandText = sqlStr;
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    log.Debug(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + ex.Message);

                    transaction.Rollback();


                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }

                    return -1;
                }
                finally
                {
                    if (connection != null)
                        connection.Close();
                    connection.Dispose();
                }

                return ret;
                #endregion
            }
        }

        internal static int InsertIF(string sql)
        {
            int rowAffected = 0;
            using (MySqlConnection connection = new MySqlConnection(connectioninfo()))
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    rowAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    log.Debug(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + ex.Message);
                    //Log.WriteLog(Log.enumLogLevel.MIDDLE, "Insert Data", ex.Message);
                    return rowAffected;
                }

                return rowAffected;
            }
        }

        internal static void UpdateQuery(string v)
        {
            using (MySqlConnection connection = new MySqlConnection(connectioninfo()))
            {
                try
                {
                    MySqlCommand command = null;
                    command = new MySqlCommand(v, connection);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    if (command.ExecuteNonQuery() == 1)
                    {
                        reply = true;
                    }
                    else
                    {
                        reply = false;
                    }
                }
                catch (Exception ex)
                {
                    log.Debug(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + ex.Message);
                    //Log.WriteLog(Log.enumLogLevel.MIDDLE, "Update Data", ex.Message);
                    reply = false;
                }
                finally
                {
                    connection.Dispose();
                }
            }
        }

        internal static int UpdateQuery2(string v)
        {
            int ret = 0;
            using (MySqlConnection connection = new MySqlConnection(connectioninfo()))
            {
                try
                {
                    MySqlCommand command = null;
                    command = new MySqlCommand(v, connection);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    ret = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    log.Debug(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + ex.Message);
                    //Log.WriteLog(Log.enumLogLevel.MIDDLE, "Update Data", ex.Message);
                    return ret;
                }
                finally
                {
                    connection.Dispose();
                }
            }
            return ret;
        }

        internal static void CallProcedure(string regvid, string v)
        {

            using (MySqlConnection connection = new MySqlConnection(connectioninfo()))
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (MySqlCommand command = new MySqlCommand("PROC_SCRA_REGV", connection))
                    {
                        command.CommandType = CommandType.Text;
                        regvid = regvid.Substring(1, 10);
                        command.Parameters.AddWithValue("in_regvid", regvid);
                        command.Parameters.AddWithValue("in_YKIHO", v);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    log.Debug(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + ex.Message);
                    //Log.WriteLog(Log.enumLogLevel.MIDDLE, "Procedure Call", ex.Message);
                    throw ex;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

    }
}