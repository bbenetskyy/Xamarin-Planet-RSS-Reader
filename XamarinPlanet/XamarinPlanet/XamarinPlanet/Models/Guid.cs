using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Guid
    {
        [JsonProperty("@isPermaLink")]
        public string IsPermaLink { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}