using Newtonsoft.Json;

namespace OBilet_Case.Infrastructure.DTOs.OBiletAPIv2
{
    public class OBiletAPIv2GetJourneysResponseFeatureDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("priority")]
        public byte? Priority { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("is-promoted")]
        public bool IsPromoted { get; set; }

        [JsonProperty("back-color")]
        public string BackColor { get; set; }

        [JsonProperty("fore-color")]
        public string ForeColor { get; set; }
    }
}
