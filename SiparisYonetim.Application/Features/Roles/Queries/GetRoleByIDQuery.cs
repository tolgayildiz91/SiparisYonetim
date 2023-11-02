using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
    public class GetRoleByIDQuery:IRequest<IResult>
    {
        public string ID { get; set; }

        public class GetRoleByIDQueryHandler:IRequestHandler<GetRoleByIDQuery,IResult>
        {
            private readonly IMapper _mapper;
            private readonly RoleManager<AppRole> _roleManager;

            public GetRoleByIDQueryHandler(IMapper mapper, RoleManager<AppRole> roleManager)
            {
                _mapper = mapper;
                _roleManager = roleManager;
            }

            public async Task<IResult> Handle(GetRoleByIDQuery request, CancellationToken cancellationToken)
            {
                var role = await _roleManager.FindByIdAsync(request.ID);
                return new SuccessDataResult<RoleDTO>(_mapper.Map<RoleDTO>(role));
            }
        }
    }
}
