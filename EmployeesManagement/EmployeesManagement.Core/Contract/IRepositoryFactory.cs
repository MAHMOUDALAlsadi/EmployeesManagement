using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManagement.Core.Contract
{
    public interface IRepositoryFactory
    {
        IEmployeesRepository GetEmployeesRepository();

    }
}
