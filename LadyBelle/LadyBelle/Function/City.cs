using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ADODB;

namespace LadyBelle.Function
{
    public class CityFunction
    {
        private connection conn = new connection();
        public DataTable GetData(Connection cn)
        {
            string sql = "ad_GetCity";
            System.Data.DataTable dt = conn.ExecuteScalar(sql, cn);
            return dt;
        }

        public DataTable GetDataByProvince(Connection cn, int provinceID)
        {
            string sql = "ad_GetCityByProvince "+provinceID;
            System.Data.DataTable dt = conn.ExecuteScalar(sql, cn);
            return dt;
        }

        public void SaveData(Connection cn, string cityName, int provinceID)
        {
            string sql = "ad_InsertCity '" + cityName + "'," + provinceID;
            conn.ExecuteQuery(sql, cn);
        }

        public void UpdateData(Connection cn, int id, string cityName, int provinceID)
        {
            string sql = "ad_UpdateCity " + id + ",'" + cityName + "'," + provinceID;
            conn.ExecuteQuery(sql, cn);
        }

        public void DeleteData(Connection cn, int id)
        {
            string sql = "ad_DeleteCity " + id;
            conn.ExecuteQuery(sql, cn);
        }
    }
}