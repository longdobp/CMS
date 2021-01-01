using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class EmployeeDAL
    {
        private DbConnection ConnStr = new DbConnection();

        //Get All
        public IEnumerable<EmployeeListViewModel> GetAllEmployees()
        {
            List<EmployeeListViewModel> empList = new List<EmployeeListViewModel>();

            using (SqlConnection conn = new SqlConnection(ConnStr.MainconnectionString))
            {
                SqlCommand cmd = new SqlCommand("get_list_employee", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EmployeeListViewModel emp = new EmployeeListViewModel();
                    emp.employee_nr = dr["employee_nr"].ToString();
                    emp.name_l = dr["name_l"].ToString();
                    emp.sex_rcd = dr["sex_rcd"].ToString();
                    emp.phone_number = dr["phone_number"].ToString();
                    emp.email_business = dr["email_business"].ToString();
                    empList.Add(emp);
                }
                conn.Close();
            }
            return empList;
        }
    }
}