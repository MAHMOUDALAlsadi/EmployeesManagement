using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManagement.Core.Contract
{
    public interface IContext
    {
        IConfiguration GetConfiguration();
        IJsonSerializer GetJsonSerializer();
        IUseCaseFactory GetUseCaseFactory();
    }
}
