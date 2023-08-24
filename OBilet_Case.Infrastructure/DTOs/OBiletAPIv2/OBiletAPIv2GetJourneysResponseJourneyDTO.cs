using Newtonsoft.Json;

namespace OBilet_Case.Infrastructure.DTOs.OBiletAPIv2
{
    public class OBiletAPIv2GetJourneysResponseJourneyDTO
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("stops")]
        public List<OBiletAPIv2GetJourneysResponseStopDTO> Stops { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("departure")]
        public DateTime Departure { get; set; }

        [JsonProperty("arrival")]
        public DateTime Arrival { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("duration")]
        public TimeSpan Duration { get; set; }

        [JsonProperty("original-price")]
        public decimal OriginalPrice { get; set; }

        [JsonProperty("internet-price")]
        public string InternetPrice { get; set; }

        [JsonProperty("booking")]
        public List<object> Booking { get; set; }

        [JsonProperty("bus-name")]
        public string BusName { get; set; }

        [JsonProperty("policy")]
        public OBiletAPIv2GetJourneysResponsePolicyDTO Policy { get; set; }

        [JsonProperty("features")]
        public List<string> Features { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
