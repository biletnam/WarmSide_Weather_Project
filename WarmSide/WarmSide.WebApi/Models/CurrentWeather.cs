using System.Collections.Generic;


namespace WarmSide.WebApi.Models
{
    public class CurrentWeather
    {
        public int id { get; set; }
        public string name { get; set; }
        public Dictionary<string, double> coord { get; set; }
        public Dictionary<string, string>[] weather { get; set; }
        public Dictionary<string, double> main { get; set; }
        public Dictionary<string, double> wind { get; set; }
        public Dictionary<string, double> clouds { get; set; }
        public Dictionary<string, string> sys { get; set; }
    }
}