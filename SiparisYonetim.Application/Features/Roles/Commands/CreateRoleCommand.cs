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
    public class CreateRoleCommand:IRequest<IResult>
    {
        public CreateRoleDTO CreateRoleDTO { get; set; }


        public class CreateRoleCommandHandler:IRequestHandler<CreateRoleCommand,IResult>
        {
            private readonly RoleManager<AppRole> _roleManager;
            private readonly IMapper _mapper;

            public CreateRoleCommandHandler(RoleManager<AppRole> roleManager, IMapper mapper)
            {
                _roleManager = roleManager;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
            {
                await _roleManager.CreateAsync(_mapper.Map<AppRole>(request.CreateRoleDTO));

                return new SuccessResult("Kayıt Başarılı");
            }
        }
    }

}
