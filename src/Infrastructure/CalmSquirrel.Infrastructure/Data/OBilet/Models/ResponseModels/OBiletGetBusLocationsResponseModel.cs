using System.Text.Json.Serialization;

namespace CalmSquirrel.Infrastructure.Data.OBilet.Models.ResponseModels
{
    internal class OBiletGetBusLocationsResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("long-name")]
        public string LongName { get; set; }
    }
}
