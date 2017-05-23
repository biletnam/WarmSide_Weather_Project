using Newtonsoft.Json;

namespace CityWeatherService.DTO
{
    public class WindDTO
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
        [JsonProperty("deg")]
        public double Degree { get; set; }
    }
}