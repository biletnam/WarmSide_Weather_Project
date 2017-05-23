using Newtonsoft.Json;

namespace CityWeatherService.DTO
{
    public class CoordinatesDTO
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lon")]
        public double Longtitude { get; set; }
    }
}