using CalmSquirrel.Domain.ValueObjects;
using CalmSquirrel.Domain.ValueObjects.RequestModels;
using CalmSquirrel.Domain.ValueObjects.ResponseModels;

namespace CalmSquirrel.Domain.Contracts
{
    public interface IReservationAdapter
    {
        Task<BaseResponse<GetSessionResponseModel>> GetSession(GetSessionRequestModel model);
        Task<BaseResponse<List<GetBusLocationsResponseModel>>> GetBusLocations(GetBusLocationsRequestModel model);
        Task<BaseResponse<List<GetJourneyResponseModel>>> GetJourneys(GetJourneysRequestModel model);
    }
}
