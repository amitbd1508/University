using LogicLayer.BussinessObject;
using LogicLayer.DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.BussinessLogic
{
    public class UniversityInfoHandler
    {
        // Handle to the Employee DBAccess class
        UniversityInfoDBAcess personalInfoDb = null;

        public UniversityInfoHandler()
        {
            personalInfoDb = new UniversityInfoDBAcess();
        }

        // This fuction does not contain any business logic, it simply returns the 
        // list of employees, we can put some logic here if needed
        public bool Insert(UniversityInfo personalInfo)
        {
            return personalInfoDb.Insert(personalInfo);
        }

        // This fuction does not contain any business logic, it simply returns the 
        // list of employees, we can put some logic here if needed
       

        // This fuction does not contain any business logic, it simply returns the 
        // list of employees, we can put some logic here if needed
        public List<UniversityInfo> GetAll()
        {
            return personalInfoDb.GetAll();
        }
    }
}
