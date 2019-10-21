using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using utilidades.Entities.Repositorio;
using Utilidades.ViewModels.Tag;
using Utilidades.ViewModels.TipoArticulo;

namespace Utilidades.ViewModels.Articulo
{
    public abstract class ArticuloViewModelBase
    {
        public ICollection<SelectableTipoViewModel> TodosLosTipos { get; set; }

        public virtual ICollection<SelectableTagViewModel> TodosLosTags { get; set; }
    }
}