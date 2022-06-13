using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Person
    {
        [JsonProperty("@xmlns:podcast")]
        public string XmlnsPodcast { get; set; }
        [JsonProperty("@email")]
        public string Email { get; set; }
        [JsonProperty("@href")]
        public string Href { get; set; }
        [JsonProperty("@role")]
        public string Role { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}