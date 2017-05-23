using Newtonsoft.Json;

namespace CityWeatherService.DTO
{
    public class CloudsDTO
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}