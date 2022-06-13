using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Statistics
    {
        [JsonProperty("@views")]
        public string Views { get; set; }
    }
}