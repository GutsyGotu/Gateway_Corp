using SBS.BAL;
using SBS.BAL.Helper;
using SBS.BAL.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Service_Booking_System
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IServiceManager, ServiceManager>();
            container.AddNewExtension<UnityRepositoryHelper>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}