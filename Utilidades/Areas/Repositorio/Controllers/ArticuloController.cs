using Infraestructura.comun.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using utilidades.BLL.Inter;
using Utilidades.Infraestructura.Helpers.Controllers;
using Utilidades.Infraestructura.Managers.Inter;
using Utilidades.ViewModels.Articulo;

namespace Utilidades.Areas.Repositorio.Controllers
{
    [Authorize]
    public class ArticuloController : BaseController
    {
        private IArticuloManager _articuloManager;
        
        public ArticuloController(IArticuloManager articuloManager)
        {

            _articuloManager = articuloManager;

        }

        // GET: Repositorio/Articulo
        public ActionResult Index()
        {
            var listado = _articuloManager.Todos(null);

            return View(listado);
        }

        // GET: Repositorio/Articulo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Repositorio/Articulo/Create
        public ActionResult Create()
        {
            var vm = new ArticuloViewModel();

            _articuloManager.RellenarSeleccionables(vm);
            
            return View(vm);
        }

        // POST: Repositorio/Articulo/Create
        [HttpPost]
        public ActionResult Create(ArticuloViewModel articulo)
        {
            articulo.TagsSeleccionados = articulo.TagsSeleccionados.Where(s => s.Eliminado == false).ToList();

            if (ModelState.IsValid)
            {


               articulo = _articuloManager.Guardar(articulo);

                AddMessage("Articulo grabado correctamente", Infraestructura.Managers.Imp.MessageType.Normal);

                return RedirectToAction("Edit", new { Area = "Repositorio", id = articulo.Id });
            }

            AddMessage("Hubo un error al guardar", Infraestructura.Managers.Imp.MessageType.Error);

            

            _articuloManager.RellenarSeleccionables(articulo);

            articulo.Tags = articulo.TagsSeleccionados.Select(s => new utilidades.Entities.Repositorio.Tag() { Descripcion = s.Descripcion }).ToList();

            return View(articulo);
        }

        // GET: Repositorio/Articulo/Edit/5
        
        public ActionResult Edit(int id)
        {
            var vm = _articuloManager.Buscar(x => x.Id == id);

            if(vm.UsuarioCreacion != ContextoApp.Usuario.NombreUsuario && !ContextoApp.Usuario.EsAdministrador)
            {
                return new HttpUnauthorizedResult();
            }
            return View(vm);
        }

        // POST: Repositorio/Articulo/Edit/5
        [HttpPost]
        public ActionResult Edit(ArticuloViewModel articulo)
        {
            articulo.TagsSeleccionados = articulo.TagsSeleccionados.Where(s => s.Eliminado == false).ToList();

            if (ModelState.IsValid)
            {

                articulo = _articuloManager.Modificar(articulo);

                AddMessage("Articulo grabado correctamente", Infraestructura.Managers.Imp.MessageType.Normal);

                return RedirectToAction("Edit", new { Area = "Repositorio", id = articulo.Id });
            }

            AddMessage("Hubo un error al guardar", Infraestructura.Managers.Imp.MessageType.Error);

            articulo.Tags = articulo.TagsSeleccionados.Select(s => new utilidades.Entities.Repositorio.Tag() { Descripcion = s.Descripcion }).ToList();

            _articuloManager.RellenarSeleccionables(articulo);

            return View(articulo);
        }

        // GET: Repositorio/Articulo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Repositorio/Articulo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
