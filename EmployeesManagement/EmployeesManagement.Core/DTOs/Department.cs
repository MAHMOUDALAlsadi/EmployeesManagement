using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeesManagement.Core.DTOs
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
