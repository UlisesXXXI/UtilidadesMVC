using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.comun
{
    public class Paginacion
    {

        public int PaginaActual { get; set; }

        public int TotalPaginas { get; set; }

        public string CampoOrdenacion { get; set; }

        public string Orden { get; set; }

        public Paginacion()
        {
            Orden = "ASC";
        }
    }
}
