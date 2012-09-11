using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ADODB;

namespace LadyBelle.Function
{
    public class DistrictFunction
    {
        private connection conn = new connection();
        public DataTable GetData(Connection cn)
        {
            string sql = "ad_GetDistrict";
            System.Data.DataTable dt = conn.ExecuteScalar(sql, cn);
            return dt;
        }

        public DataTable GetDataByCity(Connection cn, int cityID)
        {
            string sql = "ad_GetDistrictByCity " + cityID;
            System.Data.DataTable dt = conn.ExecuteScalar(sql, cn);
            return dt;
        }

        public void SaveData(Connection cn, string districtName, int cityID)
        {
            string sql = "ad_InsertDistrict '" + districtName + "'," + cityID;
            conn.ExecuteQuery(sql, cn);
        }

        public void UpdateData(Connection cn, int id, string districtName, int cityID)
        {
            string sql = "ad_UpdateDistrict " + id + ",'" + districtName + "'," + cityID;
            conn.ExecuteQuery(sql, cn);
        }

        public void DeleteData(Connection cn, int id)
        {
            string sql = "ad_DeleteDistrict " + id;
            conn.ExecuteQuery(sql, cn);
        }
    }
}