using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Kiosk.TriupUpdate
{
    class ClsMotionDB
    {
        #region 업데이트

        public static int GetUpdateHistory(string updateKind, string ftpServer, string nowVersion, out List<UpdateHistoryInfo> items, string frDate = "", string toDate = "")
        {
            int ret = 0;

            items = new List<UpdateHistoryInfo>();
            StringBuilder sb = new StringBuilder();
            DataTable table = null;
            UpdateHistoryInfo item;

            sb.AppendLine($"SELECT a.UPDATE_VERSION");
            //sb.AppendLine($"     , a.SEQ");
            sb.AppendLine($"     , ROW_NUMBER() OVER(ORDER BY a.UPDATE_VERSION DESC, a.SEQ) AS SEQ");
            sb.AppendLine($"     , a.UPDATE_KIND");
            sb.AppendLine($"     , GROUP_CONCAT(a.UPDATE_CONTENT SEPARATOR '||') AS UPDATE_CONTENT");
            //sb.AppendLine($"     , a.UPDATE_DT");
            sb.AppendLine($"     , DATE_FORMAT(a.UPDATE_DT, '%Y.%m.%d') AS UPDATE_DT");
            sb.AppendLine($"  FROM KIOSK_UPDATE a");
            sb.AppendLine($" WHERE a.UPDATE_KIND = '{updateKind}'");
            sb.AppendLine($"   AND FTP_SERVER = '{ftpServer}'");
            if (!string.IsNullOrEmpty(nowVersion))
                sb.AppendLine($" AND UPDATE_VERSION > '{nowVersion}'");
            if (!string.IsNullOrEmpty(frDate) && !string.IsNullOrEmpty(toDate))
                sb.AppendLine($" AND DATE(UPDATE_DT) BETWEEN '{frDate}' AND '{toDate}'");
            sb.AppendLine($" GROUP BY a.UPDATE_VERSION");
            sb.AppendLine($" ORDER BY a.UPDATE_VERSION DESC, a.SEQ");

            if ((ret = DBContactor.GetSQLResult(sb.ToString(), DBContactor.SQL_CONN_COMMON, out table)) != 0) return ret;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                item = new UpdateHistoryInfo();

                item.UPDATE_VERSION = table.Rows[i]["UPDATE_VERSION"].ToString();
                item.SEQ = Convert.ToInt32(table.Rows[i]["SEQ"]);
                item.UPDATE_KIND = table.Rows[i]["UPDATE_KIND"].ToString();
                item.UPDATE_CONTENT = table.Rows[i]["UPDATE_CONTENT"].ToString();
                item.UPDATE_DT = table.Rows[i]["UPDATE_DT"].ToString();

                items.Add(item);
            }

            return ret;
        }

        #endregion
    }
}
