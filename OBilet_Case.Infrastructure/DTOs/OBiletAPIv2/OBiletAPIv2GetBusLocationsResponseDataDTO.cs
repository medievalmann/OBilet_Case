using Newtonsoft.Json;

namespace OBilet_Case.Infrastructure.DTOs.OBiletAPIv2
{
    public class OBiletAPIv2GetBusLocationsResponseDataDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("parent-id")]
        public int ParentId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("geo-location")]
        public OBiletAPIv2GetBusLocationsResponseGeoLocationDTO GeoLocation { get; set; }

        [JsonProperty("tz-code")]
        public string TzCode { get; set; }

        [JsonProperty("weather-code")]
        public object WeatherCode { get; set; }

        [JsonProperty("rank")]
        public int? Rank { get; set; }

        [JsonProperty("reference-code")]
        public object ReferenceCode { get; set; }

        [JsonProperty("keywords")]
        public string Keywords { get; set; }

    }
}
