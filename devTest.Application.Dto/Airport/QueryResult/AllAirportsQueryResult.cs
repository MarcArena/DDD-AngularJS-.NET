﻿using devTest.Application.Dto.Airport.Dto;
using devTest.Application.Dto.Base;
using System.Collections.Generic;

namespace devTest.Application.Dto.Airport.QueryResult
{
    public class AllAirportsQueryResult : IQueryResult
    {
        public IEnumerable<AirportDto> Airports { get; set; }
    }
}
