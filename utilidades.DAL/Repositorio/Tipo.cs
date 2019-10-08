using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilidades.DAL.comun;

namespace utilidades.DAL.Repositorio
{
    public class Tipo:EntidadBase,IEntidadAuditable
    {


        public int Id { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
