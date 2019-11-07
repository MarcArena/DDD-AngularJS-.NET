using System.Collections.Generic;
using domain = devTest.Domain.Modules.Hotel.Entities;

namespace devTest.Domain.Modules.Hotel.Repositories
{
    public interface IHotelsRepository
    {
        IEnumerable<domain.Hotel> GetHotelsByDestinationAndNights(int destination, int nights);
    }
}
