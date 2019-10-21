using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utilidades.ViewModels.Tag
{
    public class SelectableTagViewModel
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }
    }
}