using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Enclosure
    {
        [JsonProperty("@url")]
        public string Url { get; set; }
        [JsonProperty("@type")]
        public string Type { get; set; }
        [JsonProperty("@length")]
        public string Length { get; set; }
    }
}