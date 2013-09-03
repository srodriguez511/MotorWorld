using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using MotorWorld.Interfaces;
using MotorWorld.DataAccessLayer;
using System.Data.Entity;
using System.Web.Http;

namespace MotorWorld
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new Unity.Mvc4.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container
                .RegisterType<IUnitOfWork, ConcreteUnitOfWork>()
                .RegisterType<DbContext, ConcreteUnitOfWork>(new HierarchicalLifetimeManager()); 

            return container;
        }
    }
}