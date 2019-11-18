using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Application.Dto.Airport.Dto
{
    public class CityDto
    {
        public string Name { get; set; }
        public List<AirportDto> Airports { get; set; }
    }
}
