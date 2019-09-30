using System.Data.Entity;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;
using utilidades.DAL.dbContext;

namespace Utilidades
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            RegistrarDependenciasAPP(container);
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }


        public static void RegistrarDependenciasAPP(IUnityContainer container)
        {
            RegistrarContextoYSeguridad(container);

            RegistrarRepositorios(container);

            RegistrarServicios(container);

        }

        public static void RegistrarContextoYSeguridad(IUnityContainer container)
        {
            container.RegisterType<DbContext, UtilidadesDbContext>(new InjectionConstructor(new UtilidadesDbContext()));
        }

        public static void  RegistrarRepositorios(IUnityContainer container){

        }

        public static void RegistrarServicios(IUnityContainer container)
        {

        }
    }
}