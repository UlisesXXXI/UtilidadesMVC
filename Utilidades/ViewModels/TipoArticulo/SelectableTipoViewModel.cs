using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utilidades.ViewModels.TipoArticulo
{
    public class SelectableTipoViewModel
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }
    }
}