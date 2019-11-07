using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityConfiguration;

namespace devTest.CrossCutting.Ioc
{
    public class UnityIocContainer : IIocContainer, IDisposable
    {
        private readonly UnityContainer _current = new UnityContainer();

        public UnityContainer CurrentObject { get { return _current; } }

        public void Register<TAbstract, TConcrete>(LifetimeManagerEnum lifetimeManager) where TConcrete : TAbstract
        {
            _current.RegisterType<TAbstract, TConcrete>(SetLifeTimeManager(lifetimeManager));
        }

        public void Register(string assembly, Type interfaceType, LifetimeManagerEnum lifetimeManager)
        {
            _current.RegisterTypes(
            AllClasses.FromAssemblies(Assembly.Load(assembly)).Where(t => t.ImplementsInterface(interfaceType)),
            WithMappings.FromAllInterfaces,
            WithName.Default, x => SetLifeTimeManager(lifetimeManager)
            );
        }

        public void RegisterType(Type abstractType, Type concreteType, LifetimeManagerEnum lifetimeManager)
        {
            _current.RegisterType(abstractType, concreteType, SetLifeTimeManager(lifetimeManager));
        }

        public void RegisterType<T>(LifetimeManagerEnum lifetimeManager)
        {
            _current.RegisterType<T>(SetLifeTimeManager(lifetimeManager));
        }

        public void RegisterInstance<T>(string name, T instance)
        {
            _current.RegisterInstance<T>(name, instance);
        }

        public void RegisterInstance<T>(T instance)
        {
            _current.RegisterInstance<T>(instance);
        }


        public Object Resolve(Type t, string name, params ResolverOverride[] resolverOverrides)
        {
            return _current.Resolve(t, name, resolverOverrides);
        }

        public T Resolve<T>()
        {
            return _current.Resolve<T>();
        }

        public System.Web.Http.Dependencies.IDependencyResolver GetDependencyResolverWebApi()
        {
            return new Unity.WebApi.UnityDependencyResolver(_current);
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return _current.ResolveAll<T>();
        }

        public IUnityContainer Current
        {
            get { return _current; }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _current.Dispose();
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private LifetimeManager SetLifeTimeManager(LifetimeManagerEnum liveTimeManager)
        {
            switch (liveTimeManager)
            {
                case LifetimeManagerEnum.ContainerControlled:
                    return new ContainerControlledLifetimeManager();

                case LifetimeManagerEnum.PerResolve:
                    return new PerResolveLifetimeManager();

                case LifetimeManagerEnum.PerThread:
                    return new PerThreadLifetimeManager();

                case LifetimeManagerEnum.Transient:
                    return new TransientLifetimeManager();

                default:
                    return new TransientLifetimeManager();
            }
        }

        public void RegistreType<T>()
        {
            _current.RegisterType<T>(new ContainerControlledLifetimeManager());
        }
    }
}
