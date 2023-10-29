using SiparisYonetim.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Domain.Entities.Abstract
{
    public interface IUser:IBaseEntity
    {
        public string? Picture { get; set; }
        public string FirstName { get; set; }
        public string? SecondFirstName { get; set; }
        public string? LastName { get; set; }
        public string SecondLastName { get; set; }
        public Gender? Gender { get; set; }
    }
}
