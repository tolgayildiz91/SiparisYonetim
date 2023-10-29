using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Domain.Entities.Abstract
{
    internal interface IEntity<T>
    {
        public T Id { get; set; }
    }
}
