using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Application.Hotel.Dto
{
    public class HotelDto
    {
        public int propertyId { get; set; }
        public string name { get; set; }
        public int geoId { get; set; }
        public int rating { get; set; }
        public List<RateDto> rates { get; set; }
    }

    public class RateDto
    {
        public string rateType { get; set; }
        public string boardType { get; set; }
        public double value { get; set; }
        public double finalPrice { get; set; }
    }
}

