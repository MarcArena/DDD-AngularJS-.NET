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
    public class TilesController : ApiController
    {
        private readonly IQueryDispatcher _queryDispatcher;

        public TilesController(IQueryDispatcher queryDispatcher)
        {
            _queryDispatcher = queryDispatcher;
        }

        public HttpResponseMessage Get()
        {
            var tiles = new List<Tile>
                {
                    new Tile() { Name = "Login Forms", Url = "#/LoginForms" },
                    new Tile() { Name = "Forms", Url = "#/Forms" },
                    new Tile() { Name = "Tables", Url = "#/Tables" },
                    new Tile() { Name = "Modals", Url = "#/Modals" }
                };

            var response = this.Request.CreateResponse(HttpStatusCode.OK, tiles);

            return response;
        }

        public class Tile
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }
    }
}