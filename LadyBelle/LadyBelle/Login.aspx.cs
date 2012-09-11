using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LadyBelle.Function;
using System.Text;
namespace LadyBelle
{
  
    public partial class Login : System.Web.UI.Page
    {
        connection con = new connection();
        private UserFunction user = new UserFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            con.OpenConnection();
            Session["user"] = string.Empty;
        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            bool checkLogin = user.CheckLogin(con.cn, txtUserID.Text, txtPassword.Text);
            
            if (checkLogin == true)
            {
                int userLevel = user.GetUserLevel(con.cn, txtUserID.Text);
                if(userLevel==1)
                {
                    Session["user"] = txtUserID.Text;
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    txtMessage.Visible = true;
                    txtMessage.Text = "Access Denied!"; 
                }
            }
            else
            {
                txtMessage.Visible = true;
                txtMessage.Text = "Incorrect Username or Password";
            }
        }
    }
}