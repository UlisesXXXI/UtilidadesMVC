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
using utilidades.Entities.Comun;

namespace utilidades.BLL.Imp
{
    public class Service<TEntidad>:IService<TEntidad> where TEntidad: EntidadBase
    {
        protected DbContext _ctx;

        protected IRepositorio<TEntidad> _repositorio;

        public Service(DbContext ctx,IRepositorio<TEntidad> repositorio)
        {
            _ctx = ctx;

            _repositorio = repositorio;
        }

        public virtual IQueryable<TEntidad> Buscar(Expression<Func<TEntidad, bool>> condicion)
        {
            return _repositorio.Buscar(condicion).AsNoTracking();
        }

        public virtual void Eliminar(Expression<Func<TEntidad, bool>> condicion,string usuario = "")
        {
             _repositorio.Eliminar(condicion,usuario, true);
        }

        

        public virtual TEntidad Guardar(TEntidad tipo, string usuario)
        {
            return _repositorio.Guardar(tipo, usuario, true);
        }

        

        public virtual TEntidad Modificar(TEntidad tipo, string usuario)
        {
           return  _repositorio.Modificar(tipo, usuario, true);
        }

        public virtual IEnumerable<TEntidad> ObtenerTodos()
        {
            return Todos();
        }

        public IEnumerable<TEntidad> Todos()
        {
            return _ctx.Set<TEntidad>().AsNoTracking().ToList();
        }
    }
}
