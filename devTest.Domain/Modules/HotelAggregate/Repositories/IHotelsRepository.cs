using System.Collections.Generic;
using domain = devTest.Domain.Modules.HotelAggregate.Entities;

namespace devTest.Domain.Modules.HotelAggregate.Repositories
{
    public interface IHotelsRepository
    {
        IEnumerable<domain.Hotel> GetHotelsByDestinationAndNights(int destination, int nights);
    }
}
