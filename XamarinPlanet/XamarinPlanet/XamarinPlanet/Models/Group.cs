using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace XamarinPlanet.Models
{
    public class Group
    {
        [JsonProperty("media:title")]
        public string Title { get; set; }
        [JsonProperty("media:content")]
        public Content Content { get; set; }
        [JsonProperty("media:thumbnail")]
        public Thumbnail Thumbnail { get; set; }
        [JsonProperty("media:description")]
        public string Description { get; set; }
        [JsonProperty("media:community")]
        public Community Community { get; set; }

        [JsonProperty("@xmlns:media")]
        public string XmlnsMedia { get; set; }
    }
}