using System.Text.Json.Serialization;

namespace CalmSquirrel.Infrastructure.Data.OBilet.Models.RequestModels
{
    internal class OBiletGetSessionRequestModel
    {
        [JsonPropertyName("type")]
        public int Type { get; set; } = 1;
        [JsonPropertyName("connection")]
        public OBiletGetSessionConnectionRequestModel Connection { get; set; }
        [JsonPropertyName("browser")]
        public OBiletGetSessionBrowserRequestModel Browser { get; set; }
    }

    internal class OBiletGetSessionConnectionRequestModel
    {
        [JsonPropertyName("ip-address")]
        public string IpAddress { get; set; }
        [JsonPropertyName("port")]
        public string Port { get; set; }
    }

    internal class OBiletGetSessionBrowserRequestModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}
