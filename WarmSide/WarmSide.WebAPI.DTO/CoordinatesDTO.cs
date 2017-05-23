using Newtonsoft.Json;

namespace WarmSide.WebApi.DTO
{
    public class CoordinatesDTO
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lon")]
        public double Longtitude { get; set; }
    }
}