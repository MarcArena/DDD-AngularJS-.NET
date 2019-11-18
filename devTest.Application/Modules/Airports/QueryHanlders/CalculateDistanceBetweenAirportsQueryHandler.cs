using devTest.Application.Core.Messaging;
using devTest.Application.Dto.Airport.Query;
using devTest.Application.Dto.Airport.QueryResult;
using devTest.Application.DtoConverter.Modules.AirportAggregate;
using devTest.Application.Messaging;
using devTest.Application.Services;
using devTest.Domain.Modules.AirportAggregate.Entities;
using devTest.Domain.Modules.AirportAggregate.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Application.Modules.Airports.QueryHanlders
{
    public class CalculateDistanceBetweenAirportsQueryHandler : AutoDisposable, IQueryHandler<CalculateDistanceBetweenAirportsQuery, CalculateDistanceBetweenAirportsQueryResult>
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IAirportsService _airportsService;

        public CalculateDistanceBetweenAirportsQueryHandler(IAirportRepository airportRepository, IAirportsService airportsService)
        {
            _airportRepository = airportRepository;
            _airportsService = airportsService;
        }

        public CalculateDistanceBetweenAirportsQueryResult Retrieve(CalculateDistanceBetweenAirportsQuery query)
        {
            var result = new CalculateDistanceBetweenAirportsQueryResult();

            var airport1 = _airportRepository.GetAirportsBySearchString(query.Airport1)?.First();
            var airport2 = _airportRepository.GetAirportsBySearchString(query.Airport2)?.First();

            if (CheckAirports(airport1, airport2, query.Airport1, query.Airport2))
                result.Distances = AirportConverter.Instance.ToDistanceDto(_airportsService.CalculateDistanceBetweenAirports(airport1, airport2).ToList());
            else
                result.Distances = null;

            return result;
        }

        private bool CheckAirports(Airport airport1, Airport airport2, string searchString1, string searchString2)
        {
            if (airport1 == null)
                throw new Exception("No airport found named " + searchString1);

            if (airport2 == null)
                throw new Exception("No airport found named " + searchString2);

            return true;
        }
                               
    }
}
