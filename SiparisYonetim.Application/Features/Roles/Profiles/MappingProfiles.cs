using AutoMapper;
using SiparisYonetim.Application.Features.Roles.DTOs;
using SiparisYonetim.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Features.Roles.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
     
            CreateMap<AppRole, CreateRoleDTO>().ReverseMap();
            CreateMap<AppRole, UpdateRoleDTO>().ReverseMap();
            CreateMap<AppRole, RoleDTO>().ReverseMap();
        }
    }
}
