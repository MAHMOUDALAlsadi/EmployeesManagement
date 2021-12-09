using EmployeesManagement.Core.DTOs;
using EmployeesManagement.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeesManagement.Core.Contract
{
    public interface IEmployeesUseCase
    {
        Response AddEmployee(Request request);
        Response GetAllEmployees();
        Response UpdateEmployee(Request request);
        Response GetEmployeeById(int? id);
        Response DeleteEmployee(int? id);
    }
}
