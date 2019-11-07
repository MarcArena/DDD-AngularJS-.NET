using devTest.Application.Dto.Base;
using devTest.Application.Hotel.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain = devTest.Domain.Modules.Hotel.Entities;


namespace devTest.Application.Dto.Converters
{
    public class HotelConverter : IDtoTranslatable
    {
        private static HotelConverter _instance = null;

        private HotelConverter() { }

        public static HotelConverter Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HotelConverter();

                return _instance;
            }
        }

        public IEnumerable<HotelDto> ToDto(IEnumerable<domain.Hotel> hotels)
        {
            var hotelDtos = new List<HotelDto>();

            foreach (var h in hotels)
            {
                var hotelToAdd = new HotelDto()
                {
                    name = h.name,
                    propertyId = h.propertyID,
                    geoId = h.geoId,
                    rating = h.rating,
                    rates = GetRates(h.rates)
                };

                hotelDtos.Add(hotelToAdd);
            }

            return hotelDtos;

        }

        private List<RateDto> GetRates(IEnumerable<domain.Rate> rates)
        {
            var ratesToAdd = new List<RateDto>();

            foreach (var r in rates)
            {
                ratesToAdd.Add(new RateDto()
                {
                    finalPrice = r.finalPrice,
                    value = r.value,
                    rateType = r.rateType.ToString(),
                    boardType = r.boardType
                });
            }

            return ratesToAdd;
        }
    }
}

