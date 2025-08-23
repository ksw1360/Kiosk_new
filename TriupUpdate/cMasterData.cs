using Kiosk.Class;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Kiosk.TriupUpdate
{
    public class cMasterData
    {
        private const string Charset = "utf8mb4";
        private const bool UseConvertZeroDateTime = true;
        private const bool UseAllowUserVariables = true;

        public static cMasterList GetMasterDB()
        {
            cMasterList list = new cMasterList();
            string con = $"Server=db-5hrh5.pub-cdb.ntruss.com;Port=3306;Database=MASTER_DB;Uid=cdbuser;Pwd=dV4s!tpvs^sqcu;charset={Charset};convert zero datetime={UseConvertZeroDateTime};Allow User Variables={UseAllowUserVariables};SSLMODE=NONE";

            string ConnectionString = con;
            string ykiho = Common.YKIHO;

            if (string.IsNullOrEmpty(ykiho))
            {
                ykiho = "22222222";
            }


            string Query = "SELECT ITEM ,IP ,ID ,PASSWORD ,PORT ,NAME ,USE_E ,USE_W FROM DB_INFO WHERE YKIHO = '" + ykiho + "'";

            try
            {
                using (MySqlConnection connect = new MySqlConnection(ConnectionString))
                {
                    connect.Open();

                    MySqlCommand cmd = new MySqlCommand(Query, connect);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    DataTable dt = ds.Tables[0];

                    foreach (DataRow row in dt.Rows)
                    {
                        list.Add(new cMasterItem
                        {
                            ITEM = Convert.ToInt32(row["ITEM"].ToString()),
                            IP = row["IP"].ToString(),
                            ID = row["ID"].ToString(),
                            PASSWORD = row["PASSWORD"].ToString(),
                            PORT = Convert.ToInt32((row["PORT"].ToString() != "") ? row["PORT"].ToString() : "0"),
                            NAME = row["NAME"].ToString(),
                            USE_E = Convert.ToInt32((row["USE_E"].ToString() != "") ? row["USE_E"].ToString() : "0"),
                            USE_W = Convert.ToInt32((row["USE_W"].ToString() != "") ? row["USE_W"].ToString() : "0"),
                        });
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return list;
        }
    }
}
