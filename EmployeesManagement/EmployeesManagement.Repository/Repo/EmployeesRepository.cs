using EmployeesManagement.Core.Contract;
using EmployeesManagement.Core.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EmployeesManagement.Repository.Repo
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public bool AddEmployee(Employee employee)
        {
            try
            {
                using (var context = new EmployeeContext())
                {
                    bool result = false;
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "AddEmployee";
                        command.CommandType = CommandType.StoredProcedure;
                        context.Database.OpenConnection();
                        command.Parameters.Add(new SqlParameter("@FullName", employee.FullName));
                        command.Parameters.Add(new SqlParameter("@DepartmentId", employee.DepartmentId));
                        command.Parameters.Add(new SqlParameter("@PhoneNumber", employee.PhoneNumber));
                        command.Parameters.Add(new SqlParameter("@CountryId", employee.CountryId));
                        command.Parameters.Add(new SqlParameter("@CreatedOn", DateTime.Now));
                        command.Parameters.Add(new SqlParameter("@Salary", employee.Salary));

                        result = command.ExecuteNonQuery() < 0;
                        command.Connection.Close();
                    }
                    return result;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                using var dbContext = new EmployeeContext();
                List<Employee> employees = dbContext.Employees.Include(x => x.Country).Include(x => x.Department).ToList();
                return employees;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Employee GetEmployeeById(int id)
        {
            try
            {
                using var dbContext = new EmployeeContext();
                Employee employee = dbContext.Employees.Include(x => x.Country).Include(x => x.Department).FirstOrDefault(p => p.EmployeeId == id);
                return employee;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                Employee employee = new Employee { EmployeeId = id };
                using var dbContext = new EmployeeContext();
                dbContext.Remove<Employee>(employee);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;

            }
        }
        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                using (var context = new EmployeeContext())
                {
                    bool result = false;
                    using (var command = context.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = "UpdateEmployee";
                        command.CommandType = CommandType.StoredProcedure;
                        context.Database.OpenConnection();
                        command.Parameters.Add(new SqlParameter("@EmployeeId", employee.EmployeeId));
                        command.Parameters.Add(new SqlParameter("@FullName", employee.FullName));
                        command.Parameters.Add(new SqlParameter("@DepartmentId", employee.DepartmentId));
                        command.Parameters.Add(new SqlParameter("@PhoneNumber", employee.PhoneNumber));
                        command.Parameters.Add(new SqlParameter("@CountryId", employee.CountryId));
                        command.Parameters.Add(new SqlParameter("@UpdateOn", DateTime.Now));
                        command.Parameters.Add(new SqlParameter("@Salary", employee.Salary));

                        result = command.ExecuteNonQuery() < 0;
                        command.Connection.Close();
                    }
                    return result;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
