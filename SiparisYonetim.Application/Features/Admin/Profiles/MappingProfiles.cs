using AutoMapper;
using SiparisYonetim.Application.Features.Admin.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Features.Admin.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap <Domain.Entities.Concrete.Admin,AdminDTO > ().ReverseMap();
            CreateMap<Domain.Entities.Concrete.Admin, CreateAdminDTO>().ReverseMap();
        }
    }
}
