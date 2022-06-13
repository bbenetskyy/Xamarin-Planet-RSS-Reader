using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class VideoId
    {
        [JsonProperty("@xmlns:yt")]
        public string XmlnsYt { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}