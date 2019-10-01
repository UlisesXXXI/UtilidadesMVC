using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Mvc5;
using utilidades.BLL;
using utilidades.DAL.dbContext;
using utilidades.DAL.UsuarioYRoles;
using Utilidades.Infraestructura;
using Utilidades.Infraestructura.Managers.Inter;

namespace Utilidades
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

                //Carga de todas las dependencias de la aplicacion
                DependenciasAplicacion(container);


                //Asigna el contenedor al objeto ContextApp para que este disponible en todo el frontal
                ContextoApp.Container = container;

                
                DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }


        public static void DependenciasAplicacion(IUnityContainer container)
        {
            //Dependencias de UserManager,RoleManager,SignInService
            IdentityDependencias(container);
        }

        public static void IdentityDependencias(IUnityContainer container)
        {
            var accountInjectionConstructor = new InjectionConstructor(new UtilidadesDbContext());
            container.RegisterType<UtilidadesDbContext>(new PerThreadLifetimeManager());
            container.RegisterType<DbContext, UtilidadesDbContext>(new PerThreadLifetimeManager());

            
            container.RegisterType<IUserStore<ApplicationUser,string>, UserStore<ApplicationUser,ApplicationRole,string,IdentityUserLogin,IdentityUserRole,IdentityUserClaim>>(accountInjectionConstructor);
            container.RegisterType<IRoleStore<ApplicationRole, string>, RoleStore<ApplicationRole>>();
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(o => HttpContext.Current.GetOwinContext().Authentication));


            container.RegisterType<UtilidadesDbContext>();
            container.RegisterType<SignInService>();
            container.RegisterType<UserService>();
            container.RegisterType<EmailService>();
        }

        public static void ManagerDependencias(IUnityContainer container)
        {
            container.RegisterType<IUsuariosManager, IUsuariosManager>();
        }
    }
}