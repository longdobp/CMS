using System;

namespace CMS.Models
{
    public class EmployeeVm
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public int Age { get; set; }
        public DateTime Start_date { get; set; }
        public Decimal Salary { get; set; }
    }
}