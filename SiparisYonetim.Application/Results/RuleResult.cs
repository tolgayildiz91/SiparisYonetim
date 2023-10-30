using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Results
{
    public class RuleResult : IRuleResult
    {
        public string Message { get; set; } = "";
        public bool isError { get; set; }

        public RuleResult() { }
        public RuleResult(bool isError, string Message)
        {
            this.isError = isError;
            this.Message = Message;
        }
    }
}
