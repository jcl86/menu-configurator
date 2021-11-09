using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MenuConfigurator.Web.Client
{
    public static class ApiExtensions
    {
        public static string ToJson<TContent>(this TContent content)
        {
            var json = JsonSerializer.Serialize(content, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return json;
        }

        public static StringContent JsonContent<TContent>(this TContent content, string contentType = "application/json")
        {
            var json = content.ToJson();
            return new StringContent(json, Encoding.UTF8, contentType);
        }

        public static async Task<TModel> ReadJsonResponse<TModel>(this HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TModel>(json, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return result;
        }
    }
}
