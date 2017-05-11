using CityWeatherService.Model;

namespace CityWeatherService.Interfaces
{
    public interface IWeatherService
    {
        CurrentWeatherAPIResponse GetCurrent(string city);
        ForecastWeatherApiResponse GetForecast(string city);
    }
}
