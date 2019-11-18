using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Domain.Modules.AirportAggregate.Entities
{
    public class Airport
    {
        public Airport(string name, string latitude, string longitude, string id, string cityName)
        {
            Id = id;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            CityName = cityName;
        }

        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Id { get; set; }
        public string CityId { get; set; }
        public string CountryId { get; set; }
        public string CityName { get; set; }
    }

    public class Distance
    {
        public double DistanceInKM { get; set; }
        public string OriginAirport { get; set; }
        public string DestinationAirport { get; set; }
    }
}
