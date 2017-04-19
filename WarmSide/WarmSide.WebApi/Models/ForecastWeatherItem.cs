using System.Collections.Generic;

namespace WarmSide.WebApi.Models
{
    public class ForecastWeatherItem
    {
        public int dt { get; set; }
        public Dictionary<string, double> main { get; set; }
        public Dictionary<string, string>[] weather { get; set; }
        public Dictionary<string, double> clouds { get; set; }
        public Dictionary<string, double> wind { get; set; }
        public Dictionary<string, string> rain { get; set; }
        public string dt_txt{ get; set; }
    }
}