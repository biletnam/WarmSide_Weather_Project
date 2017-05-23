using CityWeatherService.Interfaces;
using System.Net.Http;

namespace CityWeatherService.Services
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient()
        {
            return new HttpClient(new HttpClientHandler());
        }
    }
}
