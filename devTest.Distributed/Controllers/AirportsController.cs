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

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var query = new AllAirportsQuery { };

            var queryResponse = _queryDispatcher.Dispatch<AllAirportsQuery, AllAirportsQueryResult>(query);

            var okResponse = this.Request.CreateResponse(HttpStatusCode.OK, queryResponse);

            return okResponse;
        }

        [HttpGet]
        [ActionName("GetAirportsBySearchString")]
        public HttpResponseMessage GetAirportsBySearchString(string searchString)
        {
            var query = new AirportsBySearchStringQuery { SearchString = searchString};

            var queryResponse = _queryDispatcher.Dispatch<AirportsBySearchStringQuery, AirportsBySearchStringQueryResult>(query);

            var okResponse = this.Request.CreateResponse(HttpStatusCode.OK, queryResponse);

            return okResponse;
        }
       
        [HttpGet]
        [ActionName("CalculateDistanceBetweenAirportsInKM")]
        public HttpResponseMessage CalculateDistanceBetweenAirportsInKM(string airport1, string airport2)
        {
            var query = new CalculateDistanceBetweenAirportsQuery { Airport1 = airport1, Airport2 = airport2 };

            var queryResponse = _queryDispatcher.Dispatch<CalculateDistanceBetweenAirportsQuery, CalculateDistanceBetweenAirportsQueryResult>(query);

            var okResponse = this.Request.CreateResponse(HttpStatusCode.OK, queryResponse);

            return okResponse;
        }

        [HttpGet]
        [ActionName("GetNearestAirports")]
        public HttpResponseMessage GetNearestAirports(string currentLatitude, string currentLongitude)
        {
            var query = new GetNearestAirportsQuery { CurrentLatitude = currentLatitude, CurrentLongitude = currentLongitude };

            var queryResponse = _queryDispatcher.Dispatch<GetNearestAirportsQuery, GetNearestAirportsQueryResult>(query);

            var okResponse = this.Request.CreateResponse(HttpStatusCode.OK, queryResponse);

            return okResponse;
        }

    }
}