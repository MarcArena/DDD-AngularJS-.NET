using devTest.Application.Core.Messaging;
using devTest.Application.Dto.Gif.Dto;
using devTest.Application.Dto.Gif.Query;
using devTest.Application.Dto.Gif.QueryResult;
using devTest.Application.DtoConverter.Modules.GifAggregate;
using devTest.Application.Messaging;
using devTest.Domain.Modules.GifAggregate.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.Application.Modules.Gifs.QueryHandlers
{
    public class GifsBySearchStringQueryHandler : AutoDisposable, IQueryHandler<GifsBySearchStringQuery, GifsBySearchStringQueryResult>
    {
        private readonly IGifRepository _gifRepository;

        public GifsBySearchStringQueryHandler(IGifRepository gifRepository)
        {
            _gifRepository = gifRepository;
        }
        public GifsBySearchStringQueryResult Retrieve(GifsBySearchStringQuery query)
        {
            var result = new GifsBySearchStringQueryResult();

            var gifs = _gifRepository.GetGifsBySearchString(query.SearchString, query.Limit);

            if (gifs != null && gifs.Any())
                result.Gifs = GifConverter.Instance.ToDto(gifs);
            else
                result.Gifs = new List<GifDto>();

            return result;
        }
    }
}
