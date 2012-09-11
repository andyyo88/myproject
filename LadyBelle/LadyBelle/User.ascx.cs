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
    public partial class User : System.Web.UI.UserControl
    {
        connection con = new connection();
        private UserFunction user = new UserFunction(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            con.OpenConnection();
            if (!IsPostBack)
            {
                trCreate.Visible = true;
                trUpdate.Visible = false;
                BindData();
            }
        }

        private void BindData()
        {
            dgList.DataSource = user.GetData(con.cn);
            dgList.DataBind();
        }

        protected void dgList_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgList.CurrentPageIndex = e.NewPageIndex;
            BindData();
            Reset();
        }

        private void Reset()
        {
            txtUserID.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtUserID.Enabled = false;
            trCreate.Visible = true;
            trUpdate.Visible = false;
        }

        protected void dgList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "id")
            {
                txtUserID.Text = e.Item.Cells[3].Text.Trim();
                txtUserName.Text = e.Item.Cells[1].Text.Trim();
                txtPassword.Text = e.Item.Cells[2].Text.Trim();
            }
            txtUserID.Enabled = false;
            trUpdate.Visible = true;
            trCreate.Visible = false;
        }

        protected void cmdCreate_Click(object sender, EventArgs e)
        {
           
        }

        protected void cmdCancel_1_Click(object sender, EventArgs e)
        {
            Response.Redirect("User.aspx");
        }

        protected void cmdUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void cmdCancel_2_Click(object sender, EventArgs e)
        {

        }

        protected void cmdDelete_Click(object sender, EventArgs e)
        {

        }

        private void ShowPopUpMsg(string msg)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("alert('");
            sb.Append(msg.Replace("\n", "\\n").Replace("\r", "").Replace("'", "\\'"));
            sb.Append("');");
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "showalert", sb.ToString(), true);
        }

        protected void CallbackPanel_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            switch (e.Parameter.ToUpper())
            {
                case "SAVE":
                    DoSave();
                    break;
            }
        }

        private void DoSave()
        {
         
        }
    }
}