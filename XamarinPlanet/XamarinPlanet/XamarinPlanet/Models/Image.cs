using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Image
    {
        [JsonProperty("@url")]
        public string Url { get; set; }
        [JsonProperty("@title")]
        public string Title { get; set; }
        [JsonProperty("@link")]
        public string Link { get; set; }

        [JsonProperty("@xmlns:itunes")]
        public string XmlnsItunes { get; set; }
        [JsonProperty("@href")]
        public string Href { get; set; }
    }
}