using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using devTest.CrossCutting.Cache;
using devTest.Domain.Modules.AirportAggregate.Entities;
using System.Device.Location;
using devTest.Domain.Modules.AirportAggregate.Repositories;
using devTest.Application.Dto.Airport.QueryResult;

namespace devTest.Application.Services
{
    public class AirportsService : IAirportsService
    {
        private readonly ICache _cache;
        private readonly IAirportRepository _airportRepository;

        public AirportsService(ICache cache, IAirportRepository airportRepository)
        {
            _cache = cache;
            _airportRepository = airportRepository;
        }

        public Distance CalculateDistanceBetweenAirports(Airport originAirport, Airport destinationAirport)
        {
            var result = _cache.Get<Distance>($"AirportDistance[{originAirport.Name}, {destinationAirport.Name}]");

            if (result == null)
                result = _cache.Get<Distance>($"AirportDistance[{destinationAirport.Name}, {originAirport.Name}]");

            if (result == null)
            {
                var originAirportCoordinates = new GeoCoordinate()
                {
                    Longitude = Convert.ToDouble(originAirport.Longitude),
                    Latitude = Convert.ToDouble(originAirport.Latitude)
                };

                var destinationAirportCoordinates = new GeoCoordinate()
                {
                    Longitude = Convert.ToDouble(destinationAirport.Longitude),
                    Latitude = Convert.ToDouble(destinationAirport.Latitude)
                };

                var distanceInKm = Math.Round(originAirportCoordinates.GetDistanceTo(destinationAirportCoordinates) / 1000, 3);

                result = new Distance()
                {
                    OriginAirport = originAirport.Name,
                    DestinationAirport = destinationAirport.Name,
                    DistanceInKM = distanceInKm
                };

                if (result != null)
                    _cache.Set($"AirportDistance[{originAirport.Name}, {destinationAirport.Name}]", result);

            }

            return result;
        }

        public IEnumerable<Airport> GetNearestAirports(string currentLatitude, string currentLongitude)
        {
            var nearestAirports = new List<Airport>();

            var currentLocation = new GeoCoordinate()
            {
                Longitude = Convert.ToDouble(currentLongitude),
                Latitude = Convert.ToDouble(currentLatitude)
            };

            var cities = _airportRepository.All();

            foreach (var city in cities)
            {
                foreach (var airport in city.Airports)
                {
                    var airportLocation = new GeoCoordinate()
                    {
                        Latitude = Convert.ToDouble(airport.Latitude),
                        Longitude = Convert.ToDouble(airport.Longitude),
                    };

                    var distanceFromCurrentLocation = Math.Round(currentLocation.GetDistanceTo(airportLocation), 3);

                    airport.DistanceFromCurrentLocation = distanceFromCurrentLocation;

                    nearestAirports.Add(airport);
                }
            }

            return nearestAirports.Where(x => x.DistanceFromCurrentLocation <= nearestAirports.Min(a => a.DistanceFromCurrentLocation) + 70000);
        }


    }
}
