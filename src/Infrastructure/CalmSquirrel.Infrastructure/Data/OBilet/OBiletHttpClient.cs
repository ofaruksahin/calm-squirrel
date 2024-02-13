using CalmSquirrel.Domain.Attributes;
using CalmSquirrel.Domain.Contracts;
using CalmSquirrel.Domain.ValueObjects;
using CalmSquirrel.Domain.ValueObjects.RequestModels;
using CalmSquirrel.Domain.ValueObjects.ResponseModels;
using CalmSquirrel.Infrastructure.Data.OBilet.Exceptions;
using CalmSquirrel.Infrastructure.Data.OBilet.Models.Extensions;
using CalmSquirrel.Infrastructure.Data.OBilet.Models.RequestModels;
using CalmSquirrel.Infrastructure.Data.OBilet.Models.ResponseModels;
using CalmSquirrel.Infrastructure.Data.OBilet.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace CalmSquirrel.Infrastructure.Data.OBilet
{
    [Inject(ServiceLifetime.Scoped)]
    public class OBiletHttpClient : IReservationAdapter
    {
        private readonly HttpClient _httpClient;

        public OBiletHttpClient(
            IHttpClientFactory _httpClientFactory,
            OBiletOptions options)
        {
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(options.BaseUrl);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", options.AuthorizationKey);
        }

        public async Task<BaseResponse<GetSessionResponseModel>> GetSession(GetSessionRequestModel model)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync<OBiletGetSessionRequestModel>("api/client/getsession", model.ToRequestModel());
            if (!httpResponse.IsSuccessStatusCode)
                throw new OBiletInvalidResponseException();
            var obiletResponseModel = await httpResponse.Content.ReadFromJsonAsync<BaseOBiletResponse<OBiletGetSessionResponseModel>>();
            return obiletResponseModel.ToDomainModel();
        }

        public async Task<BaseResponse<List<GetBusLocationsResponseModel>>> GetBusLocations(GetBusLocationsRequestModel model)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync<OBiletGetBusLocationsRequestModel>("api/location/getbuslocations", model.ToRequestModel());
            if (!httpResponse.IsSuccessStatusCode)
                throw new OBiletInvalidResponseException();
            var obiletResponseModel = await httpResponse.Content.ReadFromJsonAsync<BaseOBiletResponse<List<OBiletGetBusLocationsResponseModel>>>();
            return obiletResponseModel.ToDomainModel();
        }

        public async Task<BaseResponse<List<GetJourneyResponseModel>>> GetJourneys(GetJourneysRequestModel model)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync<OBiletGetJourneysRequestModel>("api/journey/getbusjourneys", model.ToRequestModel());
            if (!httpResponse.IsSuccessStatusCode)
                throw new OBiletInvalidResponseException();
            var obiletResponseModel = await httpResponse.Content.ReadFromJsonAsync<BaseOBiletResponse<List<OBiletGetJourneyResponseModel>>>();
            return obiletResponseModel.ToDomainModel();
        }     
    }
}
