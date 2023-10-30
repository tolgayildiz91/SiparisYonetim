using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SiparisYonetim.Application.Features.Manager.DTOs;
using SiparisYonetim.Application.Results;
using SiparisYonetim.Application.Services.ManagerService;
using SiparisYonetim.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Features.Manager.Commands
{
    public class CreateManagerCommand:IRequest<IResult>
    {
        public CreateManagerDTO ManagerDTO { get; set; }

        public class CreateManagerCommandHandler : IRequestHandler<CreateManagerCommand, IResult>
        {

            private readonly IManagerService _managerService;
            private readonly IMapper _mapper;

            public CreateManagerCommandHandler(IManagerService managerService, IMapper mapper)
            {
                _managerService = managerService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateManagerCommand request, CancellationToken cancellationToken)
            {
                var result = await _managerService.CreateManagerAsync(request.ManagerDTO);
                if (result)
                {
                    return new SuccessResult();
                }
                return new ErrorResult();



            }
        }
    }
}
