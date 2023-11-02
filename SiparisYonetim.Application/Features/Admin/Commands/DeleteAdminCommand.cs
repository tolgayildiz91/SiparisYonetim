using AutoMapper;
using MediatR;
using SiparisYonetim.Application.Features.Admin.DTOs;
using SiparisYonetim.Application.Results;
using SiparisYonetim.Application.Services.AdminService;
using SiparisYonetim.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Features.Admin.Commands
{
    public class DeleteAdminCommand:IRequest<IResult>
    {
        public Guid ID { get; set; }


        public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, IResult>
        {

            IMapper _mapper;
            IAdminService _adminService;

            public DeleteAdminCommandHandler(IMapper mapper, IAdminService adminService)
            {
                _mapper = mapper;
                _adminService = adminService;
            }

            public async Task<IResult> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
            {
                var admin = await _adminService.GetAdminId(request.ID);
                await _adminService.DeleteAdminAsync(_mapper.Map<AdminDTO>(admin));
                return new SuccessResult();

            }
        }
    }
}
