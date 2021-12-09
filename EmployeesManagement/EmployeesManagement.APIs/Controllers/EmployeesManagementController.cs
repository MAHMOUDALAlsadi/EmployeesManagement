using EmployeesManagement.Core.Contract;
using EmployeesManagement.Core.DTOs;
using EmployeesManagement.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

namespace EmployeesManagement.APIs.Controllers
{
    [Route("API/[action]")]
    [ApiController]
    public class EmployeesManagementController : ControllerBase
    {
        private readonly IContext _context;

        public EmployeesManagementController(IContext context)
        {
            _context = context;
        }


        [HttpGet]
        [ActionName("GetAllEmployees")]
        public string GetAllEmployees([FromQuery(Name = "GUID")] string guid)
        {
            try
            {
                var response = _context.GetUseCaseFactory().GetEmployeesUseCase().GetAllEmployees();
                return _context.GetJsonSerializer().SerializeToString(response);
            }
            catch (Exception e)
            {
                Response body = new Response { IsSuccess = false, Body = null, Message = "Internal Error ==> Exception Message: " + e.Message };
                return _context.GetJsonSerializer().SerializeToString(body);
            }
        }

        [HttpGet]
        [ActionName("GetEmployeeDetails")]
        public string GetEmployeeDetails([FromQuery(Name = "GUID")] string guid, [FromQuery(Name = "EmployeeId")] int? employeeId)
        {
            try
            {
                var response = _context.GetUseCaseFactory().GetEmployeesUseCase().GetEmployeeById(employeeId);
                return _context.GetJsonSerializer().SerializeToString(response);
            }
            catch (Exception e)
            {
                Response body = new Response { IsSuccess = false, Body = null, Message = "Internal Error ==> Exception Message: " + e.Message };
                return _context.GetJsonSerializer().SerializeToString(body);
            }
        }

        [HttpPost]
        [ActionName("AddEmployee")]
        public string AddEmployee([FromQuery(Name = "GUID")] string guid, [FromBody] JsonElement message)
        {
            try
            {
                var employee = _context.GetJsonSerializer().DeserializeFromString<Employee>(message.ToString());
                Request request = new Request { Body = employee };
                var response = _context.GetUseCaseFactory().GetEmployeesUseCase().AddEmployee(request);
                return _context.GetJsonSerializer().SerializeToString(response);
            }
            catch (Exception e)
            {
                Response body = new Response { IsSuccess = false, Body = null, Message = "Internal Error ==> Exception Message: " + e.Message };
                return _context.GetJsonSerializer().SerializeToString(body);
            }
        }

        [HttpPost]
        [ActionName("UpdateEmployee")]
        public string UpdateEmployee([FromQuery(Name = "GUID")] string guid, [FromBody] JsonElement message)
        {
            try
            {
                var employee =  _context.GetJsonSerializer().DeserializeFromString<Employee>(message.ToString());
                Request request = new Request {Body = employee };
                var response = _context.GetUseCaseFactory().GetEmployeesUseCase().UpdateEmployee(request);
                return _context.GetJsonSerializer().SerializeToString(response);
            }
            catch (Exception e)
            {
                Response body = new Response { IsSuccess = false, Body = null, Message = "Internal Error ==> Exception Message: " + e.Message };
                return _context.GetJsonSerializer().SerializeToString(body);
            }
        }

        [HttpGet]
        [ActionName("DeleteEmployee")]
        public string DeleteEmployee([FromQuery(Name = "GUID")] string guid, [FromQuery(Name = "EmployeeId")] int? EmployeeId)
        {
            try
            {
                var response = _context.GetUseCaseFactory().GetEmployeesUseCase().DeleteEmployee(EmployeeId);
                return _context.GetJsonSerializer().SerializeToString(response);
            }
            catch (Exception e)
            {
                Response body = new Response { IsSuccess = false, Body = null, Message = "Internal Error ==> Exception Message: " + e.Message };
                return _context.GetJsonSerializer().SerializeToString(body);
            }
        }
    }
}
