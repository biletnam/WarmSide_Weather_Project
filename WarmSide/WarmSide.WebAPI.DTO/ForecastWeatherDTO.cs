using Newtonsoft.Json;
using System.Collections.Generic;

namespace WarmSide.WebApi.DTO
{
    public class ForecastWeatherDTO
    {
        [JsonProperty("city")]
        public CityDTO City { get; set; }
        [JsonProperty("list")]
        public ForecastItemDTO[] Forecast { get; set; }
    }
}
