using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTest.CrossCutting.Ioc
{

    public interface IIocContainer
    {
        void Register<TAbstract, TConcrete>(LifetimeManagerEnum lifetimeManager) where TConcrete : TAbstract;
        void RegisterType<T>(LifetimeManagerEnum lifetimeManager);
        void Register(string assembly, Type interfaceType, LifetimeManagerEnum lifetimeManager);
        void RegisterInstance<T>(string instance, T interfaces);
        void RegisterInstance<TInterface>(TInterface instance);
        object Resolve(Type t, string name, params ResolverOverride[] resolverOverrides);
        T Resolve<T>();
        System.Web.Http.Dependencies.IDependencyResolver GetDependencyResolverWebApi();
        IEnumerable<T> ResolveAll<T>();
        void RegistreType<T>();
        UnityContainer CurrentObject { get; }
        void RegisterType(Type abstractType, Type concreteType, LifetimeManagerEnum lifetimeManager);
    }

    public enum LifetimeManagerEnum
    {
        Transient,              //Se crea una instancia cada vez que se inyecta o resuelve. 
        PerResolve,             //Se crea una instancia por resolución del controlador, básicamente una por petición http.
        ContainerControlled,     //Se crea una instancia única global a toda la vida de la aplicación.
        PerThread
    }
}
