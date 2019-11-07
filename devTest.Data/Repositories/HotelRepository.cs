using devTest.CrossCutting.Cache;
using devTest.Data.Base;
using devTest.Data.Dtos;
using devTest.Domain.Modules.Hotel.Repositories;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using domain = devTest.Domain.Modules.Hotel.Entities;

namespace devTest.Data.Repositories
{
    public class HotelsRepository : IHotelsRepository
    {
        private readonly IWebApiService _webApiService;
        private readonly ICache _cache;

        private static string webBedsEndPoint = ConfigurationManager.AppSettings["webBedsEndPoint"];
        private static string webBedsSecretCode = ConfigurationManager.AppSettings["webBedsSecretCode"];

        public HotelsRepository(IWebApiService webApiService, ICache cache)
        {
            _webApiService = webApiService;
            _cache = cache;
        }

        public IEnumerable<domain.Hotel> GetHotelsByDestinationAndNights(int destination, int nights)
        {
            string url = $"{webBedsEndPoint}findBargain?destinationId={destination}&nights={nights}&code={webBedsSecretCode}";

            var result = _cache.Get<IEnumerable<domain.Hotel>>($"HotelsByDestinationAndNights[{destination}][{nights}]");

            if (result == null)
            {
                var resultDto = _webApiService.Get<List<HotelDto>>(url, 1000);

                result = Translate(resultDto, nights);

                if (result.Any())
                    _cache.Set($"HotelsByDestinationAndNights[{destination}][{nights}]", result);
            }

            return result;
        }

        private IEnumerable<domain.Hotel> Translate(List<HotelDto> result, int nights)
        {
            var hotels = new List<domain.Hotel>();

            if (result != null && result.Any())
            {
                foreach (var r in result)
                {
                    var hotelToAdd = new domain.Hotel()
                    {
                        propertyID = r.hotel.propertyID,
                        geoId = r.hotel.geoId,
                        name = r.hotel.name,
                        rating = r.hotel.rating
                    };

                    foreach (var rate in r.rates)
                    {
                        if (rate.value >= 0 && Enum.TryParse<domain.RateTypes>(rate.rateType, out var type))
                            hotelToAdd.AddRate(type, rate.boardType, rate.value, nights);
                    }

                    hotels.Add(hotelToAdd);
                }
            }

            return hotels;
        }
    }
}