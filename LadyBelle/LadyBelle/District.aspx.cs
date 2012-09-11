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
    public partial class District : System.Web.UI.Page
    {
        connection con = new connection();
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
            dgList.DataSource = district.GetData(con.cn);
            dgList.DataBind();

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

        protected void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();
        }

        protected void dgList_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgList.CurrentPageIndex = e.NewPageIndex;
            BindData();
            Reset();
        }

        private void Reset()
        {
            txtDistrictID.Text = "";
            txtDistrictName.Text = "";
            cmbProvince.SelectedIndex = 0;
            cmbCity.SelectedIndex = 0;
            txtDistrictID.Enabled = false;
            trCreate.Visible = true;
            trUpdate.Visible = false;
        }

        protected void dgList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "id")
            {
                txtDistrictID.Text = e.Item.Cells[3].Text.Trim();
                txtDistrictName.Text = e.Item.Cells[1].Text.Trim();
                cmbProvince.SelectedValue = e.Item.Cells[5].Text.Trim();
                BindCity();
                cmbCity.SelectedValue = e.Item.Cells[4].Text.Trim();
            }
            txtDistrictID.Enabled = false;
            trUpdate.Visible = true;
            trCreate.Visible = false;
        }

        protected void cmdCreate_Click(object sender, EventArgs e)
        {
            district.SaveData(con.cn, txtDistrictName.Text, Convert.ToInt32(cmbCity.SelectedValue));
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
            district.UpdateData(con.cn, Convert.ToInt32(txtDistrictID.Text), txtDistrictName.Text, Convert.ToInt32(cmbCity.SelectedValue));
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
            district.DeleteData(con.cn, Convert.ToInt32(txtDistrictID.Text));
            BindData();
            Reset();
            ShowPopUpMsg("Delete Success");
        }
    }
}