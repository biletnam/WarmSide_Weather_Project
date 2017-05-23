using Newtonsoft.Json;

namespace CityWeatherService.DTO
{
    public class CurrentMainDTO
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
        [JsonProperty("humidity")]
        public double Humidity { get; set; }
        [JsonProperty("pressure")]
        public double Pressure { get; set; }
        [JsonProperty("temp_min")]
        public double MinTemperature { get; set; }
        [JsonProperty("temp_max")]
        public double MaxTemperature { get; set; }
    }
}