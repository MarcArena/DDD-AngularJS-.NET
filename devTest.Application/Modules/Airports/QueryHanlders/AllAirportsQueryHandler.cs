using devTest.Application.Core.Messaging;
using devTest.Application.Dto.Airport.Dto;
using devTest.Application.Dto.Airport.Query;
using devTest.Application.Dto.Airport.QueryResult;
using devTest.Application.DtoConverter.Modules.AirportAggregate;
using devTest.Application.Messaging;
using devTest.Domain.Modules.AirportAggregate.Entities;
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

            var cities = _airportRepository.All();

            var airportDtos = new List<AirportDto>();

            foreach (var c in cities)
            {
                foreach (var a in c.Airports)
                {
                    airportDtos.Add(AirportConverter.Instance.ToAirportDto(a));
                }
            }

            //var a = airports.Select(c => c.Airports.Select(x => x));

            if (airportDtos != null && airportDtos.Any())
            {
                result.Airports = airportDtos;
                result.TotalResult = airportDtos.Count();
            }
            else
                result.Airports = new List<AirportDto>();

            return result;

        }
       
    }
}
