using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LadyBelle.Function;
using System.Text;
namespace LadyBelle
{
    public partial class ManageUser : System.Web.UI.Page
    {
        connection con = new connection();
        private UserFunction user = new UserFunction();
        private UserLevelFunction userLevel = new UserLevelFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            con.OpenConnection();
            CheckSession();
            if (!IsPostBack)
            {
                trCreate.Visible = true;
                txtUserName.Enabled = true;
                trUpdate.Visible = false;
                BindData();
            }
        }

        private void BindData()
        {
            dgList.DataSource = user.GetData(con.cn);
            dgList.DataBind();

            cmbUserLevel.DataSource = userLevel.GetData(con.cn);
            cmbUserLevel.DataTextField = "LevelName";
            cmbUserLevel.DataValueField = "LevelID";
            cmbUserLevel.DataBind();
            cmbUserLevel.Items.Insert(0, "");
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
            txtUserName.Enabled = true;
            trCreate.Visible = true;
            trUpdate.Visible = false;
        }

        protected void dgList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "id")
            {
                txtUserID.Text = e.Item.Cells[3].Text.Trim();
                txtUserName.Text = e.Item.Cells[4].Text.Trim();
                txtPassword.Text = e.Item.Cells[1].Text.Trim();
                cmbUserLevel.SelectedValue = e.Item.Cells[5].Text.Trim();
            }
            txtUserID.Enabled = false;
            txtUserName.Enabled = false;
            trUpdate.Visible = true;
            trCreate.Visible = false;
        }

        protected void cmdCreate_Click(object sender, EventArgs e)
        {
            bool checkExist = user.CheckExist(con.cn, txtUserName.Text);
            if (checkExist == true)
            {
                ShowPopUpMsg("Username already exist");
            }
            else
            {
                user.SaveData(con.cn, txtUserName.Text, txtPassword.Text, Convert.ToInt32(cmbUserLevel.SelectedValue));
                BindData();
                Reset();
                ShowPopUpMsg("Save Success");
            }
           
        }

        protected void cmdCancel_1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void cmdDelete_Click(object sender, EventArgs e)
        {
            user.DeleteData(con.cn, Convert.ToInt32(txtUserID.Text));
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

        protected void cmdCancelUpdate_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void cmbUpdateUser_Click(object sender, EventArgs e)
        {
            user.UpdateData(con.cn, Convert.ToInt32(txtUserID.Text), txtPassword.Text, Convert.ToInt32(cmbUserLevel.SelectedValue));
            BindData();
            Reset();
            ShowPopUpMsg("Update Success");
        }

        private void CheckSession()
        {
            if ( Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Session["user"].ToString() == string.Empty)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}