using Newtonsoft.Json;

namespace OBilet_Case.Infrastructure.DTOs.OBiletAPIv2
{
    public class OBiletAPIv2GetSessionResponseDataDTO
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId { get; set; }

        public string Affiliate { get; set; }

        [JsonProperty("device-type")]
        public int DeviceType { get; set; }

        public string Device { get; set; }

        [JsonProperty("ip-country")]
        public string IpCountry { get; set; }
    }
}
