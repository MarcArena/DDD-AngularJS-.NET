
using devTest.Application.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Application.Hotel.Query
{
    public class HotelsByDestinationAndNightsQuery : IQuery
    {
        public int DestinationId { get; set; }
        public int NumberOfNights { get; set; }
    }
}
