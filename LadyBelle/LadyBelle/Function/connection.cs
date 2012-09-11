using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ADODB;

namespace LadyBelle.Function
{
    public class connection
    {
        public ADODB.Connection cn = new ADODB.Connection();
        public ADODB.Command cmd = new ADODB.Command();
        public ADODB.Recordset rs = new ADODB.Recordset();
        public void OpenConnection()
        {
            string DatabaseName = "OnlineShop";
            string ServerName = "ELLY\\SQLEXPRESS";
            string ServerPassword = "adminsa";
            string ServerUsername = "sa";
            bool WindowsAuthentication = false;
            string Conn = "";
            if (WindowsAuthentication)
                Conn = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=" + DatabaseName + ";Data Source=" + ServerName;
            else
                Conn = "Provider=SQLOLEDB.1;Password=" + ServerPassword + ";Persist Security Info=True;User ID=" + ServerUsername + ";Initial Catalog=" + DatabaseName + ";Data Source=" + ServerName;
            cn.Open(Conn, "", "", -1);

        }
        public void ExecuteQuery(string sql, ADODB.Connection cn2)
        {
            if (rs.State == 1)
            {
                rs.Close();
            }
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

        public ADODB.Recordset Execute(string sql, ADODB.Connection cn2)
        {
            if (rs.State == 1)
            {
                rs.Close();
            }
            rs.Open(sql, cn2, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic, -1);
            return rs;
        }

        public void CloseConnection()
        {
            cn.Close();
        }

    }
}