using LogicLayer.BusinessLogic;
using LogicLayer.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestSoftwareLab163
{
    public partial class PersonalInformationView : System.Web.UI.Page
    {
        public static int drowindex = -1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPersonalInfo();
            }
            drowindex = -1;
        }

        protected void LoadPersonalInfo()
        {
            try
            {
                PersonalInfoHandler personalInfoHandler = new PersonalInfoHandler();
                List<PersonInfo> personalInfoList = personalInfoHandler.GetAll();

                if (personalInfoList != null)
                {
                    gvPersonalInfo.DataSource = personalInfoList;
                    gvPersonalInfo.DataBind();
                }
                else
                {
                    gvPersonalInfo.DataSource = null;
                    gvPersonalInfo.DataBind();
                }
            }
            catch { }
        }

        protected void gvPersonalInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                gvPersonalInfo.EditIndex = e.NewEditIndex;
                LoadPersonalInfo();
            }
            catch { }
        }

        protected void gvPersonalInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                gvPersonalInfo.EditIndex = -1;
                LoadPersonalInfo();
            }
            catch { }
        }

        protected void gvPersonalInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label lblId = gvPersonalInfo.Rows[e.RowIndex].FindControl("txtId") as Label;

                TextBox txtName = gvPersonalInfo.Rows[e.RowIndex].FindControl("txtName") as TextBox;
                TextBox txtProgram = gvPersonalInfo.Rows[e.RowIndex].FindControl("txtProgram") as TextBox;


                if (lblId != null && txtName != null && txtProgram != null)
                {
                    PersonInfo personalInfo = new PersonInfo();

                    personalInfo.Id = Convert.ToInt32(lblId.Text);
                    personalInfo.Name = txtName.Text;
                    personalInfo.Program = txtProgram.Text;

                    //Let us now update the database
                    PersonalInfoHandler personalInfoHandler = new PersonalInfoHandler();
                    if (personalInfoHandler.Update(personalInfo) == true)
                    {
                        lblResult.Text = "Record Updated Successfully";
                    }
                    else
                    {
                        lblResult.Text = "Failed to Update record";
                    }

                    //end the editing and bind with updated records.
                    gvPersonalInfo.EditIndex = -1;
                    LoadPersonalInfo();
                }
            }
            catch { }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("InsertPersonalInformation.aspx");
            }
            catch { }
        }

        protected void gvPersonalInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            drowindex = e.RowIndex;
            lblResult.Text = Convert.ToString(drowindex);
        }

        protected void gvPersonalInfo_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            drowindex = e.AffectedRows;
            lblResult.Text = Convert.ToString(drowindex);
        }
    }
}