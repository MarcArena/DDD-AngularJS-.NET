using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using devTest.CrossCutting.Cache;
using devTest.Domain.Modules.AirportAggregate.Entities;
using System.Device.Location;

namespace devTest.Application.Services
{
    public class AirportsService : IAirportsService
    {
        private readonly ICache _cache;

        public AirportsService(ICache cache)
        {
            _cache = cache;
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

                result = new Distance() {
                    OriginAirport = originAirport.Name,
                    DestinationAirport = destinationAirport.Name,
                    DistanceInKM = distanceInKm
                };

                if (result != null)
                    _cache.Set($"AirportDistance[{originAirport.Name}, {destinationAirport.Name}]", result);

            }

            return result;
        }

    }
}
