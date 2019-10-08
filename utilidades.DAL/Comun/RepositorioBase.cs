using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilidades.DAL.dbContext;

namespace utilidades.DAL.comun
{
    public class RepositorioBase<TEntity>:IRepositorio<TEntity> where TEntity:EntidadBase
    {

        private DbContext _ctx;

        private DbSet<TEntity> _dbSet;

        public RepositorioBase(DbContext ctx)
        {
            _ctx = ctx;
            _dbSet = ctx.Set<TEntity>();
        }

        public IQueryable<TEntity> Buscar(params object[] key)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Buscar(System.Linq.Expressions.Expression<Func<TEntity, bool>> where)
        {
            
            return _dbSet.Where(where);

        }

        public TEntity Modificar(TEntity entidad, string usuario ="", bool autoguardado = false)
        {
               if(entidad is IEntidadAuditable){
                   AsignarFechaModificacion((IEntidadAuditable)entidad,usuario);
               }

               _ctx.Entry(entidad).State = EntityState.Modified;

            if (autoguardado) GuardarContexto();

            return entidad;
        }

        public TEntity Guardar(TEntity entidad, string usuario="", bool autoguardado = false)
        {
             if(entidad is IEntidadAuditable){
                   AsignarFechaCreacionYModificacion((IEntidadAuditable)entidad,usuario);
               }

               _ctx.Entry(entidad).State = EntityState.Added;

            if(autoguardado){
                GuardarContexto();
            }

            return entidad;
        }

        public TEntity Eliminar(params object[] Key)
        {
            throw new NotImplementedException();
        }

       

        public void GuardarContexto()
        {
            _ctx.SaveChanges();
        }

        public void ObtenerKeys()
        {
            var et = typeof(TEntity);

            var props = et.GetProperties();

            Dictionary<String,Type> claves = new Dictionary<string,Type>();

            foreach (var p in props)
            {

                //System.Object[] attributes = p.GetCustomAttributes(true);

                //foreach (var attr in attributes){
                //    if(attr is EdmScalarPropertyAttribute){
                //        if ((attr as EdmScalarPropertyAttribute).EntityKeyProperty == true)
                //        {
                //            claves.Add(p.Name,p.PropertyType);
                //            break;
                //        }else if(attr is ColumnAttribute){
                //            if((attr as ColumnAttribute). == true){

                //            }
                //        }
                            

                //    }
                //}
	
		 
	        }

        }
            
        public void AsignarFechaModificacion(IEntidadAuditable entidad, string usuario){

            entidad.FechaModificacion = DateTime.Now;

            entidad.UsuarioModificacion = usuario;
            
        }

        public void AsignarFechaCreacionYModificacion(IEntidadAuditable entidad, string usuario){

            entidad.FechaCreacion = DateTime.Now;

            entidad.UsuarioCreacion = usuario;

            AsignarFechaModificacion(entidad,usuario);

        }

            

        

       public void Eliminar(System.Linq.Expressions.Expression<Func<TEntity,bool>> where,string usuario="", bool autoguardado = false)
       {
            TEntity entidad = _ctx.Set<TEntity>().Where(where).AsNoTracking().First();

            if (entidad == null)
                throw new Exception("Entidad no encontrada");

            if(entidad is IEntidadBorradoLogico)
            {
                ((IEntidadBorradoLogico)entidad).Borrado = true;
                Guardar(entidad, usuario, autoguardado);
            }
            else
            {
                _ctx.Entry(entidad).State = EntityState.Deleted;

                if (autoguardado) GuardarContexto();
            }
       }

       public void Eliminar(TEntity entidad, bool autoguardado = false)
       {
 	            throw new NotImplementedException();
       }
  } 
    
}
