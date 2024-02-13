using CalmSquirrel.Domain.Contracts;
using CalmSquirrel.Domain.ValueObjects;
using CalmSquirrel.Domain.ValueObjects.RequestModels;
using CalmSquirrel.Domain.ValueObjects.ResponseModels;
using MediatR;

namespace CalmSquirrel.Application.Queries
{
    public class GetJourneysQuery : IRequest<BaseResponse<List<GetJourneyResponseModel>>>
    {
        public string SessionId { get; private set; }
        public string DeviceId { get; private set; }
        public DateTime Date { get; private set; }
        public int OriginId { get; private set; }
        public int DestinationId { get; private set; }
        public DateTime DepartureDate { get; private set; }

        public GetJourneysQuery(
            string sessionId,
            string deviceId,
            DateTime date, 
            int originId,
            int destinationId,
            DateTime departureDate)
        {
            SessionId = sessionId;
            DeviceId = deviceId;
            Date = date;
            OriginId = originId;
            DestinationId = destinationId;
            DepartureDate = departureDate;
        }
    }

    public class GetJourneysQueryHandler : IRequestHandler<GetJourneysQuery, BaseResponse<List<GetJourneyResponseModel>>>
    {
        private readonly IReservationAdapter _reservationAdapter;

        public GetJourneysQueryHandler(IReservationAdapter reservationAdapter)
        {
            _reservationAdapter = reservationAdapter;
        }

        public async Task<BaseResponse<List<GetJourneyResponseModel>>> Handle(GetJourneysQuery request, CancellationToken cancellationToken)
        {
            var requestModel = new GetJourneysRequestModel(request.SessionId, request.DeviceId, request.Date, request.OriginId, request.DestinationId, request.DepartureDate);
            return await _reservationAdapter.GetJourneys(requestModel);
        }
    }
}
