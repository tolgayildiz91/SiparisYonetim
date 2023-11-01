using AutoMapper;
using MediatR;
using SiparisYonetim.Application.Features.Admin.DTOs;
using SiparisYonetim.Application.Features.Manager.Commands;
using SiparisYonetim.Application.Features.Manager.DTOs;
using SiparisYonetim.Application.Results;
using SiparisYonetim.Application.Services.AdminService;
using SiparisYonetim.Application.Services.ManagerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Features.Admin.Commands
{
    public class UpdateAdminCommand : IRequest<IResult>
    {
        public UpdateAdminDTO AdminDTO { get; set; }


        public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, IResult>
        {
            private readonly IAdminService _adminService;
            private readonly IMapper _mapper;

            public UpdateAdminCommandHandler(IAdminService adminService, IMapper mapper)
            {
                _adminService = adminService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
            {
                var result = await _adminService.UpdateAdminAsync(_mapper.Map<AdminDTO>(request));
                if (result)
                {
                    return new SuccessResult();
                }
                return new ErrorResult();
            }
        }



    }
}