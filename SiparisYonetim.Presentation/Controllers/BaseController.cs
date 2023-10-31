using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SiparisYonetim.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator
        {
            get
            {
                return _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
            }
        }
    }
}
