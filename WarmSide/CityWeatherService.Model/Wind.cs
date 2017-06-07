using Newtonsoft.Json;
using System;

namespace CityWeatherService.Model
{
    [Serializable]
    public class Wind
    {
        public double Speed { get; set; }
        public double Degree { get; set; }
    }
}