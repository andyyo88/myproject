using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace LadyBelle
{
    public partial class AdminAboutUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ShowPopUpMsg("Update Sukses", "Home.aspx");
        }
        private void ShowPopUpMsg(string msg, string location)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert('");
            sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'"));
            if (location.Equals(""))
                sb.Append("');");
            else
                sb.Append("');location.href = '" + location + "';");
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(this.GetType(), "showalert", sb.ToString(), true);
        }

    }
}