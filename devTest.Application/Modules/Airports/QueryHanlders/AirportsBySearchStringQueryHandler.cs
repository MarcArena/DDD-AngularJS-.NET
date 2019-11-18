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
    public class AirportsBySearchStringQueryHandler : AutoDisposable, IQueryHandler<AirportsBySearchStringQuery, AirportsBySearchStringQueryResult>
    {
        private readonly IAirportRepository _airportRepository;

        public AirportsBySearchStringQueryHandler(IAirportRepository airportRepository)
        {
            _airportRepository = airportRepository;
        }

        public AirportsBySearchStringQueryResult Retrieve(AirportsBySearchStringQuery query)
        {
            var result = new AirportsBySearchStringQueryResult();

            var airports = _airportRepository.GetAirportsBySearchString(query.SearchString  <);

            if (airports != null && airports.Any())
                result.Airports = AirportConverter.Instance.ToDto(airports).Where(h => h.Name != string.Empty);
            else
                result.Airports = new List<AirportDto>();

            return result;

        }

    }
}
