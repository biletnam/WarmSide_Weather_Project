﻿using Newtonsoft.Json;

namespace WarmSide.WebApi.DTO
{
    public class CurrentSystemInfo
    {
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("sunrise")]
        public long Sunrise { get; set; }
        [JsonProperty("sunset")]
        public long Sunset { get; set; }
    }
}