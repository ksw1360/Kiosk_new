using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Telerik.WinControls;
using CommonControls;

namespace Kiosk.TriupUpdate
{
    public static class DBContactor
    {
        #region Define
        public enum DBName
        {
            CommonDB,
            ChartDB,
            QRDB
        }
        #endregion

        #region Field

        public static DBInfomation CommonDB { get; private set; } = new DBInfomation();
        public static DBInfomation ChartDB { get; private set; } = new DBInfomation();
        public static DBInfomation QRDB { get; private set; } = new DBInfomation();

        //# 공통DB
        public static string SQL_CONN_COMMON { get; private set; }
        public static string SQL_CONN_MOTION { get; private set; }
        public static string SQL_CONN_QR { get; private set; }
        #endregion

        #region Property
        #endregion

        #region Method

        #region 초기설정
        public static void SetDBInformation(DBContactor.DBName dbName)
        {
            switch (dbName)
            {
                case DBName.CommonDB:
                    DBContactor.SQL_CONN_COMMON = CommonDB.MakeConn();
                    FrmUpdateHistory.SQL_CONN_COMMON = DBContactor.SQL_CONN_COMMON;//커먼라이브러리에 없어서 히스토리에 만듬.
                    break;
                case DBName.ChartDB:
                    DBContactor.SQL_CONN_MOTION = ChartDB.MakeConn();
                    break;
                case DBName.QRDB:
                    DBContactor.SQL_CONN_QR = QRDB.MakeConn();
                    break;
            }
        }
        
        public static void SetIP(DBContactor.DBName dbName, string ip)
        {
            if (string.IsNullOrEmpty(ip) == true)
            {
                // Error 처리
                //MoTMessageBox.Show("Set Ip Error");
                return;
            }

            switch (dbName)
            {
                case DBName.CommonDB:
                    DBContactor.CommonDB.IP = ip;
                    break;
                case DBName.ChartDB:
                    DBContactor.ChartDB.IP = ip;
                    break;
                case DBName.QRDB:
                    DBContactor.QRDB.IP = ip;
                    break;
            }
        }

        public static void SetID(DBContactor.DBName dbName, string id)
        {
            if (string.IsNullOrEmpty(id) == true)
            {
                // Error 처리
                return;
            }

            switch (dbName)
            {
                case DBName.CommonDB:
                    DBContactor.CommonDB.ID = id;
                    break;
                case DBName.ChartDB:
                    DBContactor.ChartDB.ID = id;
                    break;
                case DBName.QRDB:
                    DBContactor.QRDB.ID = id;
                    break;
            }
        }

        public static void SetPassword(DBContactor.DBName dbName, string password)
        {
            if (string.IsNullOrEmpty(password) == true)
            {
                // Error 처리
                return;
            }

            switch (dbName)
            {
                case DBName.CommonDB:
                    DBContactor.CommonDB.Password = password;
                    break;
                case DBName.ChartDB:
                    DBContactor.ChartDB.Password = password;
                    break;
                case DBName.QRDB:
                    DBContactor.QRDB.Password = password;
                    break;
            }
        }

        public static void SetName(DBContactor.DBName dbName, string name)
        {
            if (string.IsNullOrEmpty(name) == true)
            {
                // Error 처리
                return;
            }

            switch (dbName)
            {
                case DBName.CommonDB:
                    DBContactor.CommonDB.DBName = name;
                    break;
                case DBName.ChartDB:
                    DBContactor.ChartDB.DBName = name;
                    break;
                case DBName.QRDB:
                    DBContactor.QRDB.DBName = name;
                    break;
            }
        }

        public static void SetPort(DBContactor.DBName dbName, int port)
        {
            if (port <= 0)
            {
                // Error 처리
                return;
            }

            switch (dbName)
            {
                case DBName.CommonDB:
                    DBContactor.CommonDB.Port = port;
                    break;
                case DBName.ChartDB:
                    DBContactor.ChartDB.Port = port;
                    break;
                case DBName.QRDB:
                    DBContactor.QRDB.Port = port;
                    break;
            }
        }

