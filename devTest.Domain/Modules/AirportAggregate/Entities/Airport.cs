﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Domain.Modules.AirportAggregate.Entities
{
    public class Airport
    {
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Id { get; set; }
    }

    public class Distance
    {
        public double DistanceInKM { get; set; }
        public string OriginAirport { get; set; }
        public string DistinationAirport { get; set; }
    }
}
