using System.Net.Http;


namespace CityWeatherService.Interfaces
{
    public interface IHttpClientFactory
    {
        HttpClient CreateClient();
    }
}
