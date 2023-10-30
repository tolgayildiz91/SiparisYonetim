using AutoMapper;
using MediatR;
using SiparisYonetim.Application.Features.Users.DTOs;
using SiparisYonetim.Application.Results;
using SiparisYonetim.Application.Services.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Features.Users.Queries
{
    public class GetAllUserQuery : IRequest<IDataResult<IEnumerable<UserDTO>>>
    {
        public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IDataResult<IEnumerable<UserDTO>>>
        {
            private readonly IUserService _userService;
            private readonly IMapper _mapper;

            public GetAllUserQueryHandler(IUserService userService, IMapper mapper)
            {
                _userService = userService;
                _mapper = mapper;
            }

            public async Task<IDataResult<IEnumerable<UserDTO>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
            {
                var userEntity = await _userService.GetAllUsers();

                return new SuccessDataResult<IEnumerable<UserDTO>>(_mapper.Map<IEnumerable<UserDTO>>(userEntity));
            }
        }
    }
}
