using CalmSquirrel.Application.Queries;
using CalmSquirrel.Domain.Extensions;
using CalmSquirrel.Domain.ValueObjects;
using CalmSquirrel.Domain.ValueObjects.ResponseModels;
using CalmSquirrel.Presentation.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CalmSquirrel.Presentation.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OBiletController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string _cookieName = "OBiletSession";

        public OBiletController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetBusLocations")]
        public async Task<IActionResult> GetJourneys([FromBody]GetJourneysViewModel viewModel)
        {
            if (!Request.Cookies.ContainsKey(_cookieName))
            {
                var unauthorizedResponse = new BaseResponse<NoContent>
                {
                    IsSuccess = false,
                    Message = "Session key alınamadı"
                };

                return StatusCode((int)HttpStatusCode.Unauthorized, unauthorizedResponse);
            }

            if (!viewModel.Validate())
            {
                var badRequestResponse = new BaseResponse<NoContent>
                {
                    IsSuccess = false,
                    Message = "Kalkış saati bugünden küçük olamaz"
                };

                return StatusCode((int)HttpStatusCode.BadRequest, badRequestResponse);
            }

            var session = Request.Cookies[_cookieName].ToObject<GetSessionResponseModel>();
            var request = new GetBusLocationsQuery(viewModel.SearchText, session.SessionId, session.DeviceId, viewModel.Date);
            var response = await _mediator.Send(request);

            return StatusCode((int)HttpStatusCode.OK, response);
        }
    }
}
