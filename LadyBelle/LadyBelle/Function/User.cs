using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ADODB;

namespace LadyBelle.Function
{
    public class UserFunction
    {
        private connection conn = new connection();

        public DataTable GetData(Connection cn)
        {
            string sql = "GetUser";
            System.Data.DataTable dt = conn.ExecuteScalar(sql, cn);
            return dt;
        }

        public void SaveData(Connection cn, string userName, string password, int userLevel)
        {
            string sql = "InsertUser '" + userName + "','" + password + "'," + userLevel;
            conn.ExecuteQuery(sql, cn);
        }

        public Recordset GetDataByUsername(Connection cn, string username)
        {
            string sql = "GetUserByUsername " + username;
            Recordset rs = conn.Execute(sql, cn);

            return rs;
        }

        public int GetUserLevel(Connection cn, string username)
        {
            var rs = GetDataByUsername(cn, username);
            int userLevel = rs.Fields["UserLevel"].Value;
            return userLevel;
        }

        public bool CheckExist(Connection cn, string username)
        {
            Recordset rs = GetDataByUsername(cn, username);
            if (rs.BOF == false)
            {

                return true;

            }
            else
            {

                return false;

            }
        }

        public void UpdateData(Connection cn, int id, string password, int userLevel)
        {
            string sql = "UpdateUser " + id + ",'" + password + "'," + userLevel;
            conn.ExecuteQuery(sql, cn);
        }

        public void DeleteData(Connection cn, int id)
        {
            string sql = "DeleteUser " + id;
            conn.ExecuteQuery(sql, cn);
        }

        public bool CheckLogin(Connection cn, string username, string password)
        {
           
            Recordset rs = GetDataByUsername(cn,username);
            if (rs.BOF == false)
            {
                string pass = rs.Fields["Password"].Value.ToString();
                if (pass == password)
                {

                    return true;
                }
                else
                {

                    return false;
                }

            }
            else
            {
                return false;
            }
        }
    }
}