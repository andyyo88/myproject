using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ADODB;

namespace LadyBelle.Function
{
    public class ShippingVendorFunction
    {
        private connection conn = new connection();
        public DataTable GetData(Connection cn)
        {
            string sql = "ad_GetShippingVendor";
            System.Data.DataTable dt = conn.ExecuteScalar(sql, cn);
            return dt;
        }

        public void SaveData(Connection cn, string vendorName)
        {
            string sql = "ad_InsertShippingVendor '" + vendorName + "'";
            conn.ExecuteQuery(sql, cn);
        }

        public void UpdateData(Connection cn, int id, string vendorName)
        {
            string sql = "ad_UpdateShippingVendor " + id + ",'" + vendorName + "'";
            conn.ExecuteQuery(sql, cn);
        }

        public void DeleteData(Connection cn, int id)
        {
            string sql = "ad_DeleteShippingVendor " + id;
            conn.ExecuteQuery(sql, cn);
        }
    }
}