using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Tag
    {
        [JsonProperty("@xmlns:betag")]
        public string XmlnsBetag { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}