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
    public partial class AdminStockList : System.Web.UI.Page
    {
        public   connection conn = new connection();
        public Product products = new Product();
        public DataTable dtProduct = new DataTable();
        public DataTable dtProductDet = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.OpenConnection();
            string search = "Search";
            if (txSearch.Text.Equals(""))
                search = "";
            dtProduct = products.getProductList(txSearch.Text, search, conn.cn);
        }

        public int stockCount(string ProductDetID)
        {
            return products.getStockCount(ProductDetID, conn.cn);
        }


        public DataTable getProduct (string ProductID)
        {
            return products.getProductDetList(ProductID, "ProductID", conn.cn);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //dtProduct = products.getProductList(txSearch.Text, "Search", conn.cn);
        }
    }
}