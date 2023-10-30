using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiparisYonetim.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Infrastructure.EntityMapping
{
    public class BranchesMapping:BaseEntityMapping<Branch,int>
    {
        public override void Configure(EntityTypeBuilder<Branch> builder)
        {

            base.Configure(builder);
        }
    }
}
