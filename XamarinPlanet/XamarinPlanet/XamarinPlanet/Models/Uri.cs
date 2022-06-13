using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Uri
    {
        [JsonProperty("#prefix")]
        public string Prefix { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}