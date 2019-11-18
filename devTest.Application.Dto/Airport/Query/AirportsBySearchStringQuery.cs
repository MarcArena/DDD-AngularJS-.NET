using devTest.Application.Dto.Base;

namespace devTest.Application.Dto.Airport.Query
{
    public class AirportsBySearchStringQuery : IQuery
    {
        public string SearchString { get; set; }
    }
}
