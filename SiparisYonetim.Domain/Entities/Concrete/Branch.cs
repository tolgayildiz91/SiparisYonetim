using SiparisYonetim.Domain.Entities.Abstract;
using SiparisYonetim.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Domain.Entities.Concrete
{
    public class Branch : IEntity<int>, IBaseEntity
    {
        public int ID { get; set; }
        public string BranchName { get; set; }



        //public virtual List<Admin> Managers { get; set; }
        //public Guid ManagerId { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Status Status { get; set; }

    }
}
