using devTest.Application.Dto.Airport.Dto;
using devTest.Application.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Application.Dto.Airport.QueryResult
{
    public class GetNearestAirportsQueryResult : IQueryResult
    {
        public IEnumerable<AirportDto> NearestAirports { get; set; }
    }
    
}
