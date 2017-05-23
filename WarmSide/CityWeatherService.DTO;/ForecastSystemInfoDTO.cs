using Newtonsoft.Json;

namespace CityWeatherService.DTO
{
    public class ForecastSystemInfoDTO
    {
        [JsonProperty("pod")]
        public string Pod { get; set; }
    }
}
