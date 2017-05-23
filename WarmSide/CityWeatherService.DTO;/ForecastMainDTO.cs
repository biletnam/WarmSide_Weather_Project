using Newtonsoft.Json;

namespace CityWeatherService.DTO
{
    public class ForecastMainDTO
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
        [JsonProperty("temp_min")]
        public double MinTemperature { get; set; }
        [JsonProperty("temp_max")]
        public double MaxTemperature { get; set; }
        [JsonProperty("pressure")]
        public double Pressure { get; set; }
        [JsonProperty("sea_level")]
        public double SeaLevel { get; set; }
        [JsonProperty("grnd_level")]
        public double GroundLevel { get; set; }
        [JsonProperty("humidity")]
        public double Humidity { get; set; }
        [JsonProperty("temp_kf")]
        public double TemperatureCoefficient { get; set; }
    }
}
