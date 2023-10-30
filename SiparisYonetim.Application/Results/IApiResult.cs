using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Results
{
    public interface IApiResult<out T> : IResult
    {
        T Data { get; }
        public object Values { get; set; }

    }
}
