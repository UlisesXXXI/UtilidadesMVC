using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utilidades.Entities.Comun
{
    public interface IEntidadAuditable
    {
         DateTime FechaCreacion { get; set; }
         string UsuarioCreacion { get; set; }
         DateTime FechaModificacion { get; set; }
         string UsuarioModificacion { get; set; }
    }
}
