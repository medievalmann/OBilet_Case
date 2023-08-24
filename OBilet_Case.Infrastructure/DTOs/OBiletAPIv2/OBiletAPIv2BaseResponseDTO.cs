using Newtonsoft.Json;

namespace OBilet_Case.Infrastructure.DTOs.OBiletAPIv2
{
    public class OBiletAPIv2BaseResponseDTO<T>
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public T Data { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("user-message")]
        public object UserMessage { get; set; }

        [JsonProperty("api-request-id")]
        public object ApiRequestId { get; set; }

        [JsonProperty("controller")]
        public string Controller { get; set; }
    }
}
