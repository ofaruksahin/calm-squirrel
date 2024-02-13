using CalmSquirrel.Domain.Contracts;
using CalmSquirrel.Domain.ValueObjects;
using CalmSquirrel.Domain.ValueObjects.RequestModels;
using CalmSquirrel.Domain.ValueObjects.ResponseModels;
using MediatR;

namespace CalmSquirrel.Application.Queries
{
    public class GetSessionQuery : IRequest<BaseResponse<GetSessionResponseModel>>
    {
        public string IpAddress { get; private set; }
        public string Port { get; private set; }
        public string Browser { get; private set; }
        public string Version { get; private set; }

        public GetSessionQuery(string ipAddress, string port, string browser, string version)
        {
            IpAddress = ipAddress;
            Port = port;
            Browser = browser;
            Version = version;
        }
    }

    public class GetSessionQueryHandler : IRequestHandler<GetSessionQuery, BaseResponse<GetSessionResponseModel>>
    {
        private readonly IReservationAdapter _reservationAdapter;

        public GetSessionQueryHandler(IReservationAdapter reservationAdapter)
        {
            _reservationAdapter = reservationAdapter;
        }

        public async Task<BaseResponse<GetSessionResponseModel>> Handle(GetSessionQuery request, CancellationToken cancellationToken)
        {
            var requestModel = new GetSessionRequestModel(request.IpAddress, request.Port, request.Browser, request.Version);
            return await _reservationAdapter.GetSession(requestModel);
        }
    }
}
