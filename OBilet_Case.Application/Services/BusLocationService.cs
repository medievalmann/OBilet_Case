using OBilet_Case.Core.Constants;
using OBilet_Case.Core.DTOs;
using OBilet_Case.Core.Interfaces.IManager;
using OBilet_Case.Core.Interfaces.IRepository;
using OBilet_Case.Core.Interfaces.IService;
using OBilet_Case.Core.Mappers;

namespace OBilet_Case.Application.Services
{
    public class BusLocationService : IBusLocationService
    {
        private readonly IBusLocationRepository _busLocationRepository;
        private readonly ICacheManager _cacheManager;
        public BusLocationService(IBusLocationRepository busLocationRepository, ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
            _busLocationRepository = busLocationRepository;
        }

        public async Task<IEnumerable<BusLocationDTO>> GetBusLocationsAsync()
        {
            string cacheKey = InMemoryCacheKeys.AllBusLocations;
            var cacheDuration = InMemoryCacheDurations.Medium;

            return await _cacheManager.GetOrSet(cacheKey, async () =>
            {
                var busLocationsFromRepo = await _busLocationRepository.GetBusLocationsFromOBiletApiAsync();
                return busLocationsFromRepo.Select(x=> x.ToBusLocationDTO());
            }, cacheDuration);
        }
    }
}
