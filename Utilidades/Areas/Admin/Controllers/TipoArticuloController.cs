using AutoMapper;
using Infraestructura.comun.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using utilidades.BLL.Inter;
using utilidades.Entities.Repositorio;
using Utilidades.Infraestructura.Comun;
using Utilidades.Infraestructura.Helpers.Controllers;
using Utilidades.ViewModels.TipoArticulo;

namespace Utilidades.Areas.Admin.Controllers
{
    public class TipoArticuloController : BaseController
    {
        private ITipoService _tipoService;

        public ITipoService TipoService
       { 
            get
            {
                
                return _tipoService;
            }
        }

        public TipoArticuloController(ITipoService tipoService)
        {
            _tipoService = tipoService;
        }


        // GET: Admin/TipoArticulo
        public ActionResult Index()
        {
            List<TipoArticuloViewModel> tipos = Mapper.Map<List<TipoArticuloViewModel>>( TipoService.Todos());

            return View(tipos);
        }

        // GET: Admin/TipoArticulo/Details/5
        public ActionResult Details(int id)
        {
            TipoArticuloViewModel tipo = Mapper.Map<TipoArticuloViewModel>(TipoService.Buscar(wh=>wh.Id == id).First());

            return View(tipo);
        }

        // GET: Admin/TipoArticulo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TipoArticulo/Create
        [HttpPost]
        public ActionResult Create(NuevoTipoArticuloViewModel tipo, HttpPostedFileBase file)
        {
            
            if (ModelState.IsValid)
            {
                
                Tipo entidad = Mapper.Map<Tipo>(tipo);

                if (file != null && file.ContentLength > 0)
                {
                    var stream = file.InputStream;

                    using (BinaryReader br = new BinaryReader(stream))
                    {
                        entidad.Imagen = br.ReadBytes((int)stream.Length);
                        entidad.TipoDato = file.ContentType;
                    }


                }

                entidad = TipoService.Guardar(entidad, ContextoApp.Usuario.NombreUsuario);

                AddMessage("Tipo guardado corretamente", Infraestructura.Managers.Imp.MessageType.Normal);


                return RedirectToAction("Edit", new { id = entidad.Id });
            }

            AddMessage("Hay datos incorrectos", Infraestructura.Managers.Imp.MessageType.Error);

            return View(tipo);

        }

        // GET: Admin/TipoArticulo/Edit/5
        public ActionResult Edit(int id)
        {
            TipoArticuloViewModel tipo = Mapper.Map<TipoArticuloViewModel>(TipoService.Buscar(wh => wh.Id == id).First());

            return View(tipo);
        }

        // POST: Admin/TipoArticulo/Edit/5
        [HttpPost]
        public ActionResult Edit(TipoArticuloViewModel tipo, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                Tipo t = _tipoService.Buscar(wh => wh.Id == tipo.Id).First();
                Tipo entidad = Mapper.Map(tipo, t);
                
                if(file!=null && file.ContentLength > 0)
                {
                    var stream = file.InputStream;

                    using (BinaryReader br = new BinaryReader(stream))
                    {
                        entidad.Imagen = br.ReadBytes((int)stream.Length);
                        entidad.TipoDato = file.ContentType;
                    }

                   
                }
                entidad = TipoService.Modificar(entidad, ContextoApp.Usuario.NombreUsuario);

                AddMessage("Tipo guardado corretamente", Infraestructura.Managers.Imp.MessageType.Normal);


                return RedirectToAction("Edit", new { id = entidad.Id });
            }

            AddMessage("Hay datos incorrectos", Infraestructura.Managers.Imp.MessageType.Error);

            return View(tipo);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var Tipo = _tipoService.Buscar(wh => wh.Id == id).First();
            if (Tipo == null)
                throw new Exception("No se encontro la entidad");

            TipoArticuloViewModel vm = new TipoArticuloViewModel();

            vm = Mapper.Map(Tipo, vm);

            return View(vm);
        }

        // POST: Admin/TipoArticulo/Delete/5
        [HttpPost]
        public ActionResult Delete(TipoArticuloViewModel tipo)
        {

            try
            {
              var Tipo = _tipoService.Buscar(wh => wh.Id == tipo.Id).First();
               if (Tipo == null)
                   throw new Exception("No se encontro la entidad");
                _tipoService.Eliminar(wh => wh.Id == tipo.Id,ContextoApp.Usuario.NombreUsuario);

               AddMessage("eliminado correctamente", Infraestructura.Managers.Imp.MessageType.Error);
              
            }
            catch (SqlException exc)
            {
                AddMessage(exc.Errors.ToString(), Infraestructura.Managers.Imp.MessageType.Error);
                throw;
            }
                
            return RedirectToAction("Index");
        }
    }
}