        public static string GetIP(DBContactor.DBName dbName)
        {
            string ip = "";

            switch (dbName)
            {
                case DBName.CommonDB:
                    ip = tProtectedData.UnProtect(DBContactor.CommonDB.IP);
                    break;
                case DBName.ChartDB:
                    ip = tProtectedData.UnProtect(DBContactor.ChartDB.IP);
                    break;
                case DBName.QRDB:
                    ip = tProtectedData.UnProtect(DBContactor.QRDB.IP);
                    break;
            }

            return ip;
        }

        public static string GetID(DBContactor.DBName dbName)
        {
            string id = "";

            switch (dbName)
            {
                case DBName.CommonDB:
                    id = tProtectedData.UnProtect(DBContactor.CommonDB.ID);
                    break;
                case DBName.ChartDB:
                    id = tProtectedData.UnProtect(DBContactor.ChartDB.ID);
                    break;
                case DBName.QRDB:
                    id = tProtectedData.UnProtect(DBContactor.QRDB.ID);
                    break;
            }

            return id;
        }

        public static string GetPassword(DBContactor.DBName dbName)
        {
            string password = "";

            switch (dbName)
            {
                case DBName.CommonDB:
                    password = tProtectedData.UnProtect(DBContactor.CommonDB.Password);
                    break;
                case DBName.ChartDB:
                    password = tProtectedData.UnProtect(DBContactor.ChartDB.Password);
                    break;
                case DBName.QRDB:
                    password = tProtectedData.UnProtect(DBContactor.QRDB.Password);
                    break;
            }

            return password;
        }

        public static string GetName(DBContactor.DBName dbName)
        {
            string name = "";

            switch (dbName)
            {
                case DBName.CommonDB:
                    name = tProtectedData.UnProtect(DBContactor.CommonDB.DBName);
                    break;
                case DBName.ChartDB:
                    name = tProtectedData.UnProtect(DBContactor.ChartDB.DBName);
                    break;
                case DBName.QRDB:
                    name = tProtectedData.UnProtect(DBContactor.QRDB.DBName);
                    break;
            }

            return name;
        }

        public static int GetPort(DBContactor.DBName dbName)
        {
            int port = 0;

            switch (dbName)
            {
                case DBName.CommonDB:
                    port = DBContactor.CommonDB.Port;
                    break;
                case DBName.ChartDB:
                    port = DBContactor.ChartDB.Port;
                    break;
                case DBName.QRDB:
                    port = DBContactor.QRDB.Port;
                    break;
            }

            return port;
        }
        #endregion

        public static int GetSQLResult(string query, string sqlCommand, out DataTable result)
        {
            int ret = 0;
            result = new DataTable();
            MySqlCommand myCmd = new MySqlCommand();
            MySqlConnection myConn = new MySqlConnection(sqlCommand);
            MySqlDataAdapter adapter = null;

            try
            {
                myCmd.Connection = myConn;
                myCmd.CommandText = query;
                myConn.Open();

                adapter = new MySqlDataAdapter(myCmd);
                adapter.Fill(result);
            }
            catch (MySqlException ex)
            {
                ret = -1;
                //MoTMessageBox.Show($"GetSQLResult Error\r\n{ex.Message}", "", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                myConn.Close();
                myConn.Dispose();
            }

            return ret;
        }
        public static int GetSQLMultiResult(List<string> datas, string sqlCommand)
        {
            int ret = 0;

            MySqlConnection myConn = new MySqlConnection(sqlCommand);
            MySqlCommand myCmd = new MySqlCommand();
            MySqlTransaction transaction = null;

            try
            {
                //myCmd.Connection = myConn;
                myConn.Open();
                transaction = myConn.BeginTransaction();

                //로그 찍어봐서 오류나는 컬럼 찾아보자구나
                int i = 0;
                foreach (string sqlStr in datas)
                {
                    i++;
                    LOG_FILE.LogWrite(i.ToString() + " " + sqlStr);
                    myCmd = new MySqlCommand(sqlStr, myConn);

                    myCmd.CommandText = sqlStr;

                    myCmd.ExecuteNonQuery();
                }

                transaction.Commit();

            }
            catch (MySqlException ex)
            {
                transaction.Rollback();
                ret = -1;

                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }

                if (ex.Number != (int)MySqlErrorCode.LockDeadlock)
                {
                    //MoTMessageBox.Show("저장 쿼리 오류 !\r\n" + ex.ToString(), "", MessageBoxButtons.OK, RadMessageIcon.Error);
                }

            }
            finally
            {
                myConn.Close();
                myConn.Dispose();
            }

            return ret;
        }

        /// <summary>
        /// Query 안에 <@image or @Image or @IMAGE>를 Image byte[]로 변환시켜
        /// Insert, Update 에 사용.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="imageByte"></param>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public static int ExecSQLRsltCntImg(string query, byte[] imageByte, string sqlCommand)
        {
            int ret = 0;

            MySqlConnection myConn = new MySqlConnection(sqlCommand);
            MySqlCommand myCmd = null;

            try
            {
                myCmd = new MySqlCommand(query, myConn);
                myConn.Open();

                if (query.Contains("@Image") == true)
                    myCmd.Parameters.AddWithValue("@Image", imageByte);
                else if (query.Contains("@image") == true)
                    myCmd.Parameters.AddWithValue("@image", imageByte);
                else if (query.Contains("@IMAGE") == true)
                    myCmd.Parameters.AddWithValue("@IMAGE", imageByte);

                if (myCmd.ExecuteNonQuery() <= 0) ret = -1;
            }
            catch (MySqlException ex)
            {
                ret = -1;
                //MoTMessageBox.Show($"GetSQLResult Error\r\n{ex.Message}", "", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                myConn.Close();
                myConn.Dispose();
            }
            return ret;
        }

        /// <summary>
        /// Query 안에 <@image or @Image or @IMAGE>를 Image byte[]로 변환시켜
        /// Insert, Update 에 사용.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="imageByte"></param>
        /// <param name="sqlCommand"></param>
        /// <returns></returns>
        public static int ExecSQLRsltCntImg(string query, Image image, string sqlCommand)
        {
            int ret = 0;
            byte[] imageByte;
            MySqlConnection myConn = new MySqlConnection(sqlCommand);
            MySqlCommand myCmd = null;
            //imageByte = ComLib.ImageToByteArray(image);

            try
            {
                myCmd = new MySqlCommand(query, myConn);
                myConn.Open();

                //if (query.Contains("@Image") == true)
                //    myCmd.Parameters.AddWithValue("@Image", imageByte);
                //else if (query.Contains("@image") == true)
                //    myCmd.Parameters.AddWithValue("@image", imageByte);
                //else if (query.Contains("@IMAGE") == true)
                //    myCmd.Parameters.AddWithValue("@IMAGE", imageByte);

                if (myCmd.ExecuteNonQuery() <= 0) ret = -1;
            }
            catch (MySqlException ex)
            {
                ret = -1;
                //MoTMessageBox.Show($"GetSQLResult Error\r\n{ex.Message}", "", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                myConn.Close();
                myConn.Dispose();
            }
            return ret;
        }

        public static int ExecSQLRsltCnt(string query, string sqlCommand)
        {
            int ret = 0;

            MySqlConnection myConn = new MySqlConnection(sqlCommand);
            MySqlCommand myCmd = null;

            try
            {
                myCmd = new MySqlCommand(query, myConn);
                myConn.Open();

                myCmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                ret = -1;
                //MoTMessageBox.Show($"GetSQLResult Error\r\n{ex.Message}", "", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                myConn.Close();
                myConn.Dispose();
                myCmd.Dispose();
            }

            return ret;
        }

