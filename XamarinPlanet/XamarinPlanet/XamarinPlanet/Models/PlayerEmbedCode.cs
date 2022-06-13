using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class PlayerEmbedCode
    {
        [JsonProperty("@xmlns:fireside")]
        public string XmlnsFireside { get; set; }
        [JsonProperty("#prefix")]
        public string Prefix { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}