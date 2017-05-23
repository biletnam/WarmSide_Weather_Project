using Newtonsoft.Json;
using System.Collections.Generic;

namespace WarmSide.WebApi.DTO
{
    public class ForecastWeatherDTO
    {
        [JsonProperty("city")]
        public CityDTO City { get; set; }
        [JsonProperty("coord")]
        public CoordinatesDTO Coordinates { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("list")]
        public ForecastItemDTO[] Forecast { get; set; }
    }
}
