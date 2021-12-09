using System;
using System.Collections.Generic;

#nullable disable

namespace EmployeesManagement.Core.DTOs
{
    public partial class Country
    {
        public Country()
        {
            Employees = new HashSet<Employee>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
