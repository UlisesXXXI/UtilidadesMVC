using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilidades.Infraestructura.Filtros;

namespace Utilidades.ViewModels.Articulo
{
    public class ArticuloPaginadoViewModel
    {

        public ArticuloPaginadoViewModel()
        {

        }

        public FiltroArticulo Filtro { get; set; }

        public PagedList.IPagedList<ArticuloViewModel> Articulos { get; set; }

    }
}