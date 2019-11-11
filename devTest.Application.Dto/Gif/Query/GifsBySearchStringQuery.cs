using devTest.Application.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Application.Dto.Gif.Query
{
    public class GifsBySearchStringQuery : IQuery
    {
        public string SearchString { get; set; }
        public int Limit { get; set; }
    }
}
