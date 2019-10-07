using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilidades.DAL.comun;


namespace utilidades.DAL.Repositorio
{
    public class Articulo:EntidadBase,IEntidadAuditable,IActivo
    {

        public Articulo()
        {
            Tags = new List<Tag>();
        }

        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Contenido { get; set; }

        public int TipoId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }

        public string UsuarioModificacion { get; set; }

        public bool Activo { get; set; }

        public bool Privado { get; set; }

        public virtual Tipo Tipo { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

       

    }
}
