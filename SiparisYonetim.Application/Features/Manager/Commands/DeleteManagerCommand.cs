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

namespace SiparisYonetim.Application.Features.Manager.Commands
{
    public class DeleteManagerCommand:IRequest<IResult>
    {
        public Guid ID { get; set; }


        public class DeleteManagerCommandHandler : IRequestHandler<DeleteManagerCommand, IResult>
        {
            private readonly IMapper _mapper;
            private readonly IManagerService _managerService;

            public DeleteManagerCommandHandler(IMapper mapper, IManagerService managerService)
            {
                _mapper = mapper;
                _managerService = managerService;
            }

            public async Task<IResult> Handle(DeleteManagerCommand request, CancellationToken cancellationToken)
            {

                var manager = await _managerService.GetUserId(request.ID);
                 await _managerService.DeleteManagerAsync(_mapper.Map<ManagerDTO>(manager));

                    return new SuccessResult();
               

            }
        }

    }
}
