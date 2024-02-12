namespace CalmSquirrel.Domain.ValueObjects.RequestModels
{
    public class GetBusLocationsRequestModel
    {
        public string SearchText { get; private set; }
        public string SessionId { get; private set; }
        public string DeviceId { get; private set; }
        public DateTime Date { get; private set; }
        public string Language { get; private set; }

        public GetBusLocationsRequestModel()
        {
        }

        public GetBusLocationsRequestModel(
            string searchText,
            string sessionId,
            string deviceId,
            DateTime date,
            string language)
        {
            SearchText = searchText;
            SessionId = sessionId;
            DeviceId = deviceId;
            Date = date;
            Language = language;
        }
    }
}
