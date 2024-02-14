namespace CalmSquirrel.Domain.ValueObjects.ResponseModels
{
    public class GetJourneyResponseModel
    {
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string BusType { get; set; }
        public string BusTypeName { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public JourneyItem Journey { get; set; }
        public string OriginLocation { get; set; }
        public string DestinationLocation { get; set; }
    }

    public class JourneyItem
    {
        public string Bus { get; set; }
        public string Code { get; set; }
        public List<JourneyStop> Stops { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public string Currency { get; set; }
        public string Duration { get; set; }
        public double OriginalPrice { get; set; }
        public double InternetPrice { get; set; }
        public double? ProviderInternetPrice { get; set; }
        public double SortingPrice { get; set; }
        public List<string> Features { get; set; }

        public JourneyItem()
        {
            Stops = new List<JourneyStop>();
            Features = new List<string>();
        }
    }

    public class JourneyStop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Station { get; set; }
        public string Time { get; set; }
        public bool IsOrigin { get; set; }
        public bool IsDestination { get; set; }
        public bool IsSegmentStop { get; set; }
        public int Index { get; set; }
    }
}
