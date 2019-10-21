using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utilidades.Infraestructura.comun.Seguridad.inter
{
    public interface IUsuarioActual
    {
        bool EstaAutentificado { get; }

        bool TieneRol(string role);

        string NombreUsuario { get; }

        bool EsAdministrador { get; }

        bool EsEditor { get; }

        bool EsLector { get; }
    }
}