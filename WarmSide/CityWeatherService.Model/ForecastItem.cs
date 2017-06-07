using Newtonsoft.Json;
using System;

namespace CityWeatherService.Model
{
    [Serializable]
    public class ForecastItem
    {
        public long DateTime { get; set; }
        public ForecastMain Main { get; set; }
        public WeatherItem[] Weather { get; set; }
        public Clouds Clouds { get; set; }
        public Wind Wind { get; set; }
        public ForecastSystemInfo SystemInfo { get; set; }
        public string DateTimeText { get; set; }
    }
}
