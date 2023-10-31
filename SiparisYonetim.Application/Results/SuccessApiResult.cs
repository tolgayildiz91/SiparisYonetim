using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Results
{
    public class SuccessApiResult<T> : ApiResult<T>
    {
        public SuccessApiResult(bool success, T data, string message, object values = null) : base(success, message, data, values)
        {
        }

        public SuccessApiResult(bool success, string message, object? values = null) : base(success, message, values)
        {
        }
    }
}