using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using utilidades.BLL.Inter;
using Utilidades.Infraestructura;
using Utilidades.Infraestructura.Comun;
using Utilidades.Infraestructura.Helpers.Controllers;
using Utilidades.ViewModels.Articulo;
using System.Data.Entity;
using Utilidades.Infraestructura.Managers.Inter;
using System.Data.Entity;

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

        public ActionResult Index(string busqueda = null, int pagina=1)
        {

            List<ArticuloViewModel> listado = AutoMapper.Mapper.Map<List<ArticuloViewModel>>(_articuloService.Buscar(x=>x.Activo ==true && x.Privado == false).Include(x=>x.Tipo).ToList());

            

            return View(listado);
  
        }

        public ActionResult Articulo(int id)
        {
            _articuloService.Buscar(x => x.Id == id).First();

            var articulo = _articuloManager.Buscar(x => x.Id == id);

            return View(articulo);
        }

    }
}