using devTest.Application.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Application.Dto.Airport.Query
{
    public class CalculateDistanceBetweenAirportsQuery : IQuery
    {
        public string Airport1 { get; set; }
        public string Airport2 { get; set; }
    }
}
