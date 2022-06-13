using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Publisher
    {
        [JsonProperty("@xmlns:dc")]
        public string XmlnsDc { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}