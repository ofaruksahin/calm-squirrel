using CalmSquirrel.Domain.ValueObjects;
using CalmSquirrel.Domain.ValueObjects.RequestModels;
using CalmSquirrel.Domain.ValueObjects.ResponseModels;
using CalmSquirrel.Infrastructure.Data.OBilet.Models.RequestModels;
using CalmSquirrel.Infrastructure.Data.OBilet.Models.ResponseModels;

namespace CalmSquirrel.Infrastructure.Data.OBilet.Models.Extensions
{
    internal static class ModelExtensions
    {
        public static OBiletGetSessionRequestModel ToRequestModel(this GetSessionRequestModel requestModel)
        {
            return new OBiletGetSessionRequestModel
            {
                Connection = new OBiletGetSessionConnectionRequestModel
                {
                    IpAddress = requestModel.IpAddress,
                    Port = requestModel.Port
                },
                Browser = new OBiletGetSessionBrowserRequestModel
                {
                    Name = requestModel.BrowserName,
                    Version = requestModel.BrowserVersion
                }
            };
        }

        public static BaseResponse<GetSessionResponseModel> ToDomainModel(this BaseOBiletResponse<OBiletGetSessionResponseModel> responseModel)
        {
            return new BaseResponse<GetSessionResponseModel>
            {
                IsSuccess = responseModel.Status == "Success",
                Message = responseModel.Message,
                Data = new GetSessionResponseModel(responseModel.Data?.SessionId, responseModel.Data?.DeviceId)
            };
        }
    }
}
