using Newtonsoft.Json;
using System;

namespace CityWeatherService.Model
{
    [Serializable]
    public class CurrentSystemInfo
    {
        public string Country { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }
}