using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Target
    {
        [JsonProperty("@xmlns:pingback")]
        public string XmlnsPingback { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}