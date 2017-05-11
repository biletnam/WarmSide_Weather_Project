using Newtonsoft.Json;

namespace CityWeatherService.DTO
{
    public class Rain
    {
        [JsonProperty("3h")]
        public double h { get; set; }
    }
}
