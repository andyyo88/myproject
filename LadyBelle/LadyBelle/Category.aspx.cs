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
    public partial class WebForm2 : System.Web.UI.Page
    {
        connection con = new connection();
        private CategoryFunction category = new CategoryFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            con.OpenConnection();
            CheckSession();
            if (!IsPostBack)
            {
                trCreate.Visible = true;
                trUpdate.Visible = false;
                BindData();
                if (cmbCategoryType.SelectedValue == "0")
                {
                    cmbParent.SelectedIndex = 0;
                    cmbParent.Enabled = false;
                }
                else
                {

                    cmbParent.Enabled = true;
                }
            }
        }

        private void BindData()
        {
            dgList.DataSource = category.GetData(con.cn);
            dgList.DataBind();

            cmbParent.DataSource = category.GetData(con.cn);
            cmbParent.DataTextField = "CategoryName";
            cmbParent.DataValueField = "CategoryID";
            cmbParent.DataBind();
            cmbParent.Items.Insert(0, "");
        }

        protected void cmbCategoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategoryType.SelectedValue == "0")
            {
                cmbParent.SelectedIndex = 0;
                cmbParent.Enabled = false;
            }
            else
            {

                cmbParent.Enabled = true;
            }
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
            txtCategoryID.Text = "";
            txtCategoryName.Text = "";
            cmbCategoryType.SelectedIndex = 0;
            cmbParent.SelectedIndex = 0;
            txtCategoryID.Enabled = false;
            trCreate.Visible = true;
            trUpdate.Visible = false;
        }

        protected void dgList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName == "id")
            {
                txtCategoryID.Text = e.Item.Cells[4].Text.Trim();
                txtCategoryName.Text = e.Item.Cells[1].Text.Trim();
                cmbCategoryType.SelectedValue = e.Item.Cells[2].Text.Trim();
                if (cmbCategoryType.SelectedValue == "0")
                {
                    cmbParent.SelectedIndex = 0;
                    cmbParent.Enabled = false;
                }
                else
                {
                    if (e.Item.Cells[5].Text.Trim()=="0")
                    {
                        cmbParent.SelectedValue = "";
                    }
                    else
                    {
                        cmbParent.SelectedValue = e.Item.Cells[5].Text.Trim();
                        cmbParent.Enabled = true;  
                    }
                    
                }

            }
            txtCategoryID.Enabled = false;
            trUpdate.Visible = true;
            trCreate.Visible = false;
        }

        protected void cmdCreate_Click(object sender, EventArgs e)
        {
            string parentId = "0";
            if (cmbParent.SelectedValue != "")
            {
                parentId = cmbParent.SelectedValue;
            }
            category.SaveData(con.cn, txtCategoryName.Text, Convert.ToInt32(cmbCategoryType.SelectedValue), Convert.ToInt32(parentId));
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
            string parentId = "0";
            if (cmbParent.SelectedValue != "")
            {
                parentId = cmbParent.SelectedValue;
            }
            category.UpdateData(con.cn, Convert.ToInt32(txtCategoryID.Text), txtCategoryName.Text, Convert.ToInt32(cmbCategoryType.SelectedValue), Convert.ToInt32(parentId));
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
            category.DeleteData(con.cn, Convert.ToInt32(txtCategoryID.Text));
            BindData();
            Reset();
            ShowPopUpMsg("Delete Success");
        }
    }
}