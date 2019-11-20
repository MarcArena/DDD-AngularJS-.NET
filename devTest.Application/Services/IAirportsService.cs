using devTest.Application.Dto.Airport.QueryResult;
using devTest.Domain.Modules.AirportAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Application.Services
{
    public interface IAirportsService
    {
        Distance CalculateDistanceBetweenAirports(Airport airport1, Airport airport2);
        IEnumerable<Airport> GetNearestAirports(string currentLatitude, string currentLongitude);
    }
}
