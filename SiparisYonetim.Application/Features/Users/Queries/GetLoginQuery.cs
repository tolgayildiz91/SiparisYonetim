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
    public class GetLoginQuery:IRequest<IResult>
    {
        public LoginDTO LoginDTO { get; set; }

        public class GetLoginQueryHandler : IRequestHandler<GetLoginQuery, IResult>
        {
            private readonly IUserService _userService;

            public GetLoginQueryHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<IResult> Handle(GetLoginQuery request, CancellationToken cancellationToken)
            {
                var userCheck = await _userService.FindUserByNameAsync(request.LoginDTO.UserName);
                if(userCheck == null)
                {

                    userCheck = await _userService.FindUserByEmailAsync(request.LoginDTO.UserName);

                    if(userCheck == null)
                    {
                        return new ErrorResult("Kullanıcı Adı veya Şifre Hatalı");
                    }

                }

                var result = await _userService.LoginAsync(userCheck.UserName, request.LoginDTO.Password, false, false);

                if (!result)
                {
                    return new ErrorResult("Kullanıcı Adı veya Şifre Hatalı");
                }

                return new SuccessResult();

            }
        }
    }
}
