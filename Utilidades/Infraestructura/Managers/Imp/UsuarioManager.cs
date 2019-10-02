using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using utilidades.DAL.UsuarioYRoles;
using Utilidades.Infraestructura.Managers.Inter;
using Utilidades.ViewModels.Usuarios;

namespace Utilidades.Infraestructura.Managers.Imp
{
    public class UsuarioManager:IUsuariosManager
    {

        UserManager<ApplicationUser,string> _userService;

        RoleManager<ApplicationRole> _roleManager;

        public UsuarioManager(UserManager<ApplicationUser,string> userService, RoleManager<ApplicationRole> roleManager)
        {
            _userService = userService;

            _roleManager = roleManager;
        }

        public ViewModels.Usuarios.newUserViewModel RellenarNuevoUsuario()
        {
            var userVm = new newUserViewModel();

            RellenarRolesUsuario(userVm, null);

            return userVm;
        }

        public void RellenarRolesUsuario(ViewModels.Usuarios.IRolesUsuario contenedorRoles, string id)
        {

            contenedorRoles.RolesAsignados = new List<string>();

            if (!String.IsNullOrEmpty(id))
            {
                contenedorRoles.RolesAsignados = _userService.GetRoles(id);
            }

            contenedorRoles.TodosLosRoles = _roleManager.Roles.Select(s => s.Name).ToList();
        }


        public void RellenarCombosUsuario(newUserViewModel vm)
        {

            vm.TodosLosRoles = _roleManager.Roles.Select(s => s.Name).ToList();

        }
    }
}