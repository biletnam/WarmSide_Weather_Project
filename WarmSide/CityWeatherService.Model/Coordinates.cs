using Newtonsoft.Json;
using System;

namespace CityWeatherService.Model
{
    [Serializable]
    public class Coordinates
    {
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
    }
}