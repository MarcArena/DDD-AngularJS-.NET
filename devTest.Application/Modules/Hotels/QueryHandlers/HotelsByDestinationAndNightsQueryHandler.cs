using devTest.Application.Core.Messaging;
using devTest.Application.Dto.Converters;
using devTest.Application.Hotel.Dto;
using devTest.Application.Hotel.Query;
using devTest.Application.Hotel.QueryResult;
using devTest.Application.Messaging;
using devTest.Domain.Modules.Hotel.Repositories;

using System.Collections.Generic;
using System.Linq;

namespace devTest.Application.Modules.Hotels.QueryHandlers
{
    public class HotelsByDestinationAndNightsQueryHandler : AutoDisposable, IQueryHandler<HotelsByDestinationAndNightsQuery, HotelsByDestinationAndNightsQueryResult>
    {
        private readonly IHotelsRepository _hotelsRepository;

        public HotelsByDestinationAndNightsQueryHandler(IHotelsRepository hotelsRepository)
        {
            _hotelsRepository = hotelsRepository;
        }

        public HotelsByDestinationAndNightsQueryResult Retrieve(HotelsByDestinationAndNightsQuery query)
        {
            var result = new HotelsByDestinationAndNightsQueryResult();

            var hotels = _hotelsRepository.GetHotelsByDestinationAndNights(query.DestinationId, query.NumberOfNights);

            if (hotels != null && hotels.Any())
                result.Hotels = HotelConverter.Instance.ToDto(hotels).Where(h => h.name != string.Empty && h.rates.Any());
            else
                result.Hotels = new List<HotelDto>();

            return result;
        }  
    }
}
