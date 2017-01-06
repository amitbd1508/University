using LogicLayer.BussinessObject;
using LogicLayer.DataLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.BusinessLogic
{
    public class PersonalInfoHandler
    {
        // Handle to the Employee DBAccess class
        PersonalInfoDBAccess personalInfoDb = null;

        public PersonalInfoHandler()
        {
            personalInfoDb = new PersonalInfoDBAccess();
        }

        // This fuction does not contain any business logic, it simply returns the 
        // list of employees, we can put some logic here if needed
        public bool Insert(PersonInfo personalInfo)
        {
            return personalInfoDb.Insert(personalInfo);
        }

        // This fuction does not contain any business logic, it simply returns the 
        // list of employees, we can put some logic here if needed
        public bool Update(PersonInfo personalInfo)
        {
            return personalInfoDb.Update(personalInfo);
        }

        // This fuction does not contain any business logic, it simply returns the 
        // list of employees, we can put some logic here if needed
        public bool DeleteById(int id)
        {
            return personalInfoDb.DeleteById(id);
        }

        // This fuction does not contain any business logic, it simply returns the 
        // list of employees, we can put some logic here if needed
        public PersonInfo GetById(int id)
        {
            return personalInfoDb.GetById(id);
        }

        // This fuction does not contain any business logic, it simply returns the 
        // list of employees, we can put some logic here if needed
        public List<PersonInfo> GetAll()
        {
            return personalInfoDb.GetAll();
        }        
    }
}
