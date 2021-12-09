using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesManagement.Core.Model
{
    public class Response 
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Body { get; set; }

    }
}
