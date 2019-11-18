using System.Collections.Generic;
using System.Linq;

namespace devTest.Domain.Modules.AirportAggregate.Entities
{
    public class City
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool SingleAirportCity { get; set; }

        public string CountryId { get; set; }

        public string Location { get; set; }

        public string IataCode { get; set; }

        public string RegionId { get; set; }

        private IList<Airport> _airports = new List<Airport>();

        public IEnumerable<Airport> Airports
        {
            get { return _airports; }
        }

        public City(string name)
        {
            Name = name;
        }

        public City(string name, string countryId)
        {
            Name = name;
            CountryId = countryId;
        }

        public void AddAirport(string id, string name, string latitude, string longitude, string cityName)
        {
            if (this._airports == null)
                _airports = new List<Airport>();

            var existsAirport = _airports.FirstOrDefault(c => c.Name == name && c.Id == id);

            if (existsAirport != null) _airports.Remove(existsAirport);

            this._airports.Add(new Airport(name, latitude, longitude, id, cityName));
        }

    }
}
