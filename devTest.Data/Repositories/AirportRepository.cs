using devTest.CrossCutting.Cache;
using devTest.Data.Base;
using devTest.Data.Dtos;
using devTest.Domain.Modules.AirportAggregate.Entities;
using devTest.Domain.Modules.AirportAggregate.Repositories;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using domain = devTest.Domain.Modules.AirportAggregate.Entities;
namespace devTest.Data.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private readonly IWebApiService _webApiService;
        private readonly ICache _cache;

        private static string skyScannerEndPoint = ConfigurationManager.AppSettings["skyScannerEndPoint"]; //http://partners.api.skyscanner.net
        private static string skyScannerAPIKey = ConfigurationManager.AppSettings["skyScannerAPIKey"];

        public AirportRepository(IWebApiService webApiService, ICache cache)
        {
            _webApiService = webApiService;
            _cache = cache;
        }

        public IEnumerable<domain.City> All()
        {
            var result = _cache.Get<IEnumerable<domain.City>>($"All");

            if (result == null)
            {
                //http://partners.api.skyscanner.net/apiservices/geo/v1.0?apikey=prtl6749387986743898559646983194

                string url = $"{skyScannerEndPoint}/apiservices/geo/v1.0?apikey={skyScannerAPIKey}";

                var resultDto = _webApiService.Get<AirportDto>(url, 1000);

                result = Translate(resultDto);

                if (result.Any())
                    _cache.Set($"All", result);
            }

            return result;
        }


        public IEnumerable<domain.Airport> GetAirportsBySearchString(string searchString)
        {
            var airports = _cache.Get<IEnumerable<domain.Airport>>($"AirportsBySearchString[{searchString}]")?.ToList();

            if (airports == null)
            {
                //airports = All().Where(a => a.Name.ToUpper().Contains(searchString.ToUpper()) || a.Id.Contains(searchString.ToUpper()));

                var allCities = All().ToList();

                airports = new List<domain.Airport>();

                foreach (var c in allCities)
                {
                    if (c.Name.ToUpper().Contains(searchString.ToUpper()))
                    {
                        airports.AddRange(c.Airports);
                    }
                    else
                        foreach (var a in c.Airports.Where(a => a.Name.ToUpper().Contains(searchString.ToUpper()) || a.Id.ToUpper().Contains(searchString.ToUpper())))
                        {
                            airports.Add(new domain.Airport(a.Name, a.Latitude, a.Longitude, a.Id, a.CityName));
                        }
                }

                if (airports != null && airports.Any())
                    _cache.Set($"AirportsBySearchString[{searchString}]", airports);
            }

            return airports;
        }

        private IEnumerable<domain.City> Translate(AirportDto airports)
        {
            var res = new List<domain.City>();

            if (airports != null && airports.Continents.Any())
            {
                foreach (var continent in airports.Continents)
                {
                    foreach (var country in continent.Countries)
                    {
                        foreach (var city in country.Cities)
                        {
                            var newCity = new domain.City(city.Name);

                            foreach (var airport in city.Airports)
                            {
                                var location = airport.Location.Split(',');

                                newCity.AddAirport(id: airport.Id, name: airport.Name, latitude: location[1], longitude: location[0], cityName: city.Name);
                            }

                            res.Add(newCity);
                        }
                    }
                }
            }

            return res;
        }
    }
}