        public static void SetIP()
        {
            cMasterList list = cMasterData.GetMasterDB();

            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    // 메인 DB
                    if (list[i].ITEM == 0)
                    {
                        DBContactor.SetIP(DBContactor.DBName.ChartDB, list[i].IP);
                        DBContactor.SetID(DBContactor.DBName.ChartDB, list[i].ID);
                        DBContactor.SetPassword(DBContactor.DBName.ChartDB, list[i].PASSWORD);
                        DBContactor.SetName(DBContactor.DBName.ChartDB, list[i].NAME);
                        //ClsMotionDB.DB_Name = list[i].NAME;
                        DBContactor.SetPort(DBContactor.DBName.ChartDB, list[i].PORT);
                        DBContactor.SetDBInformation(DBContactor.DBName.ChartDB);
                    }
                    //// MESSAGE 
                    //else if (list[i].ITEM == 1)
                    //{
                    //    DBContactor.SetIP(DBContactor.DBName.MessageDB, list[i].IP);
                    //    DBContactor.SetID(DBContactor.DBName.MessageDB, list[i].ID);
                    //    DBContactor.SetPassword(DBContactor.DBName.MessageDB, list[i].PASSWORD);
                    //    DBContactor.SetName(DBContactor.DBName.MessageDB, list[i].NAME);
                    //    DBContactor.SetPort(DBContactor.DBName.MessageDB, list[i].PORT);
                    //    DBContactor.SetDBInformation(DBContactor.DBName.MessageDB);
                    //}
                    // QR
                    else if (list[i].ITEM == 2)
                    {
                        DBContactor.SetIP(DBContactor.DBName.QRDB, list[i].IP);
                        DBContactor.SetID(DBContactor.DBName.QRDB, list[i].ID);
                        DBContactor.SetPassword(DBContactor.DBName.QRDB, list[i].PASSWORD);
                        DBContactor.SetName(DBContactor.DBName.QRDB, list[i].NAME);
                        DBContactor.SetPort(DBContactor.DBName.QRDB, list[i].PORT);
                        DBContactor.SetDBInformation(DBContactor.DBName.QRDB);
                    }
                    //// FTP
                    //else if (list[i].ITEM == 3)
                    //{

                    //    MotionChart.Common.FTPFileClass.Ftp_ = list[i].IP;
                    //    MotionChart.Common.FTPFileClass.id_ = list[i].ID;
                    //    MotionChart.Common.FTPFileClass.pw_ = list[i].PASSWORD;
                    //}
                    // COMMON
                    //else 
                    else if (list[i].ITEM == 4)
                    {
                        DBContactor.SetIP(DBContactor.DBName.CommonDB, list[i].IP);
                        DBContactor.SetID(DBContactor.DBName.CommonDB, list[i].ID);
                        DBContactor.SetPassword(DBContactor.DBName.CommonDB, list[i].PASSWORD);
                        DBContactor.SetName(DBContactor.DBName.CommonDB, list[i].NAME);
                        //ClsMotionDB.DB_Name = list[i].NAME;
                        DBContactor.SetPort(DBContactor.DBName.CommonDB, list[i].PORT);
                        DBContactor.SetDBInformation(DBContactor.DBName.CommonDB);
                    }
                }
            }
        }
        #endregion
    }

    public class DBInfomation
    {
        #region Define
        private const string Charset = "utf8mb4";
        private const bool UseConvertZeroDateTime = true;
        private const bool UseAllowUserVariables = true;
        #endregion

        #region Field
        private string m_IP;
        private string m_ID;
        private string m_Password;
        private string m_DBName;
        private int m_Port;
        #endregion

        #region Constructor
        public DBInfomation() { }
        #endregion

        #region Property
        public string IP
        {
            get { return m_IP; }
            set { this.m_IP = value; }
        }

        public string ID
        {
            get { return m_ID; }
            set { this.m_ID = value; }
        }

        public string Password
        {
            get { return m_Password; }
            set { this.m_Password = value; }
        }
        public string DBName
        {
            get { return m_DBName; }
            set { this.m_DBName = value; }
        }
        public int Port
        {
            get { return m_Port; }
            set { this.m_Port = value; }
        }
        #endregion

        #region Method
        public virtual string MakeConn()
        {
            string str = "";
            string ip = tProtectedData.UnProtect(this.IP);
            string id = tProtectedData.UnProtect(this.ID);
            string passworkd = tProtectedData.UnProtect(this.Password);
            string name = tProtectedData.UnProtect(this.DBName);
            int port = this.Port;
            //str = tProtectedData.UnProtect(this.IP);

            //str = $"server={tProtectedData.UnProtect(this.IP)};UserId={tProtectedData.UnProtect(this.ID)};password={tProtectedData.UnProtect(this.Password)};
            //database={tProtectedData.UnProtect(this.DBName)};port={this.Port};charset={DBInfomation.Charset};convert zero datetime={DBInfomation.UseConvertZeroDateTime};
            //Allow User Variables={DBInfomation.UseAllowUserVariables};";

            str = $"server={ip};UserId={id};password={passworkd};database={name};port={port};charset={DBInfomation.Charset};convert zero datetime={DBInfomation.UseConvertZeroDateTime};Allow User Variables={DBInfomation.UseAllowUserVariables};SSLMODE=NONE";

            return str;
        }
        #endregion
    }
}
