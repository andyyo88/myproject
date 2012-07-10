using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ADODB;
namespace OnlineShop
{
    public partial class _Default : System.Web.UI.Page
    {
        connection test = new connection();
        Product product = new Product();
        protected void Page_Load(object sender, EventArgs e)
        {
            test.OpenConnection();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var dt2 = new DataTable();
           
            System.Data.OleDb.OleDbDataAdapter ol = new System.Data.OleDb.OleDbDataAdapter();
            System.Data.DataTable dt = new System.Data.DataTable();
            ol.Fill(dt2, product.selectTest2(test.cn));
            gvProduct.DataSource = dt2;
            gvProduct.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var test3 = product.selectTest2(test.cn);
            Label1.Text = test3.Fields["username"].Value;
        }
    }
}
