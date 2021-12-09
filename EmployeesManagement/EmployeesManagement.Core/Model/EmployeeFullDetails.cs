using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManagement.Core.Model
{
    public class EmployeeFullDetails
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string DepartmentName { get; set; }
        public decimal Salary { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryName { get; set; }
    }
}
