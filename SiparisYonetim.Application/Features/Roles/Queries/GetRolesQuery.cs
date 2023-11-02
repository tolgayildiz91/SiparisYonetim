using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SiparisYonetim.Application.Features.Roles.DTOs;
using SiparisYonetim.Application.Results;
using SiparisYonetim.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Features.Roles.Queries
{
    public class GetRolesQuery:IRequest<IDataResult<IEnumerable<RoleDTO>>>
    {

        public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, IDataResult<IEnumerable<RoleDTO>>>
        {
            private readonly RoleManager<AppRole> _roleManager;
            private readonly IMapper _mapper;

            public GetRolesQueryHandler(RoleManager<AppRole> roleManager, IMapper mapper)
            {
                _roleManager = roleManager;
                _mapper = mapper;
            }

            public async Task<IDataResult<IEnumerable<RoleDTO>>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
            {
               var roles = await _roleManager.Roles.ToListAsync(cancellationToken);
                return new SuccessDataResult<IEnumerable<RoleDTO>>(_mapper.Map<IEnumerable<RoleDTO>>(roles));
            }
        }
    }

}
