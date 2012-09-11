using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LadyBelle.Function;
using System.Data;
using System.Text;
namespace LadyBelle
{
    public partial class AdminStock : System.Web.UI.Page
    {
        public connection conn = new connection();
        public Product products = new Product();
        protected void Page_Load(object sender, EventArgs e)
        {
            string productdetid = "";
            try
            {
                 productdetid = Request.QueryString["productdetid"].ToString();
            }
            catch
            {
                Response.Redirect("AdminProduct.aspx");
            }
            conn.OpenConnection();
            DataTable dtProduct = products.getProductDetList(productdetid, "ProductDetID", conn.cn);
            lbProductDetID.Text = dtProduct.Rows[0].ItemArray[0].ToString();
            lbProductName.Text = dtProduct.Rows[0].ItemArray[11].ToString();


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
        private string validateInput()
        {
            string msg = "";
            return msg;
        }
        protected void btAdd_Click(object sender, EventArgs e)
        {
              string msg = validateInput();
              if (msg.Equals(""))
              {
                  products.modifyProductStock(lbProductDetID.Text, txLong.Text, txShort.Text, DateTime.Now.ToString(), "1", txNote.Text, "", DateTime.Now.ToString(), conn.cn);
                  ShowPopUpMsg("Success", "AdminStockList.aspx");
              }
              else
              {
                  ShowPopUpMsg(msg, "");
              }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminStockList.aspx");
        }
    }
}