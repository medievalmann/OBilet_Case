using OBilet_Case.Core.DTOs;
using OBilet_Case.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet_Case.Core.Mappers
{
    public static class JourneyMapper
    {
        public static JourneyDTO ToJourneyDTO(this Journey journey)
        {

            return new JourneyDTO
            {
                ID = journey.ID,
                Origin = journey.Origin,
                Destination = journey.Destination,
                Arrival = journey.Arrival,
                Departure = journey.Departure,
                Currency = journey.Currency,
                Price = journey.Price
            };
        }
    }
}
