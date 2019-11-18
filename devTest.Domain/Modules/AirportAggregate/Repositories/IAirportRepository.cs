using System.Collections.Generic;
using domain = devTest.Domain.Modules.AirportAggregate.Entities;
namespace devTest.Domain.Modules.AirportAggregate.Repositories
{
    public interface IAirportRepository
    {
        IEnumerable<domain.Airport> All();
        IEnumerable<domain.Airport> GetAirportsBySearchString(string searchString);
    }
}
