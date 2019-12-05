using System;
using System.Collections.Generic;
using utilidades.Entities.Repositorio;
using utilidades.Entities;
using System.Web.Mvc;
using Utilidades.ViewModels.Tag;

namespace Utilidades.ViewModels.Articulo
{
    public class ArticuloViewModel:ArticuloViewModelBase
    {

        public int Id { get; set; }

        public string Titulo { get; set; }
        [AllowHtml]
        public string Contenido { get; set; }

        public int TipoId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; }

        public bool Activo { get; set; }

        public bool Privado { get; set; }

        public virtual Tipo Tipo { get; set; }

        public List<SelectableTagViewModel> TagsSeleccionados { get; set; }

        public virtual ICollection<utilidades.Entities.Repositorio.Tag> Tags { get; set; }

        public string Base64()
        {
            if (Tipo == null) return "";

            if (Tipo.Imagen != null && Tipo.Imagen.Length > 0)
            {
                String img64 = Convert.ToBase64String(Tipo.Imagen);
                String img64Url = string.Format("data:" + Tipo.TipoDato + ";base64,{0}", img64); //imagetype can be e.g. gif
                return img64Url;
            }
            return "";
        }

    }
}