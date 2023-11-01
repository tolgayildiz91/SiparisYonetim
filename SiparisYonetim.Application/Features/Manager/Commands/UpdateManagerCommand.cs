using AutoMapper;
using MediatR;
using SiparisYonetim.Application.Features.Manager.DTOs;
using SiparisYonetim.Application.Features.Users.DTOs;
using SiparisYonetim.Application.Results;
using SiparisYonetim.Application.Services.ManagerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Features.Manager.Commands
{
    public class UpdateManagerCommand:IRequest<IResult>
    {
        public UpdateManagerDTO ManagerDTO { get; set; }


        public class UpdateManagerCommandHandler : IRequestHandler<UpdateManagerCommand, IResult>
        {
            private readonly IManagerService _managerService;
            private readonly IMapper _mapper;

            public UpdateManagerCommandHandler(IManagerService managerService, IMapper mapper)
            {
                _managerService = managerService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(UpdateManagerCommand request, CancellationToken cancellationToken)
            {
              
                var result = await _managerService.UpdateManagerAsync(_mapper.Map<ManagerDTO>(request.ManagerDTO));
                if (result)
                {
                    return new SuccessResult();
                }
                return new ErrorResult();
            }
        }



    }
}
