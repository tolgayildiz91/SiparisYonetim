﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiparisYonetim.Application.Features.Admin.Commands;
using SiparisYonetim.Application.Features.Admin.DTOs;
using SiparisYonetim.Application.Features.Manager.Commands;
using SiparisYonetim.Application.Features.Manager.DTOs;
using SiparisYonetim.Application.Features.Manager.Queries;
using SiparisYonetim.Application.Results;

namespace SiparisYonetim.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {



        #region Manager

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


        [HttpPut]
        public async Task<IActionResult> UpdateManager(UpdateManagerDTO updateManagerDTO)
        {

            var result = await Mediator.Send(new UpdateManagerCommand() { ManagerDTO=updateManagerDTO });

            if (result.Success) 
            {
                return Ok();
            }
            return BadRequest();

        }


        [HttpGet]
        public async Task<IActionResult> GetAllManager()
        {
            var result = await Mediator.Send(new GetManagersQuery());

            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }


        [HttpGet]
        public async Task<IActionResult> GetManagerByID(Guid ID)
        {
            var result = await Mediator.Send(new GetManagerByIDQuery() { ID = ID });
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }






        #endregion



        #region Admin


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


        #endregion








    }
}
