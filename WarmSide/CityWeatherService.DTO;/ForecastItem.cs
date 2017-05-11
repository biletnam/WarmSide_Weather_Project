using Newtonsoft.Json;

namespace CityWeatherService.DTO
{
    public class ForecastItem
    {
        [JsonProperty("dt")]
        public long DateTime { get; set; }
        [JsonProperty("main")]
        public ForecastMain Main { get; set; }
        [JsonProperty("weather")]
        public WeatherItem[] Weather { get; set; }
        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
        [JsonProperty("sys")]
        public ForecastSystemInfo SystemInfo { get; set; }
        [JsonProperty("dt_txt")]
        public string DateTimeText { get; set; }
    }
}
