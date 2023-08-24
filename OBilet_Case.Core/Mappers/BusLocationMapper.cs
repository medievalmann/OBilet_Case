using OBilet_Case.Core.DTOs;
using OBilet_Case.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet_Case.Core.Mappers
{
    public static class BusLocationMapper
    {
        public static BusLocationDTO ToBusLocationDTO(this BusLocation busLocation)
        {

            return new BusLocationDTO
            {
                ID = busLocation.ID,
                Name = busLocation.Name
            };
        }
    }
}
