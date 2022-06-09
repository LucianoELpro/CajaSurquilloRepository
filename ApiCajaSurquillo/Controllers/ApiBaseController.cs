using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ApiCajaSurquillo.Controllers
{
    
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class ApiBaseController : ControllerBase
    {
        private IMediator  _mediator;

        protected IMediator Mediator => _mediator ??=HttpContext.RequestServices.GetService<IMediator>();   

    }
}
