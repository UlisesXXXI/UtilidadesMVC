using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Unity;
using utilidades.BLL;
using utilidades.DAL.UsuarioYRoles;
using Utilidades.Infraestructura;

namespace Utilidades.App_Start
{
    public class InicioAplicacion
    {
        public static async Task  ComprobarUsuarios()
        {
            var contenedor = ((IUnityContainer)ContextoApp.Container);

            var userService = contenedor.Resolve<UserService>();

            var roleService = contenedor.Resolve<RoleService>();

            string UsuarioAdministrador = "Administrador";

            string Email = "Administrador@admin.com";

            string password = "P@ssw0rd";

            var usuario = await userService.FindByNameAsync(UsuarioAdministrador);

            var role = await roleService.FindByNameAsync(Infraestructura.Constantes.Roles.ADMINISTRADOR);

            if(role == null)
            {
                ApplicationRole r = new ApplicationRole()
                {
                    Activo = true,
                    Name = Infraestructura.Constantes.Roles.ADMINISTRADOR
                };
                await roleService.CreateAsync(r);
            }

            if (usuario == null)
            {
                ApplicationUser u = new ApplicationUser()
                {
                    UserName = UsuarioAdministrador,
                    Email = Email,
                    Activo = true

                };

                await userService.CreateAsync(u, password);

                var usuarioB = await userService.FindByNameAsync(UsuarioAdministrador);

                await userService.AddToRoleAsync(usuarioB.Id, Infraestructura.Constantes.Roles.ADMINISTRADOR);

            }
        }
    }
}