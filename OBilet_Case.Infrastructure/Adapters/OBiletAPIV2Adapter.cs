using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OBilet_Case.Core.Constants;
using OBilet_Case.Core.DTOs;
using OBilet_Case.Core.Entities;
using OBilet_Case.Core.Interfaces.IAdapter;
using OBilet_Case.Core.Interfaces.IManager;
using OBilet_Case.Infrastructure.DTOs.OBiletAPIv2;
using OBilet_Case.Infrastructure.Mappers;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace OBilet_Case.Infrastructure.Adapters
{
    public class OBiletAPIV2Adapter : IOBiletAPIAdapter
    {
        private readonly HttpClient _httpClient;
        private readonly IUserContextManager _userContextManager;
        private readonly ICacheManager _cacheManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OBiletAPIV2Adapter(HttpClient httpClient, IUserContextManager userContextManager, ICacheManager cacheManager, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _userContextManager = userContextManager;
            _cacheManager = cacheManager;
            _httpContextAccessor = httpContextAccessor;
        }

        private async Task<OBiletAPIv2GetSessionResponseDataDTO> GetSession()
        {
            var ipAdress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();
            var port = _httpContextAccessor.HttpContext.Connection.LocalPort;

            var jsonData = JsonConvert.SerializeObject(new OBiletAPIv2GetSessionRequestDTO
            {
                Type = 7,
                Browser = new OBiletAPIv2GetSessionRequestBrowserDTO
                {
                    Name = _userContextManager.BrowserName,
                    Version = _userContextManager.BrowserVersion,
                },
                Connection = new OBiletAPIv2GetSessionRequestConnectionDTO
                {
                    IpAddress = ipAdress,
                    Port = port.ToString()
                }
            });
            var requestContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/client/getsession", requestContent);
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<OBiletAPIv2GetSessionResponseDTO>(responseContent);

            return responseDto.Data;
        }

        public async Task<HttpResponseMessage> SendDataAsync<T>(string endpoint, T? data = default)
        {
            var userOBiletSessionCacheKey = string.Format(InMemoryCacheKeys.UserOBiletSession, _userContextManager.SessionID);
            var deviceSession = await _cacheManager.GetOrSet(userOBiletSessionCacheKey, async () =>
            {
                var oBiletSession = await GetSession();
                return oBiletSession;
            }, InMemoryCacheDurations.Long);

            var requestData = new OBiletAPIv2BaseRequestDTO<T>
            {
                Data = data,
                DeviceSession = new OBiletAPIv2BaseRequestDeviceSessionDTO
                {
                    SessionId = deviceSession.SessionId,
                    DeviceId = deviceSession.DeviceId,
                },
                Date = DateTime.Now,
                Language = _userContextManager.Culture.Name,
            };

            var jsonData = JsonConvert.SerializeObject(requestData);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);
            return response;
        }
        public async Task<IEnumerable<BusLocation>> GetBusLocationsAsync()
        {
            var response = await SendDataAsync<object>("/api/location/getbuslocations");
            var content = await response.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<OBiletAPIv2GetBusLocationsResponseDTO>(content);

            return responseDto.Data.Select(x => x.ToEntity());
        }

        public async Task<IEnumerable<Journey>> GetJourneysAsync(GetJourneysFromOBiletApiDTO dto)
        {
            var response = await SendDataAsync<OBiletAPIv2GetJourneysRequestDataDTO>("/api/journey/getbusjourneys",
                new OBiletAPIv2GetJourneysRequestDataDTO
                {
                    OriginId = dto.OriginID,
                    DestinationId = dto.DestinationID,
                    DepartureDate = DateTime.Now
                });
            var content = await response.Content.ReadAsStringAsync();
            var responseDto = JsonConvert.DeserializeObject<OBiletAPIv2GetJourneysResponseDTO>(content);

            return responseDto.Data.Select(x => x.ToEntity());
        }
    }
}
