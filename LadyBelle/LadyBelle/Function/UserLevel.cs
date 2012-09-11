using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ADODB;

namespace LadyBelle.Function
{
    public class UserLevelFunction
    {
        private connection conn = new connection();
        public DataTable GetData(Connection cn)
        {
            string sql = "ad_GetUserLevel";
            System.Data.DataTable dt = conn.ExecuteScalar(sql, cn);
            return dt;
        }
    }
}