using Infraestructura.comun.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilidades.BLL.Inter;
using utilidades.DAL.comun;
using utilidades.Entities.Repositorio;
using Utilidades.Infraestructura.comun;

namespace utilidades.BLL.Imp
{
    public class ArticuloService:Service<Articulo>,IArticuloService
    {
        private RepositorioBase<Tag> _tagRepositorio;

        private RepositorioBase<Tipo> _tipoRepositorio;

        public ArticuloService(DbContext ctx,
                            RepositorioBase<Articulo> repositorio,
                            RepositorioBase<Tag> tagRepositorio,
                            RepositorioBase<Tipo> tipoRepositorio)
                            :base(ctx,repositorio)
        {

            _tagRepositorio = tagRepositorio;

            _tipoRepositorio = tipoRepositorio;
            
        }


        public override Articulo Guardar(Articulo tipo, string usuario)
        {

            List<String> listaDeTags = tipo.Tags.Select(s => s.Descripcion).ToList();
            //buscamos tags
            var tags = _tagRepositorio.Buscar(x => listaDeTags.Contains(x.Descripcion)).ToList();

           

            tipo.Tags = tags;

            tipo =  _repositorio.Guardar(tipo,usuario,false);

            GuardarUOW();

            return tipo;

        }

        public override Articulo Modificar(Articulo tipo, string usuario)
        {
            _ctx.Configuration.AutoDetectChangesEnabled = true;

            List<String> listaDeTags = tipo.Tags.Select(s => s.Descripcion).ToList();
            //buscamos tags
            var tags = _tagRepositorio.Buscar(x => listaDeTags.Contains(x.Descripcion)).ToList();

            if (!ContextoApp.Usuario.EsAdministrador)
            {

            }

            var Entidad = _repositorio.Buscar(wh => wh.Id == tipo.Id).Include(x=>x.Tags).Single();

            if(!ContextoApp.Usuario.EsAdministrador && Entidad.UsuarioCreacion != usuario)
            {
                throw new Exception("No encontrado recurso");
            }

            var tagsEliminar = Entidad.Tags.Where(wh => !listaDeTags.Contains(wh.Descripcion)).ToList();

            foreach (var del in tagsEliminar)
            {
                Entidad.Tags.Remove(del);
            }

            var tagsInserar = tags.Where(x => !Entidad.Tags.Any(a => a.Descripcion == x.Descripcion)).ToList();

            foreach (var del in tagsInserar)
            {
                Entidad.Tags.Add(del);
            }

            

            Entidad.TipoId = tipo.TipoId;

            Entidad.Privado = tipo.Privado;

            Entidad.Titulo = tipo.Titulo;

            Entidad.Activo = tipo.Activo;

            Entidad.Contenido = tipo.Contenido;
            

            Entidad = _repositorio.Modificar(Entidad, usuario, false);

           

            GuardarUOW();
            _ctx.Configuration.AutoDetectChangesEnabled = false;
            return Entidad;
        }

        private void GuardarUOW()
        {
            _ctx.SaveChanges();
        }
    }
}
