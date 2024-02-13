using System.Text.Json.Serialization;

namespace CalmSquirrel.Infrastructure.Data.OBilet.Models.RequestModels
{
    internal class OBiletGetJourneysRequestModel
    {
        [JsonPropertyName("device-session")]
        public OBiletDeviceSessionRequestModel DeviceSession { get; set; }
        [JsonPropertyName("date")]
        public string Date { get; set; }
        [JsonPropertyName("language")]
        public string Language { get; set; }
        [JsonPropertyName("data")]
        public OBiletGetJourneysItemRequestModel Data { get; set; }
    }

    internal class OBiletGetJourneysItemRequestModel
    {
        [JsonPropertyName("origin-id")]
        public int OriginId { get; set; }
        [JsonPropertyName("destination-id")]
        public int DestinationId { get; set; }
        [JsonPropertyName("departure-date")]
        public string DepartureDate { get; set; }
    }
}
