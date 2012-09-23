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
    public partial class WebForm3 : System.Web.UI.Page
    {
        connection con = new connection();
        ClientFunction customer =new ClientFunction();
        UserLevelFunction customerLevel = new UserLevelFunction();
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
            dgList.DataSource = customer.GetData(con.cn);
            dgList.DataBind();

            cmbCustomerLevel.DataSource = customerLevel.GetData(con.cn);
            cmbCustomerLevel.DataTextField = "LevelName";
            cmbCustomerLevel.DataValueField = "LevelID";
            cmbCustomerLevel.DataBind();
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
            txtCustID.Text = "";
            txtCustName.Text = "";
            txtUsername.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtProvince.Text = "";
            txtPostalCode.Text = "";
            txtPhone.Text = "";
            cmbCustomerLevel.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            txtCustID.Enabled = false;
            trCreate.Visible = true;
            trUpdate.Visible = false;
        }

        protected void dgList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "id")
            {
                txtCustID.Text = e.Item.Cells[4].Text.Trim();
                var cust = customer.GetDataByID(con.cn, Convert.ToInt32(txtCustID.Text));
                txtUsername.Text = cust.Fields["username"].Value.ToString();
                txtCustName.Text = cust.Fields["ClName"].Value.ToString();
                txtEmail.Text = cust.Fields["Email"].Value.ToString();
                txtAddress.Text = cust.Fields["Address"].Value.ToString();
                txtCity.Text = cust.Fields["CityName"].Value.ToString();
                txtProvince.Text = cust.Fields["ProvinceName"].Value.ToString();
                txtPostalCode.Text = cust.Fields["PostalCode"].Value.ToString();
                txtPhone.Text = cust.Fields["Phone"].Value.ToString();
                cmbCustomerLevel.SelectedValue = cust.Fields["UserLevel"].Value.ToString();
                cmbStatus.SelectedValue = cust.Fields["Active"].Value.ToString();
            }
            txtCustID.Enabled = false;
            txtUsername.Enabled = false;
            txtCustName.Enabled = false;
            txtEmail.Enabled = false;
            txtAddress.Enabled = false;
            txtCity.Enabled = false;
            txtProvince.Enabled = false;
            txtPostalCode.Enabled = false;
            txtPhone.Enabled = false;
            trUpdate.Visible = true;
            trCreate.Visible = false;
        }

        protected void cmdCreate_Click(object sender, EventArgs e)
        {

        }

        protected void cmdCancel_1_Click(object sender, EventArgs e)
        {

        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {
            customer.UpdateLevelByAdmin(con.cn, Convert.ToInt32(txtCustID.Text), Convert.ToInt32(cmbCustomerLevel.SelectedValue), txtUsername.Text);
            customer.UpdateStatusByAdmin(con.cn, Convert.ToInt32(txtCustID.Text), Convert.ToBoolean(cmbStatus.SelectedValue), DateTime.Now);
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
            customer.DeleteData(con.cn, Convert.ToInt32(txtCustID.Text));
            BindData();
            Reset();
            ShowPopUpMsg("Delete Success");
        }

        private void ShowPopUpMsg(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert('");
            sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'"));
            sb.Append("');");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", sb.ToString(), true);
        }
    }
}