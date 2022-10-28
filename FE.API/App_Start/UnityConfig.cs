using FE.API.DataAccess;
using FE.API.Repositories;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace FE.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterType<IPersonRepository, PersonRepository>();
            //container.RegisterType<IUnitOfWork, UnitOfWork>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}