using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Utilidades.Infraestructura.comun.Seguridad.inter;
using Infraestructura.comun.Constantes;

namespace Utilidades.Infraestructura.comun.Seguridad.imp
{
    public class UsuarioActual:IUsuarioActual
    {

        public UsuarioActual()
        {

        }

        private static IPrincipal Usuario {
            get
            {
              return  (IPrincipal)HttpContext.Current.User;
            }
        }

        public bool EstaAutentificado { get
            {
                return Usuario.Identity.IsAuthenticated;
            }
        }
        

        public bool TieneRol(string role)
        {
            if (EstaAutentificado)
            {
                return Usuario.IsInRole(role);
            }

            return false;
        }
      
        public string NombreUsuario
        {
            get
            {

                if (EstaAutentificado)
                {
                    return Usuario.Identity.Name;
                }

                return "";

            }
        }
        public bool EsAdministrador { get
            {
                return TieneRol(Roles.ADMINISTRADOR);
            }
        }
        

        public bool EsEditor {
            get
            {
                return TieneRol(Roles.EDITOR);
            }
        }
       

        public bool EsLector { get
            {
                return TieneRol(Roles.LECTOR);
            }
        }
        
    }
}