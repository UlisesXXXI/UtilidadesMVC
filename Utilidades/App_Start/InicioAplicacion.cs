using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Unity;
using utilidades.BLL;
using utilidades.DAL.UsuarioYRoles;
using Utilidades.Infraestructura;
using Utilidades.Infraestructura.Comun;

namespace Utilidades.App_Start
{
    public class InicioAplicacion
    {
        public static async Task  ComprobarUsuarios()
        {
            
            var contenedor = ((IUnityContainer)ContextoApp.Container);

            var userService = contenedor.Resolve<UserService>();

            var roleService = contenedor.Resolve<RoleService>();


            await ComprobarRolesSistemaAsync(roleService);

            await ComprobarUsuarioAdministradorAsync(userService);

        }

        public async static Task ComprobarUsuarioAdministradorAsync(UserManager<ApplicationUser,string> userManager)
        {
            string UsuarioAdministrador = Infraestructura.Constantes.Usuarios.USUARIO_ADMINISTRADOR;

            string Email = "Administrador@admin.com";

            string password = "P@ssw0rd";

            var usuario = await userManager.FindByNameAsync(UsuarioAdministrador);

            if (usuario == null)
            {
                ApplicationUser u = new ApplicationUser()
                {
                    UserName = UsuarioAdministrador,
                    Email = Email,
                    Activo = true,
                    Sistema = true

                };

                await userManager.CreateAsync(u, password);

                var usuarioB = await userManager.FindByNameAsync(UsuarioAdministrador);

                await userManager.AddToRoleAsync(usuarioB.Id, Infraestructura.Constantes.Roles.ADMINISTRADOR);

            }
        }

        public static async Task ComprobarRolesSistemaAsync(RoleManager<ApplicationRole> roleManager)
        {
            List<string> rolesSitema = new List<string>()
            {
                Infraestructura.Constantes.Roles.ADMINISTRADOR,
                Infraestructura.Constantes.Roles.EDITOR,
                Infraestructura.Constantes.Roles.LECTOR
            };

            foreach (var rolSistem in rolesSitema)
            {
                var role = await roleManager.FindByNameAsync(rolSistem);

                if (role == null)
                {
                    ApplicationRole r = new ApplicationRole()
                    {
                        Activo = true,
                        Name = rolSistem,
                        Sistema = true
                    };
                    await roleManager.CreateAsync(r);
                }
            }

            
        }
    }
}