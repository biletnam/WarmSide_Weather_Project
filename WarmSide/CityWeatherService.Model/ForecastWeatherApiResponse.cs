using Newtonsoft.Json;
using System.Collections.Generic;

namespace CityWeatherService.Model
{
    public class ForecastWeatherApiResponse
    {
        public City City { get; set; }
        public Coordinates Coordinates { get; set; }
        public string Country { get; set; }
        public ForecastItem[] Forecast { get; set; }
    }
}
