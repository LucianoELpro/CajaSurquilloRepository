using Application.Features.CardRequestFeature.Queries.GetAllCardRequestQuery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiCajaSurquillo.Controllers.V1
{
   
    [ApiVersion("1.0")]
    public class CardRequestController : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCardRequest()
        {
            return Ok(await Mediator.Send(new GetAllCardRequestQuery()));
            //Object reference not set to an instance of an object.'
        }
    }
}
