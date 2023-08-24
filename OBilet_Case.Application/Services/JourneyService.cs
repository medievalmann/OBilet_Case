using FluentValidation;
using OBilet_Case.Core.DTOs;
using OBilet_Case.Core.Interfaces.IManager;
using OBilet_Case.Core.Interfaces.IRepository;
using OBilet_Case.Core.Interfaces.IService;
using OBilet_Case.Core.Mappers;
using OBilet_Case.Core.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OBilet_Case.Application.Services
{
    public class JourneyService : IJourneyService
    {
        private readonly IJourneyRepository _journeyRepository;
        private readonly ICacheManager _cacheManager;

        private readonly IBusLocationService _busLocationService;
        public JourneyService(IJourneyRepository journeyRepository, IBusLocationService busLocationService, ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
            _journeyRepository = journeyRepository;

            _busLocationService = busLocationService;
        }
        public async Task<IEnumerable<JourneyDTO>> GetJourneysAsync(GetJoruneysDTO dto)
        {
            var validator = new GetJourneysValidator(_busLocationService);
            var validationResult = await validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
            var getJourneysFromOBiletApiAsyncDTO = new GetJourneysFromOBiletApiDTO
            {
                DepratureDate = dto.DepratureDate,
                OriginID = dto.OriginID,
                DestinationID = dto.DestinationID,
            };
            var journeys = await _journeyRepository.GetJourneysFromOBiletApiAsync(getJourneysFromOBiletApiAsyncDTO);

            return journeys.Select(x => x.ToJourneyDTO());

        }
    }
}
