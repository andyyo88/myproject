using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ADODB;

namespace LadyBelle.Function
{
    public class ClientFunction
    {
        private connection conn = new connection();
        public DataTable GetData(Connection cn)
        {
            string sql = "ad_GetClient";
            System.Data.DataTable dt = conn.ExecuteScalar(sql, cn);
            return dt;
        }

        public Recordset GetDataByID(Connection cn, int ID)
        {
            string sql = "ad_GetClientByID " + ID;
            Recordset rs = conn.Execute(sql, cn);
            return rs;
        }

        public void SaveData(Connection cn, string clName, string username, string email, string address, int cityID, int provinceID, string postalCode, string phone, bool active, DateTime lastUpdate)
        {
            string sql = "ad_InsertClient '" + clName + "','" + username + "','" + email + "','" + address + "'," + cityID + "," + provinceID + ",'" + postalCode + "','" + phone + "'," + active + ",'" + lastUpdate + "'";
            conn.ExecuteQuery(sql, cn);
        }

        public void UpdateData(Connection cn, int id, string clName, string username, string email, string address, int cityID, int provinceID, string postalCode, string phone, bool active, DateTime lastUpdate)
        {
            string sql = "ad_UpdateClient " + id + ",'" + clName + "','" + username + "','" + email + "','" + address + "'," + cityID + "," + provinceID + ",'" + postalCode + "','" + phone + "'," + active + ",'" + lastUpdate + "'";
            conn.ExecuteQuery(sql, cn);
        }

        public void UpdateStatusByAdmin(Connection cn, int id, bool status,  DateTime lastUpdate)
        {
            string sql = "ad_UpdateClientStatusByAdmin " + id + "," + status + ",'" + lastUpdate + "'";
            conn.ExecuteQuery(sql, cn);
        }

        public void UpdateLevelByAdmin(Connection cn, int id, int level, string username)
        {
            string sql1 = "ad_UpdateClientLevelByAdmin " + id + "," + level + ",'" + username + "'";
            conn.ExecuteQuery(sql1, cn);
        }

        public void DeleteData(Connection cn, int id)
        {
            string sql = "ad_DeleteClient " + id;
            conn.ExecuteQuery(sql, cn);
        }

    }
}