namespace CalmSquirrel.Domain.ValueObjects
{
    public class BaseResponse<TResponse>
        where TResponse : class
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public TResponse Data { get; set; }
    }
}
