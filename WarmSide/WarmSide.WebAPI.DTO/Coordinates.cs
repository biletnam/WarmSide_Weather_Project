using Newtonsoft.Json;

namespace WarmSide.WebApi.DTO
{
    public class Coordinates
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lon")]
        public double Longtitude { get; set; }
    }
}