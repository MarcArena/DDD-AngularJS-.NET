using devTest.Application.Dto.Gif.Query;
using devTest.Application.Dto.Gif.QueryResult;
using devTest.Application.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace devTest.Distributed.Controllers
{
    public class GifsController : ApiController
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public GifsController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        public HttpResponseMessage Get(string searchString, int limit)
        {
            var query = new GifsBySearchStringQuery { SearchString = searchString, Limit = limit };

            var queryResponse = _queryDispatcher.Dispatch<GifsBySearchStringQuery, GifsBySearchStringQueryResult>(query);

            var okResponse = this.Request.CreateResponse(HttpStatusCode.OK, queryResponse);

            return okResponse;
        }
    }
}