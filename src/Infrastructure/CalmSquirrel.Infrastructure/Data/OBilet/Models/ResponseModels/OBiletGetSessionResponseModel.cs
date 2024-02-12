using System.Text.Json.Serialization;

namespace CalmSquirrel.Infrastructure.Data.OBilet.Models.ResponseModels
{
    internal class OBiletGetSessionResponseModel
    {
        [JsonPropertyName("session-id")]
        public string SessionId { get; set; }
        [JsonPropertyName("device-id")]
        public string DeviceId { get; set; }
        [JsonPropertyName("affiliate")]
        public string Affiliate { get; set; }
        [JsonPropertyName("device-type")]
        public int DeviceType { get; set; }
        [JsonPropertyName("device")]
        public string Device { get; set; }
        [JsonPropertyName("ip-country")]
        public string IpCountry { get; set; }
    }
}
