using System.Net.Http;
using System.Threading.Tasks;

namespace MenuConfigurator.Model
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, string url, HttpContent content)
        {
            return await client.SendAsync(new HttpRequestMessage(new HttpMethod("PATCH"), url)
            {
                Content = content
            });
        }
    }
}