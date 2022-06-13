using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Ping
    {
        [JsonProperty("@xmlns:trackback")]
        public string XmlnsTrackback { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}