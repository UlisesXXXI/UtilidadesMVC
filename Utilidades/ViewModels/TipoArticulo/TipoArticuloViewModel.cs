using Infraestructura.comun.Configuraciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Utilidades.ViewModels.TipoArticulo
{
    public class TipoArticuloViewModel
    {
        public TipoArticuloViewModel()
        {

        }

        public int Id { get; set; }

        [MaxLength(ConstantesGeneralesConfiguracion.TAMAÑO_CADENA_PEQUEÑO)]
        public string Descripcion { get; set; }

        public string TipoDato { get; set; }

        public byte[] Imagen { get; set; }

        public string Base64()
        {
            if(Imagen!=null && Imagen.Length > 0)
            {
                 String img64 = Convert.ToBase64String(Imagen);
                String img64Url = string.Format("data:image/" + TipoDato + ";base64,{0}", img64); //imagetype can be e.g. gif
                return img64Url;
            }
            return "";
        }
    }
}