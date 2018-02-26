using BRRF.Core.BusinessManager;
using BRRF.Core.BusinessManager.Interface;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace BRRF.SAM.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IDispatcher, Dispatcher>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}