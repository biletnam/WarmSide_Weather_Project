using Newtonsoft.Json;

namespace CityWeatherService.DTO
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}