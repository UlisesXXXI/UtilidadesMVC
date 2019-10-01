using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.ViewModels.Usuarios;

namespace Utilidades.Infraestructura.Managers.Inter
{
    public interface IUsuariosManager
    {
        newUserViewModel RellenarNuevoUsuario();

        void RellenarRolesUsuario(IRolesUsuario contenedorRoles,string id);

        void RellenarCombosUsuario(newUserViewModel vm);
        
    }
}
