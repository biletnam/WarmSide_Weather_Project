using Newtonsoft.Json;

namespace CityWeatherService.Model
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}