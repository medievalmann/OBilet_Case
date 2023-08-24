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
    public class BusLocationRepository : IBusLocationRepository
    {
        private readonly IOBiletAPIAdapter _oBiletApiAdapter;

        public BusLocationRepository(IOBiletAPIAdapter oBiletApiAdapter)
        {
            _oBiletApiAdapter = oBiletApiAdapter;
        }
        public async Task<IEnumerable<BusLocation>> GetBusLocationsFromOBiletApiAsync()
        {
            return await _oBiletApiAdapter.GetBusLocationsAsync();
        }
    }
}
