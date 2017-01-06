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
    public class PersonalInfoDBAccess
    {
        public bool Insert(PersonInfo personalInfo)
        {
            SqlParameter[] parameters = new SqlParameter[]
            { 
                new SqlParameter("@Id", personalInfo.Id),
                new SqlParameter("@Name", personalInfo.Name),
                new SqlParameter("@Program", personalInfo.Program)
            };

            return SqlDBHelper.ExecuteNonQuery("PersonalInfoInsert", CommandType.StoredProcedure, parameters);
        }

        public bool Update(PersonInfo personalInfo)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", personalInfo.Id),
                new SqlParameter("@Name", personalInfo.Name),
                new SqlParameter("@Program", personalInfo.Program)
            };

            return SqlDBHelper.ExecuteNonQuery("PersonalInfoUpdate", CommandType.StoredProcedure, parameters);
        }

        public bool DeleteById(int id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            };

            return SqlDBHelper.ExecuteNonQuery("PersonalInfoDeleteById", CommandType.StoredProcedure, parameters);
        }

        public PersonInfo GetById(int id)
        {
            PersonInfo personalInfo = null;

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            };
            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("PersonalInfoGetById", CommandType.StoredProcedure, parameters))
            {
                //check if any record exist or not
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];

                    //Lets go ahead and create the list of employees
                    personalInfo = new PersonInfo();

                    //Now lets populate the employee details into the list of employees                                           
                    personalInfo.Id = Convert.ToInt32(row["Id"]);
                    personalInfo.Name = row["Name"].ToString();
                    personalInfo.Program = row["Program"].ToString();
                }
            }

            return personalInfo;
        }

        public List<PersonInfo> GetAll()
        {
            List<PersonInfo> personalInfoList = null;

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("PersonalInfoGetAll", CommandType.StoredProcedure))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    personalInfoList = new List<PersonInfo>();

                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table.Rows)
                    {
                        PersonInfo personalInfo = new PersonInfo();
                        personalInfo.Id = Convert.ToInt32(row["Id"]);
                        personalInfo.Name = row["Name"].ToString();
                        personalInfo.Program = row["Program"].ToString();

                        personalInfoList.Add(personalInfo);
                    }
                }
            }

            return personalInfoList;
        }        
    }
}
