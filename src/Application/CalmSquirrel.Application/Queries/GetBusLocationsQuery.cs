using CalmSquirrel.Domain.Contracts;
using CalmSquirrel.Domain.ValueObjects;
using CalmSquirrel.Domain.ValueObjects.RequestModels;
using CalmSquirrel.Domain.ValueObjects.ResponseModels;
using MediatR;

namespace CalmSquirrel.Application.Queries
{
    public class GetBusLocationsQuery : IRequest<BaseResponse<List<GetBusLocationsResponseModel>>>
    {
        public string SearchText { get; private set; }
        public string SessionId { get; private set; }
        public string DeviceId { get; private set; }
        public DateTime Date { get; private set; }

        public GetBusLocationsQuery(
            string searchText, 
            string sessionId,
            string deviceId,
            DateTime date)
        {
            SearchText = searchText;
            SessionId = sessionId;
            DeviceId = deviceId;
            Date = date;
        }
    }

    public class GetBusLocationsQueryHandler : IRequestHandler<GetBusLocationsQuery, BaseResponse<List<GetBusLocationsResponseModel>>>
    {
        private readonly IReservationAdapter _reservationAdapter;

        public GetBusLocationsQueryHandler(IReservationAdapter reservationAdapter)
        {
            _reservationAdapter = reservationAdapter;
        }

        public async Task<BaseResponse<List<GetBusLocationsResponseModel>>> Handle(GetBusLocationsQuery request, CancellationToken cancellationToken)
        {
            var requestModel = new GetBusLocationsRequestModel(request.SearchText, request.SessionId, request.DeviceId, request.Date);
            return await _reservationAdapter.GetBusLocations(requestModel);
        }
    }
}
