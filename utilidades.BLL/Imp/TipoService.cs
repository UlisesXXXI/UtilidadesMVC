using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using utilidades.BLL.Inter;
using utilidades.DAL.comun;
using utilidades.DAL.dbContext;
using utilidades.DAL.Repositorio;

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
