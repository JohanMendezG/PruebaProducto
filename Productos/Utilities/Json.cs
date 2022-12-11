using System.Text.Json;

namespace Productos.Utilities
{
    public static class Json
    {
        public static string Serialize(object data)
        {
            return JsonSerializer.Serialize(data);
        }

        public static dynamic? Deserealize<T>(string data)
        {
            return string.IsNullOrEmpty(data) ? null : JsonSerializer.Deserialize<T>(data);
        }
    }
}
