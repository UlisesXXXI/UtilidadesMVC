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




                IdentityDependencias(container);



                ContextoApp.Container = container;

                

                DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }


        public static void IdentityDependencias(IUnityContainer container)
        {
            var accountInjectionConstructor = new InjectionConstructor(new UtilidadesDbContext());
            container.RegisterType<UtilidadesDbContext>(new PerThreadLifetimeManager());
            container.RegisterType<DbContext, UtilidadesDbContext>(new PerThreadLifetimeManager());

            //container.RegisterInstance<UtilidadesDbContext>(new PerResolveLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser,string>, UserStore<ApplicationUser,ApplicationRole,string,IdentityUserLogin,IdentityUserRole,IdentityUserClaim>>(accountInjectionConstructor);
            container.RegisterType<IRoleStore<ApplicationRole, string>, RoleStore<ApplicationRole>>();
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(o => HttpContext.Current.GetOwinContext().Authentication));


            container.RegisterType<UtilidadesDbContext>();
            container.RegisterType<SignInService>();
            container.RegisterType<UserService>();
            container.RegisterType<EmailService>();
        }
    }
}