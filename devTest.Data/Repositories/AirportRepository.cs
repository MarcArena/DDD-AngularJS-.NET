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

        public IEnumerable<domain.Airport> All()
        {
            //http://partners.api.skyscanner.net/apiservices/geo/v1.0?apikey=prtl6749387986743898559646983194

            string url = $"{skyScannerEndPoint}/apiservices/geo/v1.0?apikey={skyScannerAPIKey}";

            var result = _cache.Get<IEnumerable<domain.Airport>>($"Airports");

            if (result == null)
            {
                var resultDto = _webApiService.Get<AirportDto>(url, 1000);

                result = Translate(resultDto);

                if (result.Any())
                    _cache.Set($"Airports", result);
            }

            return result;
        }


        public IEnumerable<domain.Airport> GetAirportsBySearchString(string searchString)
        {
            var airports = _cache.Get<IEnumerable<domain.Airport>>($"AirportsBySearchString[{searchString}]");

            if (airports == null)
            {
                airports = All().Where(a => a.Name.Contains(searchString) || a.Id.Contains(searchString));

                if (airports != null && airports.Any())                
                    _cache.Set($"AirportsBySearchString[{searchString}]", airports);           
            }

            return airports;
        }

        private IEnumerable<domain.Airport> Translate(AirportDto result)
        {
            var airports = new List<domain.Airport>();

            if (result != null && result.Continents.Any())
            {
                foreach (var continent in result.Continents)
                {
                    foreach (var country in continent.Countries)
                    {
                        foreach (var city in country.Cities)
                        {
                            foreach (var airport in city.Airports)
                            {
                                var location = airport.Location.Split(',');

                                airports.Add(new domain.Airport()
                                {
                                    Name = airport.Name,
                                    Latitude = location[1],
                                    Longitude = location[0],
                                    Id = airport.Id
                                });
                            }
                        }
                    }
                }
            }

            return airports;
        }

    }
}
