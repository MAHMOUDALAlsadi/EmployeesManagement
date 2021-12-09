using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManagement.Core.Contract
{
    public interface IUseCaseFactory
    {
        IEmployeesUseCase GetEmployeesUseCase();
    }
}
