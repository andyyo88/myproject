using System;
using System.Data;
using ADODB;

namespace LadyBelle.Function
{
    public class ProvinceFunction
    {
        private connection conn = new connection();
        public DataTable GetData(Connection cn)
        {
            string sql = "ad_GetProvince";
            System.Data.DataTable dt = conn.ExecuteScalar(sql, cn);
            return dt;
        }

        public void SaveData(Connection cn, string provinceName)
        {
            string sql = "ad_InsertProvince '" + provinceName + "'";
            conn.ExecuteQuery(sql, cn);
        }

        public void UpdateData(Connection cn, int id, string provinceName)
        {
            string sql = "ad_UpdateProvince " + id + ",'" + provinceName + "'";
            conn.ExecuteQuery(sql, cn);
        }

        public void DeleteData(Connection cn, int id)
        {
            string sql = "ad_DeleteProvince " + id;
            conn.ExecuteQuery(sql, cn);
        }
    }
}