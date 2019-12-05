using Infraestructura.comun.EntityFramework;
using Infraestructura.comun.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using utilidades.BLL.Inter;
using utilidades.Entities.Repositorio;
using Utilidades.Infraestructura.Filtros;
using Utilidades.Infraestructura.Helpers.Controllers;
using Utilidades.Infraestructura.Managers.Inter;
using Utilidades.ViewModels.Articulo;

namespace Utilidades.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {

        private IArticuloService _articuloService;

        private IArticuloManager _articuloManager;

        public HomeController(IArticuloService articuloService,
                              IArticuloManager articuloManager
                            )
        {
            _articuloService = articuloService;

            _articuloManager = articuloManager;
        }

        public ActionResult Index(FiltroArticulo filtro)
        {
            
            var paginado = _articuloManager.FiltroPaginado(filtro);

            return View(paginado);
  
        }

       

        public ActionResult Articulo(int id)
        {

            var articulo = _articuloManager.Buscar(x => x.Id == id);

            if (articulo == null) return HttpNotFound();

            if(articulo.Privado || !articulo.Activo)
            {
                if(articulo.UsuarioCreacion != ContextoApp.Usuario.NombreUsuario || !ContextoApp.Usuario.EsAdministrador)
                {
                    return HttpNotFound();
                }
            }

            return View(articulo);
        }

    }
}