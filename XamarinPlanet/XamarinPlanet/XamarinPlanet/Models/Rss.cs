using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Rss
    {
        public Channel Channel { get; set; }

        [JsonProperty("@xmlns:a10")]
        public string XmlnsA10 { get; set; }
        public string Version { get; set; }
    }
}