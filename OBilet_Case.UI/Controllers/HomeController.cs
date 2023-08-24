using Microsoft.AspNetCore.Mvc;
using OBilet_Case.Core.Interfaces.IManager;
using OBilet_Case.Core.Interfaces.IService;
using OBilet_Case.Infrastructure.Managers;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OBilet_Case.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBusLocationService _busLocationService;
        private readonly IJourneyService _journeyService;
        private readonly IUserContextManager _userContextManager;

        public HomeController(IBusLocationService busLocationService, IJourneyService journeyService, IUserContextManager userContextManager)
        {
            _busLocationService = busLocationService;
            _journeyService = journeyService;
            _userContextManager = userContextManager;
        }

        public async Task<IActionResult> Index()
        {
            var busLocations = await _busLocationService.GetBusLocationsAsync();

            return View(busLocations);
        }

        [HttpGet("{originId}/{destinationId}/{depratureDate}")]
        public async Task<IActionResult> Journeys(int originId, int destinationId, DateTime depratureDate)
        {
            var journeys = await _journeyService.GetJourneysAsync(new Core.DTOs.GetJoruneysDTO
            {
                DepratureDate = depratureDate,
                OriginID = originId,
                DestinationID = destinationId
            });

            var busLocations = await _busLocationService.GetBusLocationsAsync();
            var originLocation = busLocations.FirstOrDefault(x => x.ID == originId);
            var destinationLocation = busLocations.FirstOrDefault(x => x.ID == destinationId);


            ViewData["originToDestination"] = string.Format("{0} - {1}", originLocation.Name, destinationLocation.Name);

            ViewData["arriveDate"] = depratureDate.ToString("dd MMMM dddd", _userContextManager.Culture);

            return View(journeys);
        }
    }
}