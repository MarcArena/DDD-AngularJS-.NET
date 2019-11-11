using devTest.Application.Dto.Base;
using devTest.Application.Dto.Gif.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Application.Dto.Gif.QueryResult
{
    public class GifsBySearchStringQueryResult : IQueryResult
    {
        public IEnumerable<GifDto> Gifs { get; set; }

    }
}
