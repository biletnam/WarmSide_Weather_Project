using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CityWeatherService.Model
{
    [Serializable]
    public class ForecastWeather
    {
        public City City { get; set; }
        public ForecastItem[] Forecast { get; set; }
    }
}
