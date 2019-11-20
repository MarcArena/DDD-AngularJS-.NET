using System.Collections.Generic;
using domain = devTest.Domain.Modules.AirportAggregate.Entities;
namespace devTest.Domain.Modules.AirportAggregate.Repositories
{
    public interface IAirportRepository
    {
        IEnumerable<domain.City> All();
        IEnumerable<domain.Airport> GetAirportsBySearchString(string searchString);
        //IEnumerable<domain.Airport> GetNearestAirports(string currentLatitude, string currentLongitude);
    }
}
