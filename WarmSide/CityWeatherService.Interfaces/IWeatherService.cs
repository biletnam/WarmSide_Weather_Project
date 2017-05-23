using CityWeatherService.Model;
using System.Threading.Tasks;

namespace CityWeatherService.Interfaces
{
    public interface IWeatherService
    {
        Task<CurrentWeatherAPIResponse> GetCurrentAsync(string city);
        ForecastWeatherApiResponse GetForecastAsync(string city);
    }
}
