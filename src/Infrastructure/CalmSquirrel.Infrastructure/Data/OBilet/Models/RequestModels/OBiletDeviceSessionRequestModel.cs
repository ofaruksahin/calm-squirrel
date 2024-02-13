using System.Text.Json.Serialization;

namespace CalmSquirrel.Infrastructure.Data.OBilet.Models.RequestModels
{
    internal class OBiletDeviceSessionRequestModel
    {
        [JsonPropertyName("session-id")]
        public string SessionId { get; set; }
        [JsonPropertyName("device-id")]
        public string DeviceId { get; set; }
    }
}
