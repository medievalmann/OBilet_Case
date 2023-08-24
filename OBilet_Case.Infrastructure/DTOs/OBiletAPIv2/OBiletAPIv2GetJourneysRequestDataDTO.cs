using Newtonsoft.Json;

namespace OBilet_Case.Infrastructure.DTOs.OBiletAPIv2
{
    public class OBiletAPIv2GetJourneysRequestDataDTO
    {
        [JsonProperty("origin-id")]
        public int OriginId { get; set; }

        [JsonProperty("destination-id")]
        public int DestinationId { get; set; }

        [JsonProperty("departure-date")]
        public DateTime DepartureDate { get; set; }
    }
}
