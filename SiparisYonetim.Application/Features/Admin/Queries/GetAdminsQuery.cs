using AutoMapper;
using MediatR;
using SiparisYonetim.Application.Features.Admin.DTOs;
using SiparisYonetim.Application.Features.Manager.DTOs;
using SiparisYonetim.Application.Results;
using SiparisYonetim.Application.Services.AdminService;
using SiparisYonetim.Application.Services.ManagerService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Features.Admin.Queries
{
    public class GetAdminsQuery:IRequest<IDataResult<IEnumerable<AdminDTO>>>
    {
        public AdminDTO AdminDTO { get; set; }

        public class GetAdminsQueryHandler : IRequestHandler<GetAdminsQuery, IDataResult<IEnumerable<AdminDTO>>>
        {
            IMapper _mapper;
            IAdminService _adminService;

            public GetAdminsQueryHandler(IMapper mapper, IAdminService adminService)
            {
                _mapper = mapper;
                _adminService = adminService;
            }

            public async Task<IDataResult<IEnumerable<AdminDTO>>> Handle(GetAdminsQuery request, CancellationToken cancellationToken)
            {

                var adminEntity = await _adminService.GetAllAdmins();
                return new SuccessDataResult<IEnumerable<AdminDTO>>(_mapper.Map<IEnumerable<AdminDTO>>(adminEntity));

            }
        }
    }
}
