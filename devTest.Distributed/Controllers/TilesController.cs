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
                    new Tile() { Name = "Login Forms", Url = "login", Description = "See a collection of different Login Forms, using bootstrap 4.0.0." },
                    new Tile() { Name = "Forms - CRUD", Url = "Forms", Description = "See an example of Users CRUD with a Create, Edit and Delete page, using bootrstrap 4.0.0." },
                    new Tile() { Name = "Tables", Url = "Tables", Description = "See various examples of tables to map the app users." },
                    new Tile() { Name = "Bootstrap Components", Url = "Bootstrap", Description = "See a list of interesting Bootstrap components, with code examples." }
                };

            var response = this.Request.CreateResponse(HttpStatusCode.OK, tiles);

            return response;
        }

        public class Tile
        {
            public string Name { get; set; }
            public string Url { get; set; }
            public string Description { get; set; }
        }
    }
}