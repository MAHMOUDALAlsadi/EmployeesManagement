using EmployeesManagement.Core.DTOs;
using EmployeesManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagement.Core.Contract
{
    public interface IEmployeesRepository
    {
        bool AddEmployee(Employee employee);
        List<Employee> GetAllEmployees();
        bool UpdateEmployee(Employee employee);
        Employee GetEmployeeById(int id);
        bool DeleteEmployee(int id);
    }
}
