using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LadyBelle.Function;
using System.IO;
using System.Text;
namespace LadyBelle
{
    public partial class SaveText : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string fullpath = "~/txt/" + tipe + ".txt";
            string text = "";
            if (!IsPostBack)
            {
                try
                {
                    StreamReader obj = new StreamReader(HttpContext.Current.Server.MapPath(fullpath));
                    text = obj.ReadToEnd();
                    obj.Close();
                    obj.Dispose();
                    ftb1.Text = text;
                }
                catch
                {

                }
            }
        }

        protected void btConfirm_Click(object sender, EventArgs e)
        {
            string fullpath = "~/txt/" + tipe + ".txt";
            DeleteText(fullpath);
            StreamWriter obj = new StreamWriter(HttpContext.Current.Server.MapPath(fullpath));
            obj.Write(ftb1.Text);
            obj.Close();
            obj.Dispose();
            ShowPopUpMsg("Update Sukses", "Home.aspx");
        }
        public void DeleteText(string fullpath)
        {
            if (System.IO.File.Exists(HttpContext.Current.Server.MapPath(fullpath)))
                System.IO.File.Delete(HttpContext.Current.Server.MapPath(fullpath));
        }
        private string tipeText = string.Empty;
        public string tipe
        {
            get { return tipeText; }
            set { tipeText = value; }
        }
        public string HeaderTextString = string.Empty;
        public string HeaderText
        {
            get { return HeaderTextString; }
            set { HeaderTextString = value; }
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

        protected void btCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

    }


}