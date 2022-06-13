using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Chapters
    {
        [JsonProperty("@xmlns:podcast")]
        public string XmlnsPodcast { get; set; }
        [JsonProperty("@url")]
        public string Url { get; set; }
        [JsonProperty("@type")]
        public string Type { get; set; }
    }
}