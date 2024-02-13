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
                Message = !string.IsNullOrEmpty(responseModel.UserMessage) ? responseModel.UserMessage : responseModel.Message,
                Data = new GetSessionResponseModel(responseModel.Data?.SessionId, responseModel.Data?.DeviceId)
            };
        }

        public static OBiletGetBusLocationsRequestModel ToRequestModel(this GetBusLocationsRequestModel requestModel)
        {
            return new OBiletGetBusLocationsRequestModel
            {
                Data = requestModel.SearchText,
                DeviceSession = new OBiletDeviceSessionRequestModel
                {
                    SessionId = requestModel.SessionId,
                    DeviceId = requestModel.DeviceId,
                },
                Date = requestModel.Date,
                Language = requestModel.Language,
            };
        }

        public static BaseResponse<List<GetBusLocationsResponseModel>> ToDomainModel(this BaseOBiletResponse<List<OBiletGetBusLocationsResponseModel>> responseModel)
        {
            return new BaseResponse<List<GetBusLocationsResponseModel>>
            {
                Message = !string.IsNullOrEmpty(responseModel.UserMessage) ? responseModel.UserMessage : responseModel.Message,
                IsSuccess = responseModel.Status == "Success",
                Data = responseModel.Data.Select(item => new GetBusLocationsResponseModel(item.Id, item.LongName)).ToList()
            };
        }

        public static OBiletGetJourneysRequestModel ToRequestModel(this GetJourneysRequestModel requestModel)
        {
            return new OBiletGetJourneysRequestModel
            {
                DeviceSession = new OBiletDeviceSessionRequestModel
                {
                    SessionId = requestModel.SessionId,
                    DeviceId = requestModel.DeviceId
                },
                Date = requestModel.Date.ToString("yyyy/MM/dd"),
                Language = requestModel.Language,
                Data = new OBiletGetJourneysItemRequestModel
                {
                    OriginId = requestModel.OriginId,
                    DestinationId = requestModel.DestinationId,
                    DepartureDate = requestModel.DepartureDate.ToString("yyyy/MM/dd")
                }
            };
        }

        public static BaseResponse<List<GetJourneyResponseModel>> ToDomainModel(this BaseOBiletResponse<List<OBiletGetJourneyResponseModel>> responseModel)
        {
            return new BaseResponse<List<GetJourneyResponseModel>>
            {
                IsSuccess = responseModel.Status == "Success",
                Message = !string.IsNullOrEmpty(responseModel.UserMessage) ? responseModel.UserMessage : responseModel.Message,
                Data = responseModel.Data.Select(item => new GetJourneyResponseModel
                {
                    Id = item.Id,
                    PartnerId = item.PartnerId,
                    PartnerName = item.PartnerName,
                    BusType = item.BusType,
                    BusTypeName = item.BusTypeName,
                    TotalSeats =item.TotalSeats,
                    AvailableSeats = item.AvailableSeats,
                    Journey = new JourneyItem
                    {
                        Bus = item.Journey.Bus,
                        Code = item.Journey.Code,
                        Stops = item.Journey.Stops.Select(stop => new JourneyStop
                        {
                            Id = stop.Id,
                            Name = stop.Name,
                            Station = stop.Station,
                            Time = stop.Time,
                            IsOrigin = stop.IsOrigin,
                            IsDestination = stop.IsDestination,
                            IsSegmentStop = stop.IsSegmentStop,
                            Index = stop.Index
                        }).ToList(),
                        Origin = item.Journey.Origin,
                        Destination = item.Journey.Destination,
                        Departure = item.Journey.Departure,
                        Arrival = item.Journey.Arrival,
                        Currency = item.Journey.Currency,
                        Duration = item.Journey.Duration,
                        OriginalPrice = item.Journey.OriginalPrice,
                        InternetPrice = item.Journey.InternetPrice,
                        ProviderInternetPrice = item.Journey.ProviderInternetPrice,
                        SortingPrice = item.Journey.SortingPrice,
                        Features = item.Journey.Features
                    }
                }).ToList()
            };
        }
    }
}
