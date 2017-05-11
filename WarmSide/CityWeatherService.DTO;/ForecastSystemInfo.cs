using Newtonsoft.Json;

namespace CityWeatherService.DTO
{
    public class ForecastSystemInfo
    {
        [JsonProperty("pod")]
        public string Pod { get; set; }
    }
}
