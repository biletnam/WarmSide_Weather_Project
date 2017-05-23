using Newtonsoft.Json;

namespace CityWeatherService.DTO
{
    public class CurrentWeatherDTO
    {
        [JsonProperty("coord")]
        public CoordinatesDTO Coordinates { get; set; }
        [JsonProperty("sys")]
        public CurrentSystemInfoDTO SystemInfo { get; set; }
        [JsonProperty("weather")]
        public WeatherItemDTO[] Weather { get; set; }
        [JsonProperty("main")]
        public CurrentMainDTO Main { get; set; }
        [JsonProperty("wind")]
        public WindDTO Wind { get; set; }
        [JsonProperty("rain")]
        public RainDTO Rain{ get; set; }
        [JsonProperty("clouds")]
        public CloudsDTO Clouds { get; set; }
        [JsonProperty("dt")]
        public long DateTime { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("cod")]
        public int Code { get; set; }
    }
}