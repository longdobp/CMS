using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Models
{
    public class EmployeeListViewModel
    {
        public string employee_nr { get; set; }
        public string name_l { get; set; }
        public string sex_rcd { get; set; }
        public string phone_number { get; set; }
        public string email_business { get; set; }
        public string emp_status_name_e { get; set; }
    }
}