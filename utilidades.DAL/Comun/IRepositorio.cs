using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilidades.Entities.Comun;

namespace utilidades.DAL.comun
{
    public interface IRepositorio<T> where T:EntidadBase
    {

        IQueryable<T> Buscar(params object[] key);

        IQueryable<T> Buscar(System.Linq.Expressions.Expression<Func<T, bool>> where);

        T Modificar(T entidad, string usuario ="", bool autoguardado = false);

        T Guardar(T entidad, string usuario = "", bool autoguardado = false);

        T Eliminar(params object[] Key);

        void Eliminar(System.Linq.Expressions.Expression<Func<T, bool>> where,string usuario, bool autoguardado = false);
        
        void Eliminar(T entidad,bool autoguardado = false);

        void GuardarContexto();
    }
}
