using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Explicit
    {
        [JsonProperty("@xmlns:itunes")]
        public string XmlnsItunes { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}