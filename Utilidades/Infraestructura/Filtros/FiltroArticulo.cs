using Infraestructura.comun.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utilidades.Infraestructura.Filtros
{
    public class FiltroArticulo:FiltroPaginadoBase
    {

        public string BusquedaGlobal { get; set; }

        public IEnumerable<int> Tipos { get; set; }

        public IEnumerable<String> Tags { get; set; }
    }
}