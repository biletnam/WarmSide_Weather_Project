using Newtonsoft.Json;

namespace WarmSide.WebApi.DTO
{
    public class City
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
