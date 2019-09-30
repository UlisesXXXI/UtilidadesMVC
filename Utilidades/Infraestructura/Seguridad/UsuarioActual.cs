using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Utilidades.Infraestructura.Seguridad.inter;

namespace Utilidades.Infraestructura.Seguridad
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

        public bool EstaAutentificado()
        {
            return Usuario.Identity.IsAuthenticated;
        }

        public bool TieneRol(string role)
        {
            if (EstaAutentificado())
            {
                return Usuario.IsInRole(role);
            }

            return false;
        }

        public string NombreUsuario()
        {
            if (EstaAutentificado())
            {
                return Usuario.Identity.Name;
            }

            return "";
            
        }





       
    }
}