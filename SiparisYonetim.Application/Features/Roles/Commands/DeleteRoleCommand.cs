using MediatR;
using Microsoft.AspNetCore.Identity;
using SiparisYonetim.Application.Results;
using SiparisYonetim.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisYonetim.Application.Features.Roles.Commands
{
    public class DeleteRoleCommand:IRequest<IResult>
    {
        public string ID { get; set; }

        public class DeleteRoleCommandHandler:IRequestHandler<DeleteRoleCommand,IResult>
        {
            private readonly RoleManager<AppRole> _roleManager;
            

            public DeleteRoleCommandHandler(RoleManager<AppRole> roleManager)
            {
                _roleManager = roleManager;
            }

            public async Task<IResult> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
            {
                var result = await _roleManager.FindByIdAsync(request.ID);
                await _roleManager.DeleteAsync(result);
                return (new SuccessResult("Silme Başarılı"));

            }
        }
    }
}
