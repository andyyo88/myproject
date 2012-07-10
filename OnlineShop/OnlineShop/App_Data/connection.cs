using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ADODB;

namespace OnlineShop
{
    public class connection
    {
      public ADODB.Connection cn = new ADODB.Connection();
      public  ADODB.Command cmd = new ADODB.Command();
     public  ADODB.Recordset rs = new ADODB.Recordset();
      
        public void OpenConnection()
        {
            string DatabaseName = "OnlineShop";
            string ServerName = ".";
            string ServerPassword = "adminsa";
            //string ServerUsername = "sa";
            //string Connection = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=" + DatabaseName + ";Data Source=" + ServerName;
            string Connection = "Provider=SQLOLEDB.1;Persist Security Info=False;User ID=sa;password=adminsa;Initial Catalog=" + DatabaseName + ";Data Source=" + ServerName;
            cn.Open(Connection, "", "", -1);

        }
       public void ExecuteQuery(string sql,ADODB.Connection cn2)
       {
           rs.Open(sql, cn2, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic, -1);

       }

        public System.Data.DataTable ExecuteScalar(string sql, ADODB.Connection cn2)
       {
           rs.Open(sql, cn2, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic, -1);
           System.Data.OleDb.OleDbDataAdapter ol = new System.Data.OleDb.OleDbDataAdapter();
           System.Data.DataTable dt = new System.Data.DataTable();
           ol.Fill(dt, rs);
           rs.Close();
           return dt;
       }

        public ADODB.Recordset Execute(string sql,ADODB.Connection cn2)
        {
            rs.Open(sql, cn2, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic, -1);
            return rs;
         }

        public void CloseConnection()
        {
            cn.Close();
        }
    }

}