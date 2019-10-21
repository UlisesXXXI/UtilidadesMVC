using System;
using System.Collections.Generic;
using System.Linq;

namespace utilidades.BLL.Inter
{
    public interface IService<T>
    {
        IEnumerable<T> ObtenerTodos();

        T Guardar(T tipo,string usuario);

        T Modificar(T tipo,string usuario);

        void Eliminar(System.Linq.Expressions.Expression<Func<T, bool>> condicion,string usuario = "");

        IQueryable<T> Buscar(System.Linq.Expressions.Expression<Func<T, bool>> condicion);

        IEnumerable<T> Todos();

    }
}
