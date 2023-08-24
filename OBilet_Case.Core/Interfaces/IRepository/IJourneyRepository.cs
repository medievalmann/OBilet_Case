using OBilet_Case.Core.DTOs;
using OBilet_Case.Core.Entities;

namespace OBilet_Case.Core.Interfaces.IRepository
{
    public interface IJourneyRepository
    {
        Task<IEnumerable<Journey>> GetJourneysFromOBiletApiAsync(GetJourneysFromOBiletApiDTO dto);
    }
}
