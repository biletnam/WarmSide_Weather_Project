using Newtonsoft.Json;

namespace WarmSide.WebApi.DTO
{
    public class CloudsDTO
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}