using devTest.Application.Dto.Airport.Query;
using devTest.Application.Dto.Airport.QueryResult;
using devTest.Application.Messaging;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace devTest.Distributed.Controllers
{
    public class AirportsController : ApiController
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public AirportsController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        public HttpResponseMessage Get()
        {
            var query = new AllAirportsQuery { };

            var queryResponse = _queryDispatcher.Dispatch<AllAirportsQuery, AllAirportsQueryResult>(query);

            var okResponse = this.Request.CreateResponse(HttpStatusCode.OK, queryResponse);

            return okResponse;
        }
        [ActionName("GetAirportsBySearchString")]
        public HttpResponseMessage GetAirportsBySearchString(string searchString)
        {
            var query = new AirportsBySearchStringQuery { SearchString = searchString};

            var queryResponse = _queryDispatcher.Dispatch<AirportsBySearchStringQuery, AirportsBySearchStringQueryResult>(query);

            var okResponse = this.Request.CreateResponse(HttpStatusCode.OK, queryResponse);

            return okResponse;
        }
    }
}