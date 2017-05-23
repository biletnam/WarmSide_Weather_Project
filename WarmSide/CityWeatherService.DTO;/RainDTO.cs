using Newtonsoft.Json;

namespace CityWeatherService.DTO
{
    public class RainDTO
    {
        [JsonProperty("3h")]
        public double h { get; set; }
    }
}
