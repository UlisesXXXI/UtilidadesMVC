using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utilidades.Infraestructura.Seguridad.inter
{
    public interface IUsuarioActual
    {
        bool EstaAutentificado();

        bool TieneRol(string role);

        string NombreUsuario();
    }
}