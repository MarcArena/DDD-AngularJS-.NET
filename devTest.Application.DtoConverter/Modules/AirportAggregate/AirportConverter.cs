using devTest.Application.Dto.Airport.Dto;
using devTest.Application.Dto.Base;
using System.Collections.Generic;
using domain = devTest.Domain.Modules.AirportAggregate.Entities;
namespace devTest.Application.DtoConverter.Modules.AirportAggregate
{
    public class AirportConverter : IDtoTranslatable
    {
        private static AirportConverter _instance = null;

        private AirportConverter() { }

        public static AirportConverter Instance
        {
            get { return _instance ?? new AirportConverter(); }
        }

        public IEnumerable<AirportDto> ToDto(IEnumerable<domain.Airport> airports)
        {
            var dtos = new List<AirportDto>();

            foreach (var a in airports)
            {
                dtos.Add(new AirportDto()
                {
                    Name = a.Name,
                    Longitude = a.Longitude,
                    Latitude = a.Latitude,
                    Id = a.Id
                });
            }

            return dtos;

        }
    }
}