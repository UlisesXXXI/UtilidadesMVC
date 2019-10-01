using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades.ViewModels.Usuarios
{
    public interface IRolesUsuario
    {

        
         IEnumerable<String> RolesAsignados { get; set; }

         IEnumerable<String> TodosLosRoles { get; set; }
    }
}
