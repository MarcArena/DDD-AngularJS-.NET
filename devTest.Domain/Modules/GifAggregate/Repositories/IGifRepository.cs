using System.Collections.Generic;
using domain = devTest.Domain.Modules.GifAggregate.Entities;

namespace devTest.Domain.Modules.GifAggregate.Repositories
{
    public interface IGifRepository
    {
        IEnumerable<domain.Gif> GetGifsBySearchString(string searchString, int limit);

    }
}
