using Newtonsoft.Json;

namespace OBilet_Case.Infrastructure.DTOs.OBiletAPIv2
{
    public class OBiletAPIv2GetJourneysResponseStopDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("station")]
        public string Station { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("is-origin")]
        public bool IsOrigin { get; set; }

        [JsonProperty("is-destination")]
        public bool IsDestination { get; set; }
    }
}
