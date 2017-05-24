using Newtonsoft.Json;
using System.Collections.Generic;

namespace CityWeatherService.Model
{
    public class ForecastWeather
    {
        public City City { get; set; }
        public ForecastItem[] Forecast { get; set; }
    }
}
