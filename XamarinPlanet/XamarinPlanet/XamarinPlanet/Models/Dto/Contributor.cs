using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Contributor
    {
        [JsonProperty("a10:name")]
        public string Name { get; set; }
        [JsonProperty("a10:url")]
        public string Uri { get; set; }
        [JsonProperty("a10:email")]
        public string Email { get; set; }
    }
}