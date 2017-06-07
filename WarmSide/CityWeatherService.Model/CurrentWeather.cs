using Newtonsoft.Json;
using System;

namespace CityWeatherService.Model
{
    [Serializable]
    public class CurrentWeather
    {
        public Coordinates Coordinates { get; set; }
        public CurrentSystemInfo SystemInfo { get; set; }
        public WeatherItem[] Weather { get; set; }
        public CurrentMain Main { get; set; }
        public Wind Wind { get; set; }
        public long DateTime { get; set; }
        public string Name { get; set; }
    }
}