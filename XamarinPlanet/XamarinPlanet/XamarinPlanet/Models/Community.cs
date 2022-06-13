using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Community
    {
        [JsonProperty("media:starRating")]
        public StarRating StarRating { get; set; }
        [JsonProperty("media:statistics")]
        public Statistics Statistics { get; set; }
    }
}