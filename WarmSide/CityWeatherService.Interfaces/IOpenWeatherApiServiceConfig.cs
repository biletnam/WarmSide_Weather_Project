namespace CityWeatherService.Interfaces
{
    public interface IOpenWeatherApiServiceConfig
    {
        string WeatherServerApiKey { get; }
        string WeatherServerUri { get; }
    }
}
