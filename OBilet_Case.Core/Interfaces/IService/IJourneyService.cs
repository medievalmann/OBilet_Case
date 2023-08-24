using OBilet_Case.Core.DTOs;
using OBilet_Case.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet_Case.Core.Interfaces.IService
{
    public interface IJourneyService
    {
        Task<IEnumerable<JourneyDTO>> GetJourneysAsync(GetJoruneysDTO dto);
    }
}
