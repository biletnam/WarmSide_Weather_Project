using Newtonsoft.Json;
using System;

namespace CityWeatherService.Model
{
    [Serializable]
    public class ForecastMain
    {
        public double Temperature { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public double Pressure { get; set; }
        public double SeaLevel { get; set; }
        public double GroundLevel { get; set; }
        public double Humidity { get; set; }
        public double TemperatureCoefficient { get; set; }
    }
}
