using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Results
{
    public class ErrorApiResult<T> : ApiResult<T>
    {
        public ErrorApiResult(string message) : base(false, message)
        {
        }
        public ErrorApiResult(bool success, T data, string message, object values = null) : base(success, message, data, values)
        {
        }

        public ErrorApiResult(bool success, string message, object? values = null) : base(success, message, values)
        {
        }
    }
}
