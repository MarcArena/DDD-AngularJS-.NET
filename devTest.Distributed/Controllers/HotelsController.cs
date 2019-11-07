
using devTest.Application.Hotel.Query;
using devTest.Application.Hotel.QueryResult;
using devTest.Application.Messaging;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace devTest.Distributed.Controllers
{
    public class HotelsController : ApiController
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public HotelsController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        public HttpResponseMessage Get(int destinationId, int numberOfNights)
        {
            var query = new HotelsByDestinationAndNightsQuery { DestinationId = destinationId, NumberOfNights = numberOfNights };
            
            var queryResponse = _queryDispatcher.Dispatch<HotelsByDestinationAndNightsQuery, HotelsByDestinationAndNightsQueryResult>(query);

            var okResponse = this.Request.CreateResponse(HttpStatusCode.OK, queryResponse);

            return okResponse;
        }
    }
}
