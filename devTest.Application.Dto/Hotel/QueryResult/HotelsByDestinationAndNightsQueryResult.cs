using devTest.Application.Dto.Base;
using devTest.Application.Hotel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Application.Hotel.QueryResult
{
    public class HotelsByDestinationAndNightsQueryResult : IQueryResult
    {
        public IEnumerable<HotelDto> Hotels { get; set; }
    }
}
