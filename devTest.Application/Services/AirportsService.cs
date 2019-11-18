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

        public IEnumerable<Distance> CalculateDistanceBetweenAirports(Airport airport1, Airport airport2)
        {
            List<Distance> result = _cache.Get<IEnumerable<Distance>>($"AirportDistance[{airport1.Name}, {airport2.Name}]")?.ToList();

            if (result == null || !result.Any())
                result = _cache.Get<IEnumerable<Distance>>($"AirportDistance[{airport2.Name}, {airport1.Name}]").ToList();

            if (result == null || !result.Any())
            {

                foreach (var r in result)
                {                   
                    var coordinates1 = new GeoCoordinate() {
                        Longitude = Convert.ToDouble(airport1.Longitude.Replace('.', ',')),
                        Latitude = Convert.ToDouble(airport1.Latitude.Replace('.', ','))
                    };

                    var coordinates2 = new GeoCoordinate() {
                        Longitude = Convert.ToDouble(airport2.Longitude.Replace('.', ',')),
                        Latitude = Convert.ToDouble(airport2.Latitude.Replace('.', ','))
                    };

                    var distance = coordinates1.GetDistanceTo(coordinates2) / 1000;
                }

                if (result != null && result.Any())
                    _cache.Set($"AirportDistance[{airport1.Name}, {airport2.Name}]", result );

            }

            return result;
        }

        //double p = 0.017453292519943295;

        //double lat1 = Convert.ToDouble(airport1.Latitude.Replace('.', ','));
        //double lat2 = Convert.ToDouble(airport2.Latitude.Replace('.', ','));

        //double lng1 = Convert.ToDouble(airport1.Longitude.Replace('.', ','));
        //double lng2 = Convert.ToDouble(airport2.Longitude.Replace('.', ','));

        //double a = 0.5 - Math.Cos((lat1 - lat2) * p) / 2 +
        //    Math.Cos(lat1 * p) * Math.Cos(lat2 * p) *
        //    (1 - Math.Cos((lng2 - lng1) * p)) / 2;

        //var distance = Math.Round(12742 * Math.Asin(Math.Sqrt(a)), 3);

        //result.Add(new Distance() { OriginAirport = airport1.Name, DistanceInKM = distance, DistinationAirport = airport2.Name });

    }
}
