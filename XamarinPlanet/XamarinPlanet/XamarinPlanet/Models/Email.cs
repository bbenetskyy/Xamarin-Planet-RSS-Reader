using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Email
    {
        [JsonProperty("#prefix")]
        public string Prefix { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}