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

namespace SiparisYonetim.Application.Features.Roles.Commands
{
    public class UpdateRoleCommand:IRequest<IResult>
    {
        public UpdateRoleDTO UpdateRoleDTO { get; set; }

        public class UpdateRoleCommandHandler:IRequestHandler<UpdateRoleCommand, IResult>
        {
            private readonly IMapper _mapper;
            private readonly RoleManager<AppRole> _roleManager;

            public UpdateRoleCommandHandler(IMapper mapper, RoleManager<AppRole> roleManager)
            {
                _mapper = mapper;
                _roleManager = roleManager;
            }

            public async Task<IResult> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
            {
                await _roleManager.UpdateAsync(_mapper.Map<AppRole>(request.UpdateRoleDTO));

                return new SuccessResult("Güncelleme Başarılı");
            }
        }
    }
}
