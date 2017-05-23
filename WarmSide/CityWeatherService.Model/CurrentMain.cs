using Newtonsoft.Json;

namespace CityWeatherService.Model
{
    public class CurrentMain
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
    }
}