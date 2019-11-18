using devTest.Application.Dto.Airport.Dto;
using devTest.Application.Dto.Base;
using System.Collections.Generic;

namespace devTest.Application.Dto.Airport.QueryResult
{
    public class AllAirportsQueryResult : IQueryResult
    {
        public int TotalResult { get; set; }
        public IEnumerable<AirportDto> Airports { get; set; }
    }
}
