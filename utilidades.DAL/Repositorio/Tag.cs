using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utilidades.DAL.Repositorio
{
    public class Tag
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }

    }
}
