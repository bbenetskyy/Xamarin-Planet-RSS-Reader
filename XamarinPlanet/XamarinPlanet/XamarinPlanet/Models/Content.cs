using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Content
    {
        [JsonProperty("@url")]
        public string Url { get; set; }
        [JsonProperty("@type")]
        public string Type { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
        [JsonProperty("@width")]
        public string Width { get; set; }
        [JsonProperty("@height")]
        public string Height { get; set; }
    }
}