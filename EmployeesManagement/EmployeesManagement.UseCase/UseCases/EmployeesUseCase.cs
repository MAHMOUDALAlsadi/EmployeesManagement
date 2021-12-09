using EmployeesManagement.Core.Contract;
using EmployeesManagement.Core.DTOs;
using EmployeesManagement.Core.Model;
using System;
using System.Collections.Generic;

namespace EmployeesManagement.UseCase.UseCases
{
    public class EmployeesUseCase : IEmployeesUseCase
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesUseCase(IRepositoryFactory repositoryFactory)
        {
            _employeesRepository = repositoryFactory.GetEmployeesRepository();
        }
        public Response AddEmployee(Request request)
        {
            try
            {
                if (request == null || request.Body == null)
                {
                    return new Response { IsSuccess = false, Body = null, Message = "Body is null" };
                }

                bool result = _employeesRepository.AddEmployee(request.Body);
                if (!result)
                {
                    return new Response { IsSuccess = false, Body = null, Message = "Added Failed" };
                }
                return new Response { IsSuccess = true, Body = null, Message = "Added Successful" };
            }
            catch (Exception e)
            {
                return new Response { IsSuccess = false, Body = null, Message = "Internal Error ==> Exception Message: " + e.Message };
            }

        }

        public Response GetAllEmployees()
        {
            try
            {
                List<Employee> employees = _employeesRepository.GetAllEmployees();

                if (employees == null || employees.Count <= 0)
                {
                    return new Response { IsSuccess = false, Body = null, Message = "List is empty" };
                }
                List<EmployeeSimpleDetails> employeeSimpleDetailsList = new List<EmployeeSimpleDetails>();

                foreach (var item in employees)
                {
                    EmployeeSimpleDetails employeeSimpleDetails = new EmployeeSimpleDetails
                    {
                        EmployeeId = item.EmployeeId,
                        FullName = item.FullName
                    };
                    employeeSimpleDetailsList.Add(employeeSimpleDetails);
                }
                return new Response { IsSuccess = true, Body = employeeSimpleDetailsList, Message = "" };
            }
            catch (Exception e)
            {
                return new Response { IsSuccess = false, Body = null, Message = "Internal Error ==> Exception Message: " + e.Message };
            }
        }

        public Response GetEmployeeById(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new Response { IsSuccess = false, Body = null, Message = "Employee Id is null" };
                }
                Employee employee = _employeesRepository.GetEmployeeById(id.GetValueOrDefault());
                if (employee == null)
                {
                    return new Response { IsSuccess = false, Body = null, Message = "employee not exist" };
                }

                EmployeeFullDetails employeeFullDetails = new EmployeeFullDetails
                {
                    CountryName = employee.Country.Name,
                    DepartmentName = employee.Department.Name,
                    EmployeeId = employee.EmployeeId,
                    FullName = employee.FullName,
                    PhoneNumber = employee.PhoneNumber,
                    Salary = employee.Salary
                };
                return new Response { IsSuccess = true, Body = employeeFullDetails, Message = "" };
            }
            catch (Exception e)
            {
                return new Response { IsSuccess = false, Body = null, Message = "Internal Error ==> Exception Message: " + e.Message };
            }
        }

        public Response UpdateEmployee(Request request)
        {
            try
            {
                if (request == null || request.Body == null)
                {
                    return new Response { IsSuccess = false, Body = null, Message = "Body is null" };
                }

                bool result = _employeesRepository.UpdateEmployee(request.Body);
                if (!result)
                {
                    return new Response { IsSuccess = false, Body = null, Message = "Update Failed" };
                }
                return new Response { IsSuccess = true, Body = null, Message = "Update Successful" };
            }
            catch (Exception e)
            {
                return new Response { IsSuccess = false, Body = null, Message = "Internal Error ==> Exception Message: " + e.Message };
            }
        }

        public Response DeleteEmployee(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new Response { IsSuccess = false, Body = null, Message = "Employee Id is null" };
                }
                bool result = _employeesRepository.DeleteEmployee(id.GetValueOrDefault());
                if (!result)
                {
                    return new Response { IsSuccess = false, Body = null, Message = "Delete Failed" };
                }
                return new Response { IsSuccess = true, Body = null, Message = "Delete Successful" };
            }
            catch (Exception e)
            {
                return new Response { IsSuccess = false, Body = null, Message = "Internal Error ==> Exception Message: " + e.Message };
            }
        }
    }
}
