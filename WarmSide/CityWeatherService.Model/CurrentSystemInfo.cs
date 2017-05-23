using Newtonsoft.Json;

namespace CityWeatherService.Model
{
    public class CurrentSystemInfo
    {
        public string Country { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }
}