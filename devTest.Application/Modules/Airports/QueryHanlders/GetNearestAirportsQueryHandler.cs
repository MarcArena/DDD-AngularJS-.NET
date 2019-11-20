using devTest.Application.Core.Messaging;
using devTest.Application.Dto.Airport.Query;
using devTest.Application.Dto.Airport.QueryResult;
using devTest.Application.DtoConverter.Modules.AirportAggregate;
using devTest.Application.Messaging;
using devTest.Application.Services;
using devTest.Domain.Modules.AirportAggregate.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Application.Modules.Airports.QueryHanlders
{
    public class GetNearestAirportsQueryHandler : AutoDisposable, IQueryHandler<GetNearestAirportsQuery, GetNearestAirportsQueryResult>
    {
        private readonly IAirportRepository _airportRepository;
        private readonly IAirportsService _airportsService;

        public GetNearestAirportsQueryHandler(IAirportRepository airportRepository, IAirportsService airportsService)
        {
            _airportRepository = airportRepository;
            _airportsService = airportsService;
        }

        public GetNearestAirportsQueryResult Retrieve(GetNearestAirportsQuery query)
        {
            var nearestAirports = _airportsService.GetNearestAirports(query.CurrentLatitude, query.CurrentLongitude)?.ToList();

            var dtos = AirportConverter.Instance.ToDto(nearestAirports);

            return new GetNearestAirportsQueryResult()
            {
                NearestAirports = dtos
            };
        }
    }
}
