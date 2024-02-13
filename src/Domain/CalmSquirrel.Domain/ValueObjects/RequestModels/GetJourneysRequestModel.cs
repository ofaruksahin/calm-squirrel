namespace CalmSquirrel.Domain.ValueObjects.RequestModels
{
    public class GetJourneysRequestModel
    {
        public string SessionId { get; private set; }
        public string DeviceId { get; private set; }
        public DateTime Date { get; private set; }
        public string Language { get; private set; } = "tr-TR";
        public int OriginId { get; private set; }
        public int DestinationId { get; private set; }
        public DateTime DepartureDate { get; private set; }

        public GetJourneysRequestModel(
            string sessionId,
            string deviceId,
            DateTime date,
            int originId, 
            int destinationId,
            DateTime departureDate)
        {
            SessionId = sessionId;
            DeviceId = deviceId;
            Date = date;
            OriginId = originId;
            DestinationId = destinationId;
            DepartureDate = departureDate;
        }
    }
}
