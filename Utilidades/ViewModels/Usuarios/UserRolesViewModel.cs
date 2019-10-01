using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utilidades.ViewModels.Usuarios
{
    public class UserRolesViewModel:IRolesUsuario
    {
        public UserRolesViewModel()
        {
            RolesAsignados = new List<string>();

            TodosLosRoles = new List<string>();
        }

        public IEnumerable<string> RolesAsignados { get; set; }
       

        public IEnumerable<string> TodosLosRoles {get;set;}
        
    }
}