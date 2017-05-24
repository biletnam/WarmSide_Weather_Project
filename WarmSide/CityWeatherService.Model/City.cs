using Newtonsoft.Json;

namespace CityWeatherService.Model
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coordinates Coordinates { get; set; }
        public string Country { get; set; }
    }
}
