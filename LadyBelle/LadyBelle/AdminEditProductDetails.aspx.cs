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
    public partial class AdminEditProductDetails : System.Web.UI.Page
    {
        connection conn = new connection();
        Product products = new Product();
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.OpenConnection();
            if(!IsPostBack) {
                reset();
          

            }
        }

        protected void btCancel2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminProduct.aspx");
        }

        protected void reset()
        {
            string productdetid = "";
            string productid = "";
            try
            {
                productid = Request.QueryString["productid"].ToString();
                lbProductID.Text = productid;
            }
            catch
            {
                Response.Redirect("~/AdminEditProduct.aspx?productid=" + productid);
            }
            try
            {
                productdetid = Request.QueryString["productdetid"].ToString();
            }
            catch { }
            hyImage.NavigateUrl = "~/AdminEditImage.aspx?productid=" + productid + "&productdetid=" + productdetid;     
            if (!productdetid.Equals(""))
            {
                DataTable dtProduct = products.getProductDetList(productdetid, "ProductDetID", conn.cn);
                
                lbProductDetID.Text = productdetid;
                lbProductID.Text = dtProduct.Rows[0].ItemArray[3].ToString();
                lbProductName.Text = dtProduct.Rows[0].ItemArray[11].ToString();
                txSubProductCode.Text = dtProduct.Rows[0].ItemArray[1].ToString();
                txSubProductName.Text = dtProduct.Rows[0].ItemArray[4].ToString();
                txPrice.Text = dtProduct.Rows[0].ItemArray[5].ToString();
                ddlStatus.Text = dtProduct.Rows[0].ItemArray[6].ToString();
                txWeight.Text = dtProduct.Rows[0].ItemArray[7].ToString();
                txSize.Text = dtProduct.Rows[0].ItemArray[8].ToString();
                txSatuan.Text = dtProduct.Rows[0].ItemArray[9].ToString();
                txDiscount.Text = dtProduct.Rows[0].ItemArray[10].ToString();
                DataTable dtImg = products.getProductImgList(productdetid, "ProductDetID", conn.cn);
                dgList.DataSource = dtImg;
                dgList.DataBind();
                trCreate.Visible = false;
                trUpdate.Visible = true;
            }
            else
            {
                lbProductDetID.Text = "";
                lbProductID.Text = productid;
                lbProductName.Text = products.getProductList(productid,"ProductID",conn.cn).Rows[0].ItemArray[2].ToString();
                txSubProductCode.Text = "";
                txSubProductName.Text = "";
                txPrice.Text = "0";
                ddlStatus.Text = "-1";
                txWeight.Text = "0";
                txSize.Text = "";
                txSatuan.Text = "";
                txDiscount.Text = "0";
                trCreate.Visible = true;
                trUpdate.Visible = false;
            }
        }
        protected void btCancel_Click(object sender, EventArgs e)
        {
            reset();
        }
        private string validateInput()
        {
            string msg = "";
            return msg;
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
        protected void btAdd_Click(object sender, EventArgs e)
        {
            string msg = validateInput();
            if (msg.Equals(""))
            {
             
                products.modifyProductDet(lbProductID.Text,txSubProductCode.Text,txSubProductName.Text,txPrice.Text,ddlStatus.SelectedValue.ToString(),txWeight.Text,txSize.Text,txSatuan.Text,txDiscount.Text,lbProductDetID.Text, conn.cn);
                ShowPopUpMsg("Success", "AdminEditProduct.aspx?productid=" + lbProductID.Text);
            }
            else
            {
                ShowPopUpMsg(msg, "");
            }
        }

        protected void btEdit_Click(object sender, EventArgs e)
        {
            string msg = validateInput();
            if (msg.Equals(""))
            {

                products.modifyProductDet(lbProductID.Text, txSubProductCode.Text, txSubProductName.Text, txPrice.Text, ddlStatus.SelectedValue.ToString(), txWeight.Text, txSize.Text, txSatuan.Text, txDiscount.Text, lbProductDetID.Text, conn.cn);
                ShowPopUpMsg("Success", "AdminEditProduct.aspx?productid=" + lbProductID.Text);
            }
            else
            {
                ShowPopUpMsg(msg, "");
            }
        }
    }
}