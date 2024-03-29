﻿using devTest.Application.Messaging;
using devTest.Application.Services;
using devTest.CrossCutting.Cache;
using devTest.CrossCutting.Ioc;
using devTest.Data.Base;
using devTest.Data.Repositories;
using devTest.Domain.Modules.AirportAggregate.Repositories;
using devTest.Domain.Modules.GifAggregate.Repositories;
using devTest.Domain.Modules.HotelAggregate.Repositories;

namespace devTest.CrossCutting.Bootstrapper
{
    public static class IocRegistration
    {
        public static void Register(IIocContainer container)
        {
            container.RegisterInstance<IIocContainer>(container);
            container.Register<IQueryDispatcher, QueryDispatcher>(LifetimeManagerEnum.ContainerControlled);
            container.Register<IHotelsRepository, HotelsRepository>(LifetimeManagerEnum.PerResolve);
            container.Register<IGifRepository, GifRepository>(LifetimeManagerEnum.PerResolve);
            container.Register<IAirportRepository, AirportRepository>(LifetimeManagerEnum.PerResolve);
            container.Register<IWebApiService, WebApiService>(LifetimeManagerEnum.PerResolve);
            container.Register<IAirportsService, AirportsService>(LifetimeManagerEnum.PerResolve);
            container.Register<ICache, devTest.CrossCutting.Cache.Cache>(LifetimeManagerEnum.PerResolve);

            container.Register("devTest.Application", typeof(IQueryHandler<,>), LifetimeManagerEnum.Transient);
        }
    }
}
