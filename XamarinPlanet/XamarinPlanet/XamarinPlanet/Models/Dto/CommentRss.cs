using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class CommentRss
    {
        [JsonProperty("@xmlns:wfw")]
        public string XmlnsWfw { get; set; }
        [JsonProperty("#prefix")]
        public string Prefix { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}