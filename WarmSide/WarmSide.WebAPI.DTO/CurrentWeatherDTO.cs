using Newtonsoft.Json;

namespace WarmSide.WebApi.DTO
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
        [JsonProperty("dt")]
        public long DateTime { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}