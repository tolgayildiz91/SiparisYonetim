using AutoMapper;
using MediatR;
using SiparisYonetim.Application.Features.Manager.DTOs;
using SiparisYonetim.Application.Results;
using SiparisYonetim.Application.Services.ManagerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Features.Manager.Queries
{
    public class GetManagerByIDQuery : IRequest<IResult>
    {
        public Guid ID { get; set; }

        public class GetManagerByIDQueryHandler : IRequestHandler<GetManagerByIDQuery, IResult>
        {
            private readonly IMapper _mapper;
            private readonly IManagerService _managerService;

            public GetManagerByIDQueryHandler(IMapper mapper, IManagerService managerService)
            {
                _mapper = mapper;
                _managerService = managerService;
            }

            public async Task<IResult> Handle(GetManagerByIDQuery request, CancellationToken cancellationToken)
            {

                var managerEntity = await _managerService.GetUserId(request.ID);
                ManagerDTO managerDTOs = _mapper.Map<ManagerDTO>(managerEntity);
                return new SuccessDataResult<ManagerDTO>(managerDTOs);


            }
        }
    }
}
