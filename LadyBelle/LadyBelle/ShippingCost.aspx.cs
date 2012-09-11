using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LadyBelle.Function;

namespace LadyBelle
{
    public partial class ShippingCost : System.Web.UI.Page
    {
        connection con = new connection();
        private ShippingCostFunction shippingCost = new ShippingCostFunction();
        private ShippingVendorFunction shippingVendor  = new ShippingVendorFunction();
        private DistrictFunction district = new DistrictFunction();
        private CityFunction city = new CityFunction();
        private ProvinceFunction province = new ProvinceFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            con.OpenConnection();
            CheckSession();
            if (!IsPostBack)
            {
                trCreate.Visible = true;
                trUpdate.Visible = false;
                BindData();
            }
        }

        private void BindData()
        {
            dgList.DataSource = shippingCost.GetData(con.cn);
            dgList.DataBind();

            cmbShippingVendor.DataSource = shippingVendor.GetData(con.cn);
            cmbShippingVendor.DataTextField = "VendorName";
            cmbShippingVendor.DataValueField = "VendorID";
            cmbShippingVendor.DataBind();
            cmbShippingVendor.Items.Insert(0, "");

            cmbProvince.DataSource = province.GetData(con.cn);
            cmbProvince.DataTextField = "ProvinceName";
            cmbProvince.DataValueField = "ProvinceID";
            cmbProvince.DataBind();
            cmbProvince.Items.Insert(0, "");
        }

        private void BindCity()
        {
            cmbCity.DataSource = city.GetDataByProvince(con.cn, Convert.ToInt32(cmbProvince.SelectedValue)); ;
            cmbCity.DataTextField = "CityName";
            cmbCity.DataValueField = "CityID";
            cmbCity.DataBind();
            cmbCity.Items.Insert(0, "");
        }

        private void BindDistrict()
        {
            cmbDistrict.DataSource = district.GetDataByCity(con.cn, Convert.ToInt32(cmbCity.SelectedValue)); ;
            cmbDistrict.DataTextField = "DistrictName";
            cmbDistrict.DataValueField = "DistrictID";
            cmbDistrict.DataBind();
            cmbDistrict.Items.Insert(0, "");
        }

        private void CheckSession()
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Session["user"].ToString() == string.Empty)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void dgList_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgList.CurrentPageIndex = e.NewPageIndex;
            BindData();
            Reset();
        }

        private void Reset()
        {
            txtShippingCostID.Text = "";
            txtPrice.Text = "";
            cmbShippingVendor.SelectedIndex = 0;
            cmbProvince.SelectedIndex = 0;
            cmbCity.SelectedIndex = 0;
            cmbDistrict.SelectedIndex = 0;
            txtShippingCostID.Enabled = false;
            trCreate.Visible = true;
            trUpdate.Visible = false;
        }

        protected void dgList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "id")
            {
                txtShippingCostID.Text = e.Item.Cells[4].Text.Trim();
                txtPrice.Text = e.Item.Cells[3].Text.Trim();
                cmbShippingVendor.SelectedValue = e.Item.Cells[5].Text.Trim();
                cmbProvince.SelectedValue = e.Item.Cells[8].Text.Trim();
                BindCity();
                cmbCity.SelectedValue = e.Item.Cells[7].Text.Trim();
                BindDistrict();
                cmbDistrict.SelectedValue = e.Item.Cells[6].Text.Trim();
            }
            txtShippingCostID.Enabled = false;
            trUpdate.Visible = true;
            trCreate.Visible = false;
        }

        protected void cmdCreate_Click(object sender, EventArgs e)
        {
            shippingCost.SaveData(con.cn, Convert.ToInt32(cmbShippingVendor.SelectedValue), Convert.ToInt32(cmbDistrict.SelectedValue), Convert.ToDecimal(txtPrice.Text));
            BindData();
            Reset();
            ShowPopUpMsg("Save Success");
        }

        private void ShowPopUpMsg(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert('");
            sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'"));
            sb.Append("');");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", sb.ToString(), true);
        }

        protected void cmdCancel_1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            shippingCost.UpdateData(con.cn, Convert.ToInt32(txtShippingCostID.Text), Convert.ToInt32(cmbShippingVendor.SelectedValue), Convert.ToInt32(cmbDistrict.SelectedValue), Convert.ToDecimal(txtPrice.Text));
            BindData();
            Reset();
            ShowPopUpMsg("Update Success");
        }

        protected void cmdCancelUpdate_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void cmdDelete_Click(object sender, EventArgs e)
        {
            shippingCost.DeleteData(con.cn, Convert.ToInt32(txtShippingCostID.Text));
            BindData();
            Reset();
            ShowPopUpMsg("Delete Success");
        }

        protected void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();
        }

        protected void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDistrict();
        }
    }
}