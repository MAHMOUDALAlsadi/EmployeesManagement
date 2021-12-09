using EmployeesManagement.Core.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeesManagement.Repository.Repo;

namespace EmployeesManagement.Core
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public IEmployeesRepository GetEmployeesRepository()
        {
            return new EmployeesRepository();
        }
    }
}
