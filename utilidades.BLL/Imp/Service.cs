using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using utilidades.BLL.Inter;
using utilidades.DAL.comun;
using utilidades.DAL.comun.inter;

namespace utilidades.BLL.Imp
{
    public class Service<TEntidad>:IService<TEntidad> where TEntidad: EntidadBase
    {
        private DbContext _ctx;

        private IRepositorio<TEntidad> _repositorio;

        public Service(DbContext ctx,IRepositorio<TEntidad> repositorio)
        {
            _ctx = ctx;
        }

        public virtual IQueryable<TEntidad> Buscar(Expression<Func<TEntidad, bool>> condicion)
        {
            return _repositorio.Buscar(condicion);
        }

        public virtual void Eliminar(Expression<Func<TEntidad, bool>> condicion)
        {
             _repositorio.Eliminar(condicion, true);
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
            return _repositorio.Buscar().ToList();
        }
    }
}
