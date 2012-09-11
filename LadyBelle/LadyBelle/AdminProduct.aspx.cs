using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LadyBelle.Function;
using System.Text;
using System.Data;
namespace LadyBelle
{
    public partial class AdminProduct : System.Web.UI.Page
    {
        connection conn = new connection();
        Product products = new Product();
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.OpenConnection();
            bindData();
        }

        private void bindData()
        {
            DataTable dtProduct = products.getProductList("", "", conn.cn);
            dgList.DataSource = dtProduct;
            dgList.DataBind();
        }

        public string getLogoURL(string path)
        {
            return products.GetImageURL(path);
        }
    }
}