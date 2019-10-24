using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using utilidades.BLL.Inter;
using utilidades.Entities.Repositorio;
using Utilidades.Infraestructura.Managers.Inter;
using Utilidades.ViewModels;
using System.Data.Entity;
using Utilidades.Infraestructura.Comun;
using Utilidades.ViewModels.Articulo;
using Utilidades.ViewModels.Tag;
using Utilidades.ViewModels.TipoArticulo;
using Utilidades.Infraestructura.comun;
using Infraestructura.comun.Shared;
using Utilidades.Infraestructura.Filtros;
using Infraestructura.comun.EntityFramework;

namespace Utilidades.Infraestructura.Managers.Imp
{
    public class ArticuloManager:IArticuloManager
    {
        private IArticuloService _articuloService;

        private ITipoService _tipoService;

        private ITagService _tagService;

        public ArticuloManager(IArticuloService articuloService
                               ,ITipoService tipoService
                               ,ITagService tagService)
        {
            _articuloService = articuloService;

            _tipoService = tipoService;

            _tagService = tagService;
        }

        public List<ArticuloViewModel> Todos(Expression<Func<Articulo, bool>> where)
        {
            var query = _articuloService.Buscar(where).Include(x => x.Tipo).Include(x => x.Tags).AsNoTracking();

            var resultado = query.ToList().Select(x => ViewModelFromArticulo(x)).ToList();

            if (!ContextoApp.Usuario.EsAdministrador)
            {
               return  resultado.Where(x => x.UsuarioCreacion == ContextoApp.Usuario.NombreUsuario).ToList();
            }
            return resultado;

        }


        public void Eliminar(ArticuloViewModel articulo)
        {
            
        }


        public ArticuloViewModel Guardar(ArticuloViewModel articulo)
        {
            Articulo art = ArticuloFromViewModel(articulo);

            var tags = art.Tags;

            art = _articuloService.Guardar(art,ContextoApp.Usuario.NombreUsuario);

            return new ArticuloViewModel() { Id = art.Id };
        }

        public ArticuloViewModel Modificar(ArticuloViewModel articulo)
        {
            Articulo art = ArticuloFromViewModel(articulo);

            var tags = art.Tags;

            art = _articuloService.Modificar(art, ContextoApp.Usuario.NombreUsuario);

            return new ArticuloViewModel() { Id = art.Id };
        }

        public void RellenarSeleccionables(ArticuloViewModelBase vm)
        {
            vm.TodosLosTipos = _tipoService.Todos().Select(s => new SelectableTipoViewModel() { Descripcion = s.Descripcion, Id = s.Id }).ToList();

            vm.TodosLosTags = _tagService.Todos().Select(s => new SelectableTagViewModel() { Descripcion = s.Descripcion, Id = s.Id }).ToList();
        }

        public ArticuloViewModel Buscar(Expression<Func<Articulo, bool>> where)
        {
            var query = _articuloService.Buscar(where).Include(x => x.Tipo).Include(x => x.Tags);

            if (!ContextoApp.Usuario.EsAdministrador)
            {
                query.Where(x => x.UsuarioCreacion == ContextoApp.Usuario.NombreUsuario);
            }

            var resultado = ViewModelFromArticulo(query.AsNoTracking().First());

            if (resultado!=null)
            {
                RellenarSeleccionables(resultado);
            }

            return resultado;
        }

        public static Articulo ArticuloFromViewModel(ArticuloViewModel vm)
        {
            Articulo art = new Articulo()
            {
                Id = vm.Id,
                UsuarioCreacion = vm.UsuarioCreacion,
                Activo = vm.Activo,
                Contenido = vm.Contenido,
                FechaCreacion = vm.FechaCreacion,
                Privado = vm.Privado,
                Tags = vm.TagsSeleccionados.Select(s => new Tag() { Descripcion = s.Descripcion }).ToList(),
                TipoId = vm.TipoId,
                Titulo = vm.Titulo


            };

            return art;
        }

        public static ArticuloViewModel ViewModelFromArticulo(Articulo articulo)
        {
            ArticuloViewModel art = new ArticuloViewModel()
            {
                Id = articulo.Id,
                UsuarioCreacion = articulo.UsuarioCreacion,
                Activo = articulo.Activo,
                Contenido = articulo.Contenido,
                FechaCreacion = articulo.FechaCreacion,
                Privado = articulo.Privado,
                Tags = articulo.Tags,
                Tipo = articulo.Tipo,
                TagsSeleccionados = articulo.Tags.Select(s => new SelectableTagViewModel() { Descripcion = s.Descripcion, Eliminado = false }).ToList(),
                TipoId = articulo.TipoId,
                Titulo = articulo.Titulo

            };

            return art;
        }

        public ArticuloPaginadoViewModel FiltroPaginado(FiltroArticulo filtro)
        {
            var predicado = GenerarWhereBusqueda(filtro);

            var query = _articuloService.Buscar(predicado);
            
            var resultado = query.Include(x => x.Tipo).Include(i => i.Tags).ToList();

            List<ArticuloViewModel> listado = AutoMapper.Mapper.Map<List<ArticuloViewModel>>(resultado);

            PagedList.IPagedList<ArticuloViewModel> paginado = new PagedList.PagedList<ArticuloViewModel>(listado, filtro.Pagina, 30);

            var vm = new ArticuloPaginadoViewModel();

            vm.Articulos = paginado;

            return vm;
        }


        private System.Linq.Expressions.Expression<Func<Articulo, bool>> GenerarWhereBusqueda(FiltroArticulo filtro)
        {


            var predicado = PredicateBuilder.And<Articulo>(x => true, x => x.Activo == true && x.Privado == false);



            if (!String.IsNullOrEmpty(filtro.BusquedaGlobal))
            {
                predicado = PredicateBuilder.And(predicado, wh => wh.Contenido.Contains(filtro.BusquedaGlobal)
                                                                                        || wh.Tipo.Descripcion.Contains(filtro.BusquedaGlobal)
                                                                                        || wh.Tags.Any(a => a.Descripcion.Contains(filtro.BusquedaGlobal)
                                                                                        || wh.Titulo.Contains(filtro.BusquedaGlobal)));
            }



            return predicado;
        }
    }
}