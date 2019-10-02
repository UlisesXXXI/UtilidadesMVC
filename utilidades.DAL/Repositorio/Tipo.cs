using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilidades.DAL.comun;

namespace utilidades.DAL.Repositorio
{
    public class Tipo:EntidadBase
    {


        public int Id { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }

    }
}
