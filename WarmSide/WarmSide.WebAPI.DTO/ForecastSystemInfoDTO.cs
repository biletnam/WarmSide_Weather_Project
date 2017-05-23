using Newtonsoft.Json;

namespace WarmSide.WebApi.DTO
{
    public class ForecastSystemInfoDTO
    {
        [JsonProperty("pod")]
        public string Pod { get; set; }
    }
}
