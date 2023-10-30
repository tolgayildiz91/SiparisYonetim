using MediatR;
using SiparisYonetim.Application.Results;
using SiparisYonetim.Application.Services.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Features.Users.Queries
{
    public class GetLogoutQuery:IRequest<IResult>
    {

        public class GetLoginQueryHandler : IRequestHandler<GetLogoutQuery, IResult>
        {
            private readonly IUserService _userService;

            public GetLoginQueryHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<IResult> Handle(GetLogoutQuery request, CancellationToken cancellationToken)
            {
                await _userService.Logout();
                return new SuccessResult();
            }
        }




    }
}
