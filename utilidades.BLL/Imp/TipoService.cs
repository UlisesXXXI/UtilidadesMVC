using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using utilidades.BLL.Inter;
using utilidades.DAL.comun.inter;
using utilidades.DAL.Repositorio;

namespace utilidades.BLL.Imp
{
    public class TipoService: Service<Tipo>, IService<Tipo>
    {
        public TipoService(DbContext ctx, 
                           IRepositorio<Tipo> repositorio) 
            :base(ctx,repositorio)
        {

        }

       
    }
}
