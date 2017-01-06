using LogicLayer.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicLayer.BussinessObject;

namespace TestWebSolution
{
    public partial class InsertPersonalInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string program = txtProgram.Text;
            PersonalInfoHandler personalInfoHandler = new PersonalInfoHandler();
            PersonInfo personinfo = new PersonInfo();
            personinfo.Name = name;
            personinfo.Program = program;
            if(personalInfoHandler.Insert(personinfo))
            {
                status.Text = "Sucess";
                txtName.Text = "";
                txtProgram.Text = "";
            }


        }
    }
}