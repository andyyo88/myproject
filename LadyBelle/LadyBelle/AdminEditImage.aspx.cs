using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LadyBelle.Function;
using System.Data;
using System.Text;
using LadyBelle.Function;
using System.Data;
using System.Text;
namespace LadyBelle
{
    public partial class AdminEditImage : System.Web.UI.Page
    {
        connection conn = new connection();
        Product products = new Product();
        public string productdetID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.OpenConnection();
            if (!IsPostBack)
            {
                try
                {
                    productdetID = Request.QueryString["productdetid"].ToString();
                    RefreshPict();

                }
                catch
                {
                    Response.Redirect("~/AdminProduct.aspx");
                }
            }
        }

        protected void RefreshPict()
        {
            productdetID = Request.QueryString["productdetid"].ToString();
            DataTable dtPic = products.getProductImgList(productdetID, "ProductDetID", conn.cn);
            int i = 0;
            while (i < dtPic.Rows.Count)
            {
                if (dtPic.Rows[i].ItemArray[3].ToString().Equals("1"))
                {
                    img1.ImageUrl = dtPic.Rows[i].ItemArray[2].ToString();
                }
                else if (dtPic.Rows[i].ItemArray[3].ToString().Equals("2"))
                {
                    img2.ImageUrl = dtPic.Rows[i].ItemArray[2].ToString();
                }
                else if (dtPic.Rows[i].ItemArray[3].ToString().Equals("3"))
                {
                    img3.ImageUrl = dtPic.Rows[i].ItemArray[2].ToString();
                }
                else if (dtPic.Rows[i].ItemArray[3].ToString().Equals("4"))
                {
                    img4.ImageUrl = dtPic.Rows[i].ItemArray[2].ToString();
                }
                i++;
            }
        }
        protected void changeImage(int order,FileUpload fu)
        {
            if (fu.HasFile)
            {
                productdetID = Request.QueryString["productdetid"].ToString();
                string fullpath = "~/images/" + productdetID + "_" + order.ToString() + System.IO.Path.GetExtension(fu.FileName);
                string path = Server.MapPath(fullpath);
                fu.SaveAs(path);
                products.modifyProductImg(productdetID, fullpath, order.ToString(),conn.cn);
            }
        }
        protected void btch1_Click(object sender, EventArgs e)
        {
            changeImage(1, FileUpload1);
            RefreshPict();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            changeImage(2, FileUpload2);
            RefreshPict();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            changeImage(3, FileUpload3);
            RefreshPict();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            changeImage(4, FileUpload4);
            RefreshPict();
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
        protected void btSave_Click(object sender, EventArgs e)
        {
            int i = 0;
            productdetID = Request.QueryString["productdetid"].ToString();
            i = int.Parse(tx1.Text) + int.Parse(tx2.Text) + int.Parse(tx3.Text) + int.Parse(tx4.Text);
            if (i == 10) {
                if (!tx1.Text.Equals("1"))
                {
                    products.changeOrderImage(productdetID, tx1.Text, img1.ImageUrl,conn.cn);
                }
                if (!tx2.Text.Equals("2"))
                {
                    products.changeOrderImage(productdetID, tx2.Text, img2.ImageUrl, conn.cn);
                }
                if (!tx3.Text.Equals("3"))
                {
                    products.changeOrderImage(productdetID, tx3.Text, img3.ImageUrl, conn.cn);
                }
                if (!tx4.Text.Equals("4"))
                {
                    products.changeOrderImage(productdetID, tx4.Text, img4.ImageUrl, conn.cn);
                }
                ShowPopUpMsg("Success", "AdminProduct.aspx");
            }
            else {
                ShowPopUpMsg("Something Wrong","");
            }
        }

        protected void btSave_Click1(object sender, EventArgs e)
        {
            productdetID = Request.QueryString["productdetid"].ToString();
            string productid = Request.QueryString["productid"].ToString();
            Response.Redirect("~/AdminEditProductDetails.aspx?productid=" + productid + "&productdetid=" + productdetID);
        }
    }
}