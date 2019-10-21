using Infraestructura.comun.Shared;
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
using utilidades.BLL.Imp;
using utilidades.BLL.Inter;
using utilidades.DAL.comun;
using utilidades.DAL.dbContext;
using utilidades.Entities.UsuarioYRoles;
using Utilidades.Infraestructura.Comun;
using Utilidades.Infraestructura.Managers.Imp;
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

        /// <summary>
        /// Inyección de todas las dependencias de la aplicación
        /// </summary>
        /// <param name="container"></param>
        public static void DependenciasAplicacion(IUnityContainer container)
        {
         
            IdentityDependencias(container);

            ManagerDependencias(container);

            RepositoriosDependencias(container);

            ServiciosDependencias(container);
        }

        /// <summary>
        /// Inyección de dependencias de seguridad para roles y usuarios
        /// </summary>
        /// <param name="container"></param>
        public static void IdentityDependencias(IUnityContainer container)
        {
            //var accountInjectionConstructor = new InjectionConstructor(new UtilidadesDbContext());

            container.RegisterType<UtilidadesDbContext>(new PerResolveLifetimeManager());

            container.RegisterType<DbContext, UtilidadesDbContext>(new PerResolveLifetimeManager());

            container.RegisterType<IUserStore<ApplicationUser,string>, UserStore<ApplicationUser,ApplicationRole,string,IdentityUserLogin,IdentityUserRole,IdentityUserClaim>>();

            container.RegisterType<IRoleStore<ApplicationRole, string>, RoleStore<ApplicationRole>>();

            container.RegisterType<IAuthenticationManager>(new InjectionFactory(o => HttpContext.Current.GetOwinContext().Authentication));

        

            container.RegisterType<SignInService>();

            container.RegisterType<UserService>();

            container.RegisterType<EmailService>();
        }

        public static void ManagerDependencias(IUnityContainer container)
        {
            container.RegisterType<IUsuariosManager, UsuarioManager>();

            container.RegisterType<IArticuloManager, ArticuloManager>();
        }

        public static void RepositoriosDependencias(IUnityContainer container)
        {   //https://stackoverflow.com/questions/35334240/unity-register-and-resolve-class-with-generic-type
            //registramos los genericos
            container.RegisterType(typeof(IRepositorio<>), typeof(RepositorioBase<>));
        }

        public static void ServiciosDependencias(IUnityContainer container)
        {   //https://stackoverflow.com/questions/35334240/unity-register-and-resolve-class-with-generic-type
            //registramos los genericos
            container.RegisterType(typeof(IService<>), typeof(Service<>));

            container.RegisterType<ITipoService, TipoService>();

            container.RegisterType<ITagService, TagService>();

            container.RegisterType<IArticuloService, ArticuloService>();
        }
    }
}