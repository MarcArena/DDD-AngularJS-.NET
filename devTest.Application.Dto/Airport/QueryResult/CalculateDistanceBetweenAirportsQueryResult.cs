using devTest.Application.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Application.Dto.Airport.QueryResult
{
    public class CalculateDistanceBetweenAirportsQueryResult : IQueryResult
    {
        public IEnumerable<DistanceDto> Distances { get; set; }
    }

    public class DistanceDto
    {
        public string OriginAirport { get; set; }
        public string DestinationAirport { get; set; }
        public double DistanceInKM { get; set; }
    }
}
