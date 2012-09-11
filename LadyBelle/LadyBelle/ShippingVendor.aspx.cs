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
    public partial class ShippingVendor : System.Web.UI.Page
    {
        connection con = new connection();
        private ShippingVendorFunction shippingVendor = new ShippingVendorFunction();
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
            dgList.DataSource = shippingVendor.GetData(con.cn);
            dgList.DataBind();
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
            txtVendorID.Text = "";
            txtVendorName.Text = "";
            txtVendorID.Enabled = false;
            trCreate.Visible = true;
            trUpdate.Visible = false;
        }

        protected void dgList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "id")
            {
                txtVendorID.Text = e.Item.Cells[2].Text.Trim();
                txtVendorName.Text = e.Item.Cells[1].Text.Trim();
            }
            txtVendorID.Enabled = false;
            trUpdate.Visible = true;
            trCreate.Visible = false;
        }

        protected void cmdCreate_Click(object sender, EventArgs e)
        {
            shippingVendor.SaveData(con.cn, txtVendorName.Text);
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
            shippingVendor.UpdateData(con.cn, Convert.ToInt32(txtVendorID.Text), txtVendorName.Text);
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
            shippingVendor.DeleteData(con.cn, Convert.ToInt32(txtVendorID.Text));
            BindData();
            Reset();
            ShowPopUpMsg("Delete Success");
        }
    }
}