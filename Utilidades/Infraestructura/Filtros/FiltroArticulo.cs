using Infraestructura.comun.Filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using utilidades.Entities.Repositorio;

namespace Utilidades.Infraestructura.Filtros
{
    public class FiltroArticulo:FiltroPaginadoBase
    {

        public string BusquedaGlobal { get; set; }

        public IEnumerable<int> Tipos { get; set; }

        public List<Tipo> TodosTipos { get; set; }

        public IEnumerable<String> Tags { get; set; }

        public IEnumerable<String> TodosTags { get; set; }

        public bool HayBusquedaAvanzada {
            get
            {
                return (
                        (Tags != null && Tags.Count() > 0) 
                        || (Tipos != null && Tipos.Count() > 0)
                        );

            }
            }
    }
}