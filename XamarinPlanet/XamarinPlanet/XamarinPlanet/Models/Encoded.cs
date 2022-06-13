using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Encoded
    {
        [JsonProperty("@xmlns:content")]
        public string XmlnsContent { get; set; }
        [JsonProperty("#prefix")]
        public string Prefix { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}