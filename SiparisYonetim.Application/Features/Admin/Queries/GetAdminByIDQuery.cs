using AutoMapper;
using MediatR;
using SiparisYonetim.Application.Features.Admin.DTOs;
using SiparisYonetim.Application.Results;
using SiparisYonetim.Application.Services.AdminService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Features.Admin.Queries
{
    public class GetAdminByIDQuery:IRequest<IResult>
    {
        public Guid ID { get; set; }

        public class GetAdminByIDQueryHandler : IRequestHandler<GetAdminByIDQuery, IResult>
        {
            IMapper _mapper;
            IAdminService _adminService;

            public GetAdminByIDQueryHandler(IMapper mapper, IAdminService adminService)
            {
                _mapper = mapper;
                _adminService = adminService;
            }

            public async Task<IResult> Handle(GetAdminByIDQuery request, CancellationToken cancellationToken)
            {

                var adminEntity = await _adminService.GetAdminId(request.ID);
               return new SuccessDataResult<AdminDTO>(_mapper.Map<AdminDTO>(adminEntity));
            }
        }



    }
}
