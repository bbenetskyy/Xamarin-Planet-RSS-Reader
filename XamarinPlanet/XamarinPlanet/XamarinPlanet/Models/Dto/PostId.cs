using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class PostId
    {
        public string Xmlns { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}