using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ADODB;

namespace LadyBelle.Function
{
    public class ShippingCostFunction
    {
        private connection conn = new connection();
        public DataTable GetData(Connection cn)
        {
            string sql = "ad_GetShippingCost";
            System.Data.DataTable dt = conn.ExecuteScalar(sql, cn);
            return dt;
        }

        public void SaveData(Connection cn, int vendorID,int districtID, decimal price)
        {
            string sql = "ad_InsertShippingCost " + vendorID + "," + districtID + "," + price;
            conn.ExecuteQuery(sql, cn);
        }

        public void UpdateData(Connection cn, int id, int vendorID,int districtID, decimal price)
        {
            string sql = "ad_UpdateShippingCost " + id + "," + vendorID + "," + districtID + "," + price;
            conn.ExecuteQuery(sql, cn);
        }

        public void DeleteData(Connection cn, int id)
        {
            string sql = "ad_DeleteShippingCost " + id;
            conn.ExecuteQuery(sql, cn);
        }
    }
}