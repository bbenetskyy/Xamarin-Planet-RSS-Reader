using Newtonsoft.Json;

namespace XamarinPlanet.Models
{
    public class Total
    {
        [JsonProperty("@xmlns:thr")]
        public string XmlnsThr { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
}