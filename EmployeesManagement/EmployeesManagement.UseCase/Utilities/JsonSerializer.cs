using EmployeesManagement.Core.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesManagement.UseCase.Utilities
{
    public class JsonSerializer : IJsonSerializer
    {
        #region Methods

        public string SerializeToString<T>(T obj, bool isIndented = true) where T : class
        {
            try
            {
                string serializeObject = JsonConvert.SerializeObject(obj, typeof(T), isIndented ? Formatting.Indented : Formatting.None, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                });
                return serializeObject;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public T DeserializeFromString<T>(string messageString) where T : class
        {
            try
            {
                T deserializeObject = JsonConvert.DeserializeObject<T>(messageString, new JsonSerializerSettings { DateFormatString = "yyyy-MM-dd HH:mm:ss.fff" });
                return deserializeObject;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
