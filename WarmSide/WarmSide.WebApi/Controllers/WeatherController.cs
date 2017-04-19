using System.Web.Http;
using WarmSide.WebApi.Models;
using WarmSide.WebApi.Providers.Interfaces;
using WarmSide.WebApi.Providers.Classes;
using System.Web.Http.Cors;

namespace WarmSide.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WeatherController : ApiController
    {
        public CurrentWeather GetCurrentWeather(string city)
        {
            IWeatherProvider weatherProvider = new OpenWeatherApiWeatherProvider();
            return weatherProvider.GetCurrent(city);
        }

        public ForecastWeather GetForecast(string city)
        {
            IWeatherProvider weatherProvider = new OpenWeatherApiWeatherProvider();
            return weatherProvider.GetForecast(city);
        }
    }
}
