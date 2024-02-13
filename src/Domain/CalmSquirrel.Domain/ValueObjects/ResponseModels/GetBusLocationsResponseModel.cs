namespace CalmSquirrel.Domain.ValueObjects.ResponseModels
{
    public class GetBusLocationsResponseModel
    {
        public int Id { get; private set; }
        public string LongName { get; private set; }

        public GetBusLocationsResponseModel(int id, string longName)
        {
            Id = id;
            LongName = longName;
        }
    }
}
