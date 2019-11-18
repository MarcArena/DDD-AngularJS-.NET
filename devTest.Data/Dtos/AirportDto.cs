using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Data.Dtos
{
    public enum CountryId { Au, De, Es, Fi, Fr, Id, It, Jp, Uk, Us };

    public partial class AirportDto
    {
        [JsonProperty("Continents")]
        public Continent[] Continents { get; set; }
    }

    public partial class Continent
    {
        [JsonProperty("Countries")]
        public Country[] Countries { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }

    public partial class Country
    {
        [JsonProperty("CurrencyId")]
        public string CurrencyId { get; set; }

        [JsonProperty("Regions")]
        public Region[] Regions { get; set; }

        [JsonProperty("Cities")]
        public City[] Cities { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("LanguageId", NullValueHandling = NullValueHandling.Ignore)]
        public string LanguageId { get; set; }
    }

    public partial class City
    {
        [JsonProperty("SingleAirportCity")]
        public bool SingleAirportCity { get; set; }

        [JsonProperty("Airports")]
        public Airport[] Airports { get; set; }

        [JsonProperty("CountryId")]
        public string CountryId { get; set; }

        [JsonProperty("Location")]
        public string Location { get; set; }

        [JsonProperty("IataCode")]
        public string IataCode { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("RegionId", NullValueHandling = NullValueHandling.Ignore)]
        public string RegionId { get; set; }
    }

    public partial class Airport
    {
        [JsonProperty("CityId")]
        public string CityId { get; set; }

        [JsonProperty("CountryId")]
        public string CountryId { get; set; }

        [JsonProperty("Location")]
        public string Location { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("RegionId", NullValueHandling = NullValueHandling.Ignore)]
        public string RegionId { get; set; }
    }

    public partial class Region
    {
        [JsonProperty("CountryId")]
        public CountryId CountryId { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
