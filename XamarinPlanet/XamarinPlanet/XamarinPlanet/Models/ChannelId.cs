using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class ChannelId
    {
        [JsonProperty("@xmlns:yt")]
        public string XmlnsYt { get; set; }
        [JsonProperty("#prefix")]
        public string Prefix { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}