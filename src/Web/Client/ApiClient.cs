using System.Net.Http;

namespace MenuConfigurator.Web.Client
{
    public class ApiClient
    {
        public HttpClient Client { get; }

        public ApiClient(HttpClient client)
        {
            Client = client;
        }
    }
}
