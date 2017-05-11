using Newtonsoft.Json;

namespace CityWeatherService.Model
{
    public class ForecastSystemInfo
    {
        [JsonProperty("pod")]
        public string Pod { get; set; }
    }
}
