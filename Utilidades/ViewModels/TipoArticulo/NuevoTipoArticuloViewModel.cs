using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Utilidades.ViewModels.TipoArticulo
{
    public class NuevoTipoArticuloViewModel
    {
        public NuevoTipoArticuloViewModel()
        {

        }

        [MaxLength(utilidades.DAL.Configuraciones.ConstantesGeneralesConfiguracion.TAMAÑO_CADENA_PEQUEÑO)]
        public string Descripcion { get; set; }
    }
}