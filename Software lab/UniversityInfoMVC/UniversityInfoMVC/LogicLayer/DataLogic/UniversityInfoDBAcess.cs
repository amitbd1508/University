using LogicLayer.BussinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DataLogic
{
   
    public class UniversityInfoDBAcess
    {
        public bool Insert(UniversityInfo personalInfo)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", personalInfo.Id),
                new SqlParameter("@Name", personalInfo.Name),
                new SqlParameter("@Details", personalInfo.Details)
            };

            return SqlDBHelper.ExecuteNonQuery("UniversityInfoInsert", CommandType.StoredProcedure, parameters);
        }

        

       

      

        public List<UniversityInfo> GetAll()
        {
            List<UniversityInfo> personalInfoList = null;

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("UniversityInfoGetAll", CommandType.StoredProcedure))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    personalInfoList = new List<UniversityInfo>();

                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table.Rows)
                    {
                        UniversityInfo personalInfo = new UniversityInfo();
                        personalInfo.Id = Convert.ToInt32(row["Id"]);
                        personalInfo.Name = row["Name"].ToString();
                        personalInfo.Details = row["Details"].ToString();

                        personalInfoList.Add(personalInfo);
                    }
                }
            }

            return personalInfoList;
        }
    }
}
