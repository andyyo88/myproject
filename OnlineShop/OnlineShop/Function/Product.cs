using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADODB;
namespace OnlineShop
{
    public class Product
    {
        private connection conn = new connection();
        public void insertTest (ADODB.Connection cn)
        {
            string sql = "insert into users values('a','b',2)";
            conn.ExecuteQuery(sql,cn);

        }
        
        public System.Data.DataTable selectTest(ADODB.Connection cn)
        {

            string sql = "select * from users";
            System.Data.DataTable dt = conn.ExecuteScalar(sql, cn);

            return dt;

        }
        public ADODB.Recordset selectTest2(ADODB.Connection cn)
        {

            string sql = "select top 1 * from users";
            var rs5 = conn.Execute(sql, cn);

            return rs5;

        }
    }
}