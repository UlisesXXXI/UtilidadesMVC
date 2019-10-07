﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Unity;
using Utilidades.Infraestructura.Seguridad;
using Utilidades.Infraestructura.Seguridad.imp;
using Utilidades.Infraestructura.Seguridad.inter;

namespace Utilidades.Infraestructura.Comun
{
    public static class ContextoApp
    {
         private static IUsuarioActual _usuario;

         static ContextoApp()
        {
            _usuario = new UsuarioActual();
        }

        public static IUnityContainer Container {get;set;}

        public static IUsuarioActual Usuario { get { return _usuario; }  }

        public static T Resolver<T>()
        {
            return ((IUnityContainer)Container).Resolve<T>();
        }

    }
}