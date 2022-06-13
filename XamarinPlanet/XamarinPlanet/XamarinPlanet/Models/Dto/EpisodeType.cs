using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class EpisodeType
    {
        [JsonProperty("@xmlns:itunes")]
        public string XmlnsItunes { get; set; }
        [JsonProperty("#prefix")]
        public string Prefix { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}