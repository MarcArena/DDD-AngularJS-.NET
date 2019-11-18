using devTest.Application.Core.Messaging;
using devTest.Application.Dto.Airport.Dto;
using devTest.Application.Dto.Airport.Query;
using devTest.Application.Dto.Airport.QueryResult;
using devTest.Application.DtoConverter.Modules.AirportAggregate;
using devTest.Application.Messaging;
using devTest.Domain.Modules.AirportAggregate.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Application.Modules.Airports.QueryHanlders
{
    public class AllAirportsQueryHandler : AutoDisposable, IQueryHandler<AllAirportsQuery, AllAirportsQueryResult>
    {
        private readonly IAirportRepository _airportRepository;

        public AllAirportsQueryHandler(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        public AllAirportsQueryResult Retrieve(AllAirportsQuery query)
        {
            var result = new AllAirportsQueryResult();

            var airports = _airportRepository.All();

            if (airports != null && airports.Any())
                result.Airports = AirportConverter.Instance.ToDto(airports).Where(h => h.Name != string.Empty);
            else
                result.Airports = new List<AirportDto>();

            return result;

        }
       
    }
}
