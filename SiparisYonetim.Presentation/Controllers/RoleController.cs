using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiparisYonetim.Application.Features.Roles.Commands;
using SiparisYonetim.Application.Features.Roles.DTOs;
using SiparisYonetim.Application.Features.Roles.Queries;
using SiparisYonetim.Application.Results;

namespace SiparisYonetim.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoleController : BaseController
    {

        #region Genel Rol İslemleri
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDTO createRoleDTO)
        {
            var result = await Mediator.Send(new CreateRoleCommand() { CreateRoleDTO=createRoleDTO});
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRole(UpdateRoleDTO updateRoleDTO)
        {
            var result = await Mediator.Send(new UpdateRoleCommand() { UpdateRoleDTO=updateRoleDTO});
            if(result.Success )
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRole(string Id)
        {
            var result = await Mediator.Send(new DeleteRoleCommand() { ID=Id});
            if ((result.Success)) 
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await Mediator.Send(new GetRolesQuery() { });
            if ((result.Success))
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetRoleByID(string Id)
        {
            var result = await Mediator.Send(new GetRoleByIDQuery() { ID=Id});
            if ((result.Success))
            {
                return Ok(result);
            }

            return BadRequest(result);

        }





        #endregion

        #region Kullanıcı Rol Ayarları

        #endregion

    }
}
