using WarmSide.WebApi.Models;

namespace WarmSide.WebApi.Providers.Interfaces
{
    interface IWeatherProvider
    {
        CurrentWeather GetCurrent(string city);
        ForecastWeather GetForecast(string city);
    }
}
