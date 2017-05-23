using Newtonsoft.Json;

namespace WarmSide.WebApi.DTO
{
    public class CityDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
