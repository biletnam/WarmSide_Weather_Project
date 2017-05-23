using CityWeatherService.Interfaces;
using System.Net.Http;

namespace CityWeatherService.Tests
{
    public class HttpClientFactoryMock: IHttpClientFactory
    {
        public HttpClient CreateClient()
        {
            return new HttpClient(new HttpMessageHandlerMock());
        }
    }
}
