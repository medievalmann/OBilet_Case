using OBilet_Case.Core.Entities;
using OBilet_Case.Infrastructure.DTOs.OBiletAPIv2;

namespace OBilet_Case.Infrastructure.Mappers
{
    public static class OBiletAPIv2GetJourneysResponseDataDTOMapper
    {
        public static Journey ToEntity(this OBiletAPIv2GetJourneysResponseDataDTO dto)
        {

            return new Journey
            {
                ID = dto.Id,
                Arrival = dto.Journey.Arrival,
                Departure = dto.Journey.Departure,
                Destination = dto.Journey.Destination,
                Origin = dto.Journey.Origin,
                Price = dto.Journey.OriginalPrice,
                Currency = dto.Journey.Currency
            };
        }
    }
}
