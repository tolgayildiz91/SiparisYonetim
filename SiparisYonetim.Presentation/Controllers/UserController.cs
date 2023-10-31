using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiparisYonetim.Application.Features.Admin.Commands;
using SiparisYonetim.Application.Features.Admin.DTOs;
using SiparisYonetim.Application.Features.Manager.Commands;
using SiparisYonetim.Application.Features.Manager.DTOs;

namespace SiparisYonetim.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
    

        [HttpPost]
        public async Task<IActionResult> CreateManager(CreateManagerDTO createManagerDTO)
        {

            var result = await Mediator.Send(new CreateManagerCommand() { ManagerDTO = createManagerDTO });
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest();
        }



        [HttpPost]
        public async Task<IActionResult> CreateAdmin(CreateAdminDTO createAdminDTO)
        {

            var result = await Mediator.Send(new CreateAdminCommand() { AdminDTO = createAdminDTO });
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest();
        }


    }
}
