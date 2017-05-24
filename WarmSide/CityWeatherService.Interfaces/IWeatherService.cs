using CityWeatherService.Model;
using System.Threading.Tasks;

namespace CityWeatherService.Interfaces
{
    public interface IWeatherService
    {
        Task<CurrentWeather> GetCurrentAsync(string city);
        Task<ForecastWeather> GetForecastAsync(string city);
    }
}
