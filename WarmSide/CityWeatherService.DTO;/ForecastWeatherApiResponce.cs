using Newtonsoft.Json;
using System.Collections.Generic;

namespace CityWeatherService.DTO
{
    public class ForecastWeatherApiResponse
    {
        [JsonProperty("city")]
        public City City { get; set; }
        [JsonProperty("coord")]
        public Coordinates Coordinates { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("cod")]
        public int Code { get; set; }
        [JsonProperty("message")]
        public double Message { get; set; }
        [JsonProperty("cnt")]
        public int Counter { get; set; }
        [JsonProperty("list")]
        public ForecastItem[] Forecast { get; set; }
    }
}
