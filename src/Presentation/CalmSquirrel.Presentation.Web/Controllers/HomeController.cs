using CalmSquirrel.Application.Queries;
using CalmSquirrel.Domain.Extensions;
using CalmSquirrel.Domain.ValueObjects.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CalmSquirrel.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly string _cookieName = "OBiletSession";

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            if (!Request.Cookies.ContainsKey(_cookieName))
            {
                var request = new GetSessionQuery("165.114.41.21", "5117", "Chrome", "47.0.0.12");
                var response = await _mediator.Send(request);

                if (!response.IsSuccess)
                    throw new Exception(response.Message);

                Response.Cookies.Append(_cookieName, response.Data.ToJson());
            }

            return View();
        }

        public async Task<IActionResult> GetJourneys()
        {
            var session = Request.Cookies[_cookieName].ToObject<GetSessionResponseModel>();

            if (session is null)
                throw new Exception(); //TODO:

            int originId = 0;
            int destinationId = 0;
            DateTime date;

            int.TryParse(Request.Query["origin-id"], out originId);
            int.TryParse(Request.Query["destination-id"], out destinationId);
            DateTime.TryParseExact(Request.Query["departure-date"], "yyyy-MM-dd",null,DateTimeStyles.None, out date);

            var request = new GetJourneysQuery(session.SessionId, session.DeviceId, date, originId, destinationId, date);
            var response = await _mediator.Send(request);

            return View(response.Data);
        }

    }
}
