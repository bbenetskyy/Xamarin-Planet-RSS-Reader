using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Comment
    {
        [JsonProperty("@xmlns:wfw")]
        public string XmlnsWfw { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}