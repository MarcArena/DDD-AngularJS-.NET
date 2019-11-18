
using devTest.CrossCutting.Cache;
using devTest.Data.Base;
using devTest.Data.Dtos;
using devTest.Domain.Modules.GifAggregate.Entities;
using devTest.Domain.Modules.GifAggregate.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using domain = devTest.Domain.Modules.GifAggregate.Entities;

namespace devTest.Data.Repositories
{
    public class GifRepository : IGifRepository
    {
        private readonly IWebApiService _webApiService;
        private readonly ICache _cache;

        private static string giphyEndPoint = ConfigurationManager.AppSettings["giphyEndPoint"]; //https://api.giphy.com/v1/
        private static string giphyAPIKey = ConfigurationManager.AppSettings["giphyAPIKey"];

        public GifRepository(IWebApiService webApiService, ICache cache)
        {
            _webApiService = webApiService;
            _cache = cache;
        }


        public IEnumerable<Gif> GetGifsBySearchString(string searchString, int limit)
        {
            //https://api.giphy.com/v1/gifs/search?api_key=pfYnWHuFkkPIlRsXiC98aH4fsrWYWpnW&q=&limit=25&offset=0&rating=G&lang=en


            string url = $"{giphyEndPoint}/gifs/search?api_key={giphyAPIKey}&q={searchString}&limit={limit}&offset=0&rating=G&lang=en";

            var result = _cache.Get<IEnumerable<domain.Gif>>($"GifsBySearchStringAndLimit[{searchString}][{limit}]");

            if (result == null)
            {
                var resultDto = _webApiService.Get<ExternalGifDto>(url, 1000);

                result = Translate(resultDto);

                if (result.Any())
                    _cache.Set($"GifsBySearchStringAndLimit[{searchString}][{limit}]", result);
            }

            return result;
        }

        private IEnumerable<domain.Gif> Translate(ExternalGifDto result)
        {
            var gifs = new List<domain.Gif>();

            if (result != null && result.data.Any())
            {
                foreach (var r in result.data)
                {
                    if (CheckValidTitle(r.title) && CheckValidMp4(r.images.fixed_height.mp4))
                    {
                        var gifToAdd = new domain.Gif()
                        {
                            id = r.id,
                            url = r.url,
                            title = r.title,
                            mp4 = r.images.fixed_height.mp4
                        };

                        if (!gifs.Contains(gifToAdd))
                            gifs.Add(gifToAdd);

                    }
                }
            }

            return gifs;
        }

        private bool CheckValidMp4(string mp4)
        {
            return mp4 != string.Empty;
        }

        private bool CheckValidTitle(string title)
        {
            return title != string.Empty && title != " ";
        }
    }
}
