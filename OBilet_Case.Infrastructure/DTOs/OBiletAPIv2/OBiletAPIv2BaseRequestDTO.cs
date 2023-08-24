using Newtonsoft.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OBilet_Case.Infrastructure.DTOs.OBiletAPIv2
{
    public class OBiletAPIv2BaseRequestDTO<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("device-session")]
        public OBiletAPIv2BaseRequestDeviceSessionDTO DeviceSession { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
    }
}
