﻿using AutoMapper;
using MediatR;
using SiparisYonetim.Application.Features.Manager.DTOs;
using SiparisYonetim.Application.Results;
using SiparisYonetim.Application.Services.ManagerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Features.Manager.Queries
{
    public class GetManagersQuery:IRequest<IDataResult<IEnumerable<ManagerDTO>>>
    {
        public ManagerDTO ManagerDTO { get; set; }

        public class GetManagersQueryHandler : IRequestHandler<GetManagersQuery, IDataResult<IEnumerable<ManagerDTO>>>
        {

            IManagerService _managerService;
            IMapper _mapper;

            public GetManagersQueryHandler(IManagerService managerService, IMapper mapper)
            {
                _managerService = managerService;
                _mapper = mapper;
            }

            public async Task<IDataResult<IEnumerable<ManagerDTO>>> Handle(GetManagersQuery request, CancellationToken cancellationToken)
            {

                var managerEntity = await _managerService.GetAllManagers();

                return new SuccessDataResult<IEnumerable<ManagerDTO>>(_mapper.Map<IEnumerable<ManagerDTO>>(managerEntity));




            }     
        }

    }
}
