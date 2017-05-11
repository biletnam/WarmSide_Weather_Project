using Newtonsoft.Json;

namespace WarmSide.WebApi.DTO
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}