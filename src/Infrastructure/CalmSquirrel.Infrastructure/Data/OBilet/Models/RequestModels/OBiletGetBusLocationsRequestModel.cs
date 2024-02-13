using System.Text.Json.Serialization;

namespace CalmSquirrel.Infrastructure.Data.OBilet.Models.RequestModels
{
    internal class OBiletGetBusLocationsRequestModel
    {
        [JsonPropertyName("data")]
        public string Data { get; set; }
        [JsonPropertyName("device-session")]
        public OBiletDeviceSessionRequestModel DeviceSession { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("language")]
        public string Language { get; set; }
    }
}
