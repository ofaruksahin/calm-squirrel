namespace CalmSquirrel.Domain.ValueObjects.ResponseModels
{
    public class GetSessionResponseModel
    {
        public string SessionId { get; set; }
        public string DeviceId { get; set; }

        public GetSessionResponseModel(string sessionId, string deviceId)
        {
            SessionId = sessionId;
            DeviceId = deviceId;
        }
    }
}
