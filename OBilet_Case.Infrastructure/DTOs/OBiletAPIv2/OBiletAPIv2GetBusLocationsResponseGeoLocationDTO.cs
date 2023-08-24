using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace OBilet_Case.Infrastructure.DTOs.OBiletAPIv2
{
    public class OBiletAPIv2GetBusLocationsResponseGeoLocationDTO
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("zoom")]
        public int Zoom { get; set; }
    }
}
