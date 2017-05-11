using Newtonsoft.Json;

namespace WarmSide.WebApi.DTO
{
    public class ForecastSystemInfo
    {
        [JsonProperty("pod")]
        public string Pod { get; set; }
    }
}
