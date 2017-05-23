using Newtonsoft.Json;

namespace CityWeatherService.Model
{
    public class WeatherItem
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}