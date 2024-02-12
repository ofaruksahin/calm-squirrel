namespace CalmSquirrel.Domain.ValueObjects.RequestModels
{
    public class GetSessionRequestModel
    {
        public string IpAddress { get; private set; }
        public string Port { get; private set; }
        public string BrowserName { get; private set; }
        public string BrowserVersion { get; private set; }

        public GetSessionRequestModel()
        {
        }

        public GetSessionRequestModel(
            string ipAddress,
            string port,
            string browserName,
            string browserVersion)
        {
            IpAddress = ipAddress;
            Port = port;
            BrowserName = browserName;
            BrowserVersion = browserVersion;
        }
    }
}
