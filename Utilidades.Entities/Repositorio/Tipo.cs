using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using utilidades.Entities.Comun;

namespace utilidades.Entities.Repositorio
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

        public string TipoDato { get; set; }
        
        public byte[] Imagen { get; set; }
    }
}
