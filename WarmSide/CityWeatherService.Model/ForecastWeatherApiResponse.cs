using Newtonsoft.Json;
using System.Collections.Generic;

namespace CityWeatherService.Model
{
    public class ForecastWeatherApiResponse
    {
        [JsonProperty("city")]
        public City City { get; set; }
        [JsonProperty("coord")]
        public Coordinates Coordinates { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("list")]
        public ForecastItem[] Forecast { get; set; }
    }
}
