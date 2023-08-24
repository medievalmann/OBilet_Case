using FluentValidation;
using OBilet_Case.Core.DTOs;
using OBilet_Case.Core.Entities;
using OBilet_Case.Core.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBilet_Case.Core.Validators
{
    public class GetJourneysValidator : AbstractValidator<GetJoruneysDTO>
    {
        private readonly IBusLocationService _busLocationService;
        private IEnumerable<BusLocationDTO> _busLocations;
        public GetJourneysValidator(IBusLocationService busLocationService)
        {
            _busLocationService = busLocationService;

            RuleFor(x => x.OriginID)
                .NotEqual(0)
                .MustAsync(ValidBusLocation).WithMessage("Hatalı başlangıç noktası !")
                .NotEqual(x => x.DestinationID)
                .WithMessage("Başlangıç ve varış noktası aynı olamaz."); ;

            RuleFor(x => x.DestinationID)
                .NotEqual(0)
                .MustAsync(ValidBusLocation).WithMessage("Hatalı varış noktası !");
            RuleFor(x => x.DepratureDate.Date)
                .NotEmpty().WithMessage("Tarih boş olamaz.")
                .GreaterThanOrEqualTo(DateTime.Now.Date).WithMessage("Tarih bugünden küçük olmamalıdır.");
        }

        private async Task<bool> ValidBusLocation(int busLocationID, CancellationToken cancellationToken)
        {
            if (_busLocations == null)
                _busLocations = await _busLocationService.GetBusLocationsAsync();

            return _busLocations.Any(x => x.ID == busLocationID);
        }
    }
}
