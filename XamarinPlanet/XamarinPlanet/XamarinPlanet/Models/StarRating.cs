using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace XamarinPlanet.Models
{
    public class StarRating
    {
        [JsonProperty("@count")]
        public string Count { get; set; }
        [JsonProperty("@average")]
        public string Average { get; set; }
        [JsonProperty("@min")]
        public string Min { get; set; }
        [JsonProperty("@max")]
        public string Max { get; set; }
    }
}