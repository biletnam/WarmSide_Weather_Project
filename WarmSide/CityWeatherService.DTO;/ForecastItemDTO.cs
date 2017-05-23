using Newtonsoft.Json;

namespace CityWeatherService.DTO
{
    public class ForecastItemDTO
    {
        [JsonProperty("dt")]
        public long DateTime { get; set; }
        [JsonProperty("main")]
        public ForecastMainDTO Main { get; set; }
        [JsonProperty("weather")]
        public WeatherItemDTO[] Weather { get; set; }
        [JsonProperty("clouds")]
        public CloudsDTO Clouds { get; set; }
        [JsonProperty("wind")]
        public WindDTO Wind { get; set; }
        [JsonProperty("sys")]
        public ForecastSystemInfoDTO SystemInfo { get; set; }
        [JsonProperty("dt_txt")]
        public string DateTimeText { get; set; }
    }
}
