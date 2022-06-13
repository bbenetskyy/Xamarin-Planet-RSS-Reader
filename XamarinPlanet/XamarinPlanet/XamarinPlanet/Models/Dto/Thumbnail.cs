using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Thumbnail
    {
        [JsonProperty("@url")]
        public string Url { get; set; }
        [JsonProperty("@width")]
        public string Width { get; set; }
        [JsonProperty("@height")]
        public string Height { get; set; }
        [JsonProperty("@xmlns:media")]
        public string XmlnsMedia { get; set; }
    }
}