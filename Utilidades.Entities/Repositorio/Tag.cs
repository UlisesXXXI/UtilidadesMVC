using System.Collections.Generic;
using utilidades.Entities.Comun;

namespace utilidades.Entities.Repositorio
{
    public class Tag:EntidadBase
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }

    }
}
