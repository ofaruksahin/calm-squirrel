using System.Text.Json.Serialization;

namespace CalmSquirrel.Infrastructure.Data.OBilet.Models.ResponseModels
{
    internal class OBiletGetJourneyResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("partner-id")]
        public int PartnerId { get; set; }
        [JsonPropertyName("partner-name")]
        public string PartnerName { get; set; }
        [JsonPropertyName("bus-type")]
        public string BusType { get; set; }
        [JsonPropertyName("bus-type-name")]
        public string BusTypeName { get; set; }
        [JsonPropertyName("total-seats")]
        public int TotalSeats { get; set; }
        [JsonPropertyName("available-seats")]
        public int AvailableSeats { get; set; }
        [JsonPropertyName("journey")]
        public OBiletGetJourneyItemResponseModel Journey { get; set; }
    }

    internal class OBiletGetJourneyItemResponseModel
    {
        [JsonPropertyName("bus")]
        public string Bus { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("stops")]
        public List<OBiletGetJourneyStopResponseModel> Stops { get; set; }
        [JsonPropertyName("origin")]
        public string Origin { get; set; }
        [JsonPropertyName("destination")]
        public string Destination { get; set; }
        [JsonPropertyName("departure")]
        public DateTime Departure { get; set; }
        [JsonPropertyName("arrival")]
        public DateTime Arrival { get; set; }
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        [JsonPropertyName("duration")]
        public string Duration { get; set; }
        [JsonPropertyName("original-price")]
        public double OriginalPrice { get; set; }
        [JsonPropertyName("internet-price")]
        public double InternetPrice { get; set; }
        [JsonPropertyName("provider-internet-price")]
        public double? ProviderInternetPrice { get; set; }
        [JsonPropertyName("sorting-price")]
        public double SortingPrice { get; set; }
        [JsonPropertyName("features")]
        public List<string> Features { get; set; }
    }

    internal class OBiletGetJourneyStopResponseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("station")]
        public string Station { get; set; }
        [JsonPropertyName("time")]
        public string Time { get; set; }
        [JsonPropertyName("is-origin")]
        public bool IsOrigin { get; set; }
        [JsonPropertyName("is-destination")]
        public bool IsDestination { get; set; }
        [JsonPropertyName("is-segment-stop")]
        public bool IsSegmentStop { get; set; }
        [JsonPropertyName("index")]
        public int Index { get; set; }
    }
}
