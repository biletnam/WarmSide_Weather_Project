using Newtonsoft.Json;


namespace CityWeatherService.DTO
{
    public class CityDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("coord")]
        public CoordinatesDTO Coordinates { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
