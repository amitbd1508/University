using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicLayer.BusinessLogic;
using LogicLayer.BussinessObject;
using TestSoftwareLab163;

namespace TestWebSolution
{
    public partial class DeleteEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PersonalInfoHandler ph = new PersonalInfoHandler();
                if(ph.DeleteById(PersonalInformationView.drowindex))
                {
                    try
                    {
                        Response.Redirect("PersonalInformationView.aspx");
                    }
                    catch { }
                }
            }
            

        }
    }
}