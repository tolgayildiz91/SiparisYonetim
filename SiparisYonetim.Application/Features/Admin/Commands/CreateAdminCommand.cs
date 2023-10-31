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
    public class CreateAdminCommand:IRequest<IResult>
    {
        public CreateAdminDTO AdminDTO { get; set; }

        public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, IResult>
        {

            private readonly IAdminService _adminService;
            private readonly IMapper _mapper;

            public CreateAdminCommandHandler(IAdminService adminService, IMapper mapper)
            {
                _adminService = adminService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
            {
                var result = await _adminService.CreateAdminAsync(request.AdminDTO);
                if (result)
                {
                    return new SuccessResult();
                }
                return new ErrorResult();



            }
        }
    }
}
