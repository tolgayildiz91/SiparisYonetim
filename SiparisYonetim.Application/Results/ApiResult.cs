using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Results
{
    public class ApiResult<T> : IApiResult<T>
    {
        public ApiResult(bool success, string message, T data, object values = null)
        {
            Success = success;
            Message = message;
            Data = data;
            Values = values;
        }

        public ApiResult(bool success, string message, object values = null)
        {
            Success = success;
            Message = message;
            Values = values;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public object Values { get; set; }
    }
}
