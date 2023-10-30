using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Domain.Entities.Concrete
{
    public class Manager:AppUser
    {
        public int BranchID { get; set; }
        public Branch Branch { get; set; }
    }
}
