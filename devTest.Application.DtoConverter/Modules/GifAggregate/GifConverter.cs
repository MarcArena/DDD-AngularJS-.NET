using devTest.Application.Dto.Base;
using devTest.Application.Dto.Gif.Dto;
using domain = devTest.Domain.Modules.GifAggregate.Entities;
using System.Collections.Generic;
using devTest.Domain.Modules.GifAggregate.Entities;
using System;

namespace devTest.Application.DtoConverter.Modules.GifAggregate
{
    public class GifConverter : IDtoTranslatable
    {
        private static GifConverter _instance = null;

        private GifConverter() { }

        public static GifConverter Instance
        {
            get { return _instance ?? new GifConverter(); }
        }

        public IEnumerable<GifDto> ToDto(IEnumerable<domain.Gif> gifs)
        {
            var gifDtos = new List<GifDto>();

            foreach (var g in gifs)
            {
                var gifToAdd = new GifDto()
                {
                   id = g.id,
                   url = g.url,
                   title = g.title,
                   mp4 = g.mp4
                };

                gifDtos.Add(gifToAdd);
            }

            return gifDtos;

        }       
    }
}