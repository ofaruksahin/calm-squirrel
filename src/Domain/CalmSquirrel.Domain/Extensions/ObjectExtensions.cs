using System.Text.Json;

namespace CalmSquirrel.Domain.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJson<TObj>(this TObj obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static TObj ToObject<TObj>(this string json)
        {
            return JsonSerializer.Deserialize<TObj>(json);
        }
    }
}
