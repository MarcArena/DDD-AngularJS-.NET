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

            var distancesToSet = new List<DistanceDto>();

            var originAirports = _airportRepository.GetAirportsBySearchString(query.Airport1);
            var destinationAirports = _airportRepository.GetAirportsBySearchString(query.Airport2);

            if (CheckAirports(originAirports, destinationAirports))
            {
                foreach (var origin in originAirports)
                {
                    foreach (var destination in destinationAirports)
                    {
                        var distance = _airportsService.CalculateDistanceBetweenAirports(origin, destination);

                        distancesToSet.Add(AirportConverter.Instance.ToDistanceDto(distance));
                    }
                }

            }

            result.Distances = distancesToSet;

            return result;
        }

        private bool CheckAirports(IEnumerable<Airport> originAirports, IEnumerable<Airport> destinationAirports)
        {
            var ok = true;

            if (originAirports == null || !originAirports.Any())
                throw new Exception("Origin Airport not found.");

            if (destinationAirports == null || !destinationAirports.Any())
                throw new Exception("Origin Airport not found.");
            
            return ok;
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
