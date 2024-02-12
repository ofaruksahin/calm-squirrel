namespace CalmSquirrel.Domain.ValueObjects.RequestModels
{
    public class GetJourneysRequestModel
    {
        public string SessionId { get; private set; }
        public string DeviceId { get; private set; }
        public string Date { get; private set; }
        public string Language { get; private set; }
        public int OriginId { get; private set; }
        public int DestinationId { get; private set; }
        public string DepartureDate { get; private set; }
    }
}
