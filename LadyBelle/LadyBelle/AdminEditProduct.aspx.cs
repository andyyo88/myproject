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
    public partial class AdminEditProduct : System.Web.UI.Page
    {
        connection conn = new connection();
        Product products = new Product();
        CategoryFunction cat = new CategoryFunction();
        private string userlogin = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.OpenConnection();
            if (!IsPostBack)
            {
                try
                {
                    lbProductID.Text = Request.QueryString["productid"].ToString();
                    trUpdate.Visible = true;
                    trCreate.Visible = false;
                    DataTable dt = products.getProductList(lbProductID.Text, "ProductID", conn.cn);
                    txProductCode.Text = dt.Rows[0].ItemArray[1].ToString();
                    txProductName.Text = dt.Rows[0].ItemArray[2].ToString();
                    txShortDesc.Text = dt.Rows[0].ItemArray[3].ToString();
                    hyNewSubProduct.NavigateUrl = "~/AdminEditProductDetails.aspx?productid=" + lbProductID.Text;
                    bindParentCat();
                    int ProductTypeID = int.Parse(dt.Rows[0].ItemArray[4].ToString());
                    DataTable ProductType = cat.getCategoryByID(ProductTypeID.ToString(),"CategoryID", conn.cn);
                    if (ProductType.Rows[0].ItemArray[2].ToString().Equals("0"))
                    {
                        ddlParentCat.Text = ProductTypeID.ToString();
                        bindSubCat();
                    }
                    else
                    {
                        DataTable ProductTypeChild = cat.getCategoryByID(int.Parse(ProductType.Rows[0].ItemArray[2].ToString()).ToString(),"CategoryID", conn.cn);
                        if (ProductTypeChild.Rows[0].ItemArray[2].ToString().Equals("0"))
                        {
                            ddlParentCat.Text = ProductType.Rows[0].ItemArray[2].ToString();
                            bindSubCat();
                            ddlSubCategory.Text = ProductTypeID.ToString();
                        }
                        else
                        {

                            ddlParentCat.Text = ProductTypeChild.Rows[0].ItemArray[2].ToString();
                            bindSubCat();
                            ddlSubCategory.Text = ProductType.Rows[0].ItemArray[2].ToString();
                            bindCat();
                            ddlCategory.Text = ProductTypeID.ToString();
                        }
                    }

                    bindGrid();
                }
                catch
                {
                    trUpdate.Visible = false;
                    trCreate.Visible = true;
                    hyNewSubProduct.Visible = false;
                    if (!IsPostBack)
                    {
                        bindParentCat();
                    }
                }
            
            }
        }

        private void bindParentCat()
        {
            ddlParentCat.DataSource = cat.getCategoryByID("0", "ParentID", conn.cn);
            ddlParentCat.DataTextField = "CategoryName";
            ddlParentCat.DataValueField = "CategoryID";
            ddlParentCat.DataBind();
            ddlParentCat.Items.Insert(0, "-Select Category-");
        }

        private void bindSubCat()
        {
            try
            {
                ddlSubCategory.DataSource = cat.getCategoryByID(ddlParentCat.SelectedValue, "ParentID", conn.cn);
                ddlSubCategory.DataTextField = "CategoryName";
                ddlSubCategory.DataValueField = "CategoryID";
                ddlSubCategory.DataBind();
                ddlSubCategory.Items.Insert(0, "-Select Category-");
            }
            catch
            {

            }
        }

        private void bindCat()
        {
            try
            {
                ddlCategory.DataSource = cat.getCategoryByID(ddlSubCategory.SelectedValue, "ParentID", conn.cn);
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, "-Select Category-");
            }
            catch { };
        }

        private void bindGrid()
        {
            dgList.DataSource = products.getProductDetList(lbProductID.Text, "ProductID", conn.cn);
            dgList.DataBind();
        }
        protected void ddlParentCat_TextChanged(object sender, EventArgs e)
        {
            bindSubCat();
        }

        protected void ddlSubCategory_TextChanged(object sender, EventArgs e)
        {
            bindCat();
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
                string categoryID = ddlParentCat.SelectedValue.ToString();
                if (ddlCategory.SelectedIndex < 1)
                    {
                if (ddlSubCategory.SelectedIndex < 1)
                    categoryID = ddlParentCat.SelectedValue.ToString();
                else
                    categoryID = ddlSubCategory.SelectedValue.ToString();
                 }
                else
                    categoryID = ddlCategory.SelectedValue.ToString();

                products.modifyProduct(txProductCode.Text, txProductName.Text, txShortDesc.Text, categoryID, lbProductID.Text,userlogin,conn.cn);
                ShowPopUpMsg("Success", "AdminProduct.aspx");
                }
            else
            {
                ShowPopUpMsg(msg,"");
            }
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

        protected void btCancel2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminProduct.aspx");
        }
        public string getLogoURL(string path)
        {
            return products.GetImageURL(path);
        }

        protected void btEdit_Click(object sender, EventArgs e)
        {
            string msg = validateInput();
            if (msg.Equals(""))
            {
                string categoryID = ddlParentCat.SelectedValue.ToString();
                if (ddlCategory.SelectedIndex < 1)
                {
                    if (ddlSubCategory.SelectedIndex < 1)
                        categoryID = ddlParentCat.SelectedValue.ToString();
                    else
                        categoryID = ddlSubCategory.SelectedValue.ToString();
                }
                else
                    categoryID = ddlCategory.SelectedValue.ToString();

                products.modifyProduct(txProductCode.Text, txProductName.Text, txShortDesc.Text, categoryID, lbProductID.Text, userlogin, conn.cn);
                ShowPopUpMsg("Success", "AdminProduct.aspx");
            }
            else
            {
                ShowPopUpMsg(msg, "");
            }
        }
        private void Reset()
        {
            trUpdate.Visible = true;
            trCreate.Visible = false;
            DataTable dt = products.getProductList(lbProductID.Text, "ProductID", conn.cn);
            txProductCode.Text = dt.Rows[0].ItemArray[1].ToString();
            txProductName.Text = dt.Rows[0].ItemArray[2].ToString();
            txShortDesc.Text = dt.Rows[0].ItemArray[3].ToString();

            bindParentCat();
            int ProductTypeID = int.Parse(dt.Rows[0].ItemArray[4].ToString());
            DataTable ProductType = cat.getCategoryByID(ProductTypeID.ToString(), "CategoryID", conn.cn);
            if (ProductType.Rows[0].ItemArray[2].ToString().Equals("0"))
            {
                ddlParentCat.Text = ProductTypeID.ToString();
                bindSubCat();
            }
            else
            {
                DataTable ProductTypeChild = cat.getCategoryByID(int.Parse(ProductType.Rows[0].ItemArray[2].ToString()).ToString(), "CategoryID", conn.cn);
                if (ProductTypeChild.Rows[0].ItemArray[2].ToString().Equals("0"))
                {
                    ddlParentCat.Text = ProductType.Rows[0].ItemArray[2].ToString();
                    bindSubCat();
                    ddlSubCategory.Text = ProductTypeID.ToString();
                    bindCat();
                }
                else
                {

                    ddlParentCat.Text = ProductTypeChild.Rows[0].ItemArray[2].ToString();
                    bindSubCat();
                    ddlSubCategory.Text = ProductType.Rows[0].ItemArray[2].ToString();
                    bindCat();
                    ddlCategory.Text = ProductTypeID.ToString();
                }
            }

        }
        protected void btCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btDelete_Click(object sender, EventArgs e)
        {

        }
    }
}