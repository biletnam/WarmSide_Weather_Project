using Newtonsoft.Json;

namespace CityWeatherService.DTO
{
    public class CurrentWeatherAPIResponse
    {
        [JsonProperty("coord")]
        public Coordinates Coordinates { get; set; }
        [JsonProperty("sys")]
        public CurrentSystemInfo SystemInfo { get; set; }
        [JsonProperty("weather")]
        public WeatherItem[] Weather { get; set; }
        [JsonProperty("main")]
        public CurrentMain Main { get; set; }
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
        [JsonProperty("rain")]
        public Rain Rain{ get; set; }
        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }
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