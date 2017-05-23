using Newtonsoft.Json;

namespace WarmSide.WebApi.DTO
{
    public class WindDTO
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
        [JsonProperty("deg")]
        public double Degree { get; set; }
    }
}