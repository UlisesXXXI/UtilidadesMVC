using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using utilidades.Entities.Repositorio;
using Utilidades.Infraestructura.Filtros;
using Utilidades.ViewModels;
using Utilidades.ViewModels.Articulo;

namespace Utilidades.Infraestructura.Managers.Inter
{
    public interface IArticuloManager
    {
        List<ArticuloViewModel> Todos(System.Linq.Expressions.Expression<Func<Articulo, bool>> where);

        ArticuloViewModel Buscar(System.Linq.Expressions.Expression<Func<Articulo, bool>> where);

        ArticuloViewModel Guardar(ArticuloViewModel articulo);


        ArticuloViewModel Modificar(ArticuloViewModel articulo);


        void Eliminar(ArticuloViewModel articulo);

        void RellenarSeleccionables(ArticuloViewModelBase vm);

        ArticuloPaginadoViewModel FiltroPaginado(FiltroArticulo filtro);

    }
}