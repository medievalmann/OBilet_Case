using OBilet_Case.Core.Entities;
using OBilet_Case.Infrastructure.DTOs.OBiletAPIv2;

namespace OBilet_Case.Infrastructure.Mappers
{
    public static class OBiletAPIv2GetBusLocationsDataDTOMapper
    {
        public static BusLocation ToEntity(this OBiletAPIv2GetBusLocationsResponseDataDTO dto)
        {

            return new BusLocation
            {
                ID = dto.Id,
                Name = dto.Name
            };
        }
    }
}
