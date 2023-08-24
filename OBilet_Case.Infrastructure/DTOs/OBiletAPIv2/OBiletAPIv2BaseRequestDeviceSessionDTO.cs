using Newtonsoft.Json;
namespace OBilet_Case.Infrastructure.DTOs.OBiletAPIv2
{
    public class OBiletAPIv2BaseRequestDeviceSessionDTO
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId { get; set; }
    }
}
