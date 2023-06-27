using System.Text.Json;

namespace GenericJsonSerializer
{
    public static class GenericSerializer
    {
        public static string Serialize<T>(this T param) => JsonSerializer.Serialize(param);

        public static T Deserialize<T>(this string json) => JsonSerializer.Deserialize<T>(json);
    }
}