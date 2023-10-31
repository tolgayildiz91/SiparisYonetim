using AutoMapper;
using SiparisYonetim.Application.Features.Manager.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Features.Manager.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Concrete.Manager, CreateManagerDTO>().ReverseMap();
            CreateMap<Domain.Entities.Concrete.Manager, ManagerDTO>().ReverseMap();
        }
    }
}
