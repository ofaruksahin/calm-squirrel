using CalmSquirrel.Domain.Contracts;

namespace CalmSquirrel.Infrastructure.Data.OBilet.Options
{
    public class OBiletOptions : IOptions
    {
        public string Key => "CalmSquirrel:Infrastructure:Data:OBilet";

        public string BaseUrl { get; set; }
        public string AuthorizationKey { get; set; }
    }
}
