using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagement.Core.Contract
{
    public interface IJsonSerializer
    {
        string SerializeToString<T>(T obj, bool isIndented = true) where T : class;
        T DeserializeFromString<T>(string messageString) where T : class;

    }
}
