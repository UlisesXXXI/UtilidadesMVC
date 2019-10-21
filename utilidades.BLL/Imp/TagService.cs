using System.Data.Entity;
using utilidades.BLL.Inter;
using utilidades.DAL.comun;
using utilidades.Entities.Repositorio;

namespace utilidades.BLL.Imp
{
    public class TagService:Service<Tag>,ITagService
    {

        public TagService(DbContext ctx, 
                            IRepositorio<Tag> repositorio):base(ctx,repositorio)
        {

        }
    }
}
