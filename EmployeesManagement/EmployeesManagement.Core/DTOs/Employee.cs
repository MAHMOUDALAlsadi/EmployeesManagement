using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeesManagement.Core.DTOs
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
        public string PhoneNumber { get; set; }
        public int CountryId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdateOn { get; set; }

        public virtual Country Country { get; set; }
        public virtual Department Department { get; set; }
    }
}
