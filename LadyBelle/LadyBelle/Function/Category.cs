using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ADODB;

namespace LadyBelle.Function
{
    public class CategoryFunction
    {
        private connection conn = new connection();
        public DataTable GetData(Connection cn)
        {
            string sql = "ad_GetCategory";
            System.Data.DataTable dt = conn.ExecuteScalar(sql, cn);
            return dt;
        }

        public DataTable GetDataByParentID(Connection cn, int parentID)
        {
            string sql = "ad_GetCategoryByParentID " + parentID;
            System.Data.DataTable dt = conn.ExecuteScalar(sql, cn);
            return dt;
        }

        public Recordset GetDataByID(Connection cn, int id)
        {
            string sql = "ad_GetCategoryByID " + id;
            Recordset rs = conn.Execute(sql, cn);

            return rs;
        }

        public void SaveData(Connection cn, string categoryName, int categoryType, int parentID)
        {
            string sql = "ad_InsertCategory '" + categoryName + "'," + categoryType + "," + parentID;
            conn.ExecuteQuery(sql, cn);
        }

        public void UpdateData(Connection cn, int id, string categoryName,  int categoryType, int parentID)
        {
            string sql = "ad_UpdateCategory " + id + ",'" + categoryName + "'," + categoryType + "," + parentID;
            conn.ExecuteQuery(sql, cn);
        }

        public void DeleteData(Connection cn, int id)
        {
            string sql = "ad_DeleteCategory " + id;
            conn.ExecuteQuery(sql, cn);
        }

        public DataTable getCategoryByID(string id,string where, Connection cn)
        {
            string sql = "getCategoryByID_rd '" + id + "','" + where + "'";
            return conn.ExecuteScalar(sql, cn);
        }
    }
}