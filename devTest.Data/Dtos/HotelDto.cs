using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Data.Dtos
{
    class HotelDto
    {
        public Hotel hotel { get; set; }
        public IList<Rate> rates { get; set; }
    }

    public class Hotel
    {
        public int propertyID { get; set; }
        public string name { get; set; }
        public int geoId { get; set; }
        public int rating { get; set; }
    }

    public class Rate
    {
        public string rateType { get; set; }
        public string boardType { get; set; }
        public double value { get; set; }
    }
}
