using OBilet_Case.Core.DTOs;
using OBilet_Case.Core.Entities;
using OBilet_Case.Core.Interfaces.IAdapter;
using OBilet_Case.Core.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet_Case.Infrastructure.Repositories
{
    public class JourneyRepository : IJourneyRepository
    {
        private readonly IOBiletAPIAdapter _oBiletApiAdapter;

        public JourneyRepository(IOBiletAPIAdapter oBiletApiAdapter)
        {
            _oBiletApiAdapter = oBiletApiAdapter;
        }
        public async Task<IEnumerable<Journey>> GetJourneysFromOBiletApiAsync(GetJourneysFromOBiletApiDTO dto)
        {
            return await _oBiletApiAdapter.GetJourneysAsync(dto);
        }
    }
}
