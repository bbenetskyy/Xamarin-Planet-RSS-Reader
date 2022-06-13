using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Server
    {
        [JsonProperty("@xmlns:pingback")]
        public string XmlnsPingback { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}