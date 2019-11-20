using devTest.Application.Dto.Airport.Dto;
using devTest.Application.Dto.Airport.QueryResult;
using devTest.Application.Dto.Base;
using System;
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

            //foreach (var c in cities)
            //{
            foreach (var a in airports)
            {
                dtos.Add(new AirportDto()
                {
                    Name = a.Name,
                    Longitude = a.Longitude,
                    Latitude = a.Latitude,
                    Id = a.Id,
                    CityName = a.CityName
                });
            }
            //}

            return dtos;

        }

        public IEnumerable<AirportDto> ToAllDto(IEnumerable<domain.Airport> airports)
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

                //foreach (var a in c.Airports)
                //{
                //    dtos.Add(new AirportDto()
                //    {
                //        Name = a.Name,
                //        Longitude = a.Longitude,
                //        Latitude = a.Latitude,
                //        Id = a.Id
                //    });
                //}
            };

            return dtos;
        }

        public AirportDto ToAirportDto(domain.Airport a)
        {
            return new AirportDto()
            {
                Name = a.Name,
                Latitude = a.Latitude,
                Longitude = a.Longitude,
                Id = a.Id
            };
        }

        public List<AirportDto> GetAirports(IEnumerable<domain.Airport> airports)
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

        public DistanceBetweenAirportsDto ToDistanceDto(domain.Distance d)
        {
            return new DistanceBetweenAirportsDto()
            {
                OriginAirport = d.OriginAirport,
                DestinationAirport = d.DestinationAirport,
                DistanceInKM = d.DistanceInKM
            };
        }
    }
}