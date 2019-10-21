using System.Data.Entity;
using utilidades.BLL.Inter;
using utilidades.DAL.comun;
using utilidades.Entities.Repositorio;

namespace utilidades.BLL.Imp
{
    public class TipoService: Service<Tipo>, ITipoService
    {
        public TipoService(DbContext ctx, 
                           IRepositorio<Tipo> repositorio) 
            :base(ctx,repositorio)
        {

        }

      
    }
}
