using AutoMapper;
using Infraestructura.comun.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using utilidades.BLL.Inter;
using utilidades.Entities.Repositorio;
using Utilidades.Infraestructura.Comun;
using Utilidades.Infraestructura.Comun.Json;
using Utilidades.Infraestructura.Helpers.Controllers;
using Utilidades.ViewModels.Tag;

namespace Utilidades.Areas.Admin.Controllers
{
    [Authorize]
    public class TagController : BaseController
    {
        private ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        // GET: Admin/Tag
        public ActionResult Index()
        {
            List<TagViewModel> tagVm = Mapper.Map<List<TagViewModel>>( _tagService.Todos().ToList());
            return View(tagVm);
        }

        // GET: Admin/Tag/Details/5
        public ActionResult Details(int id)
        {
            TagViewModel tagVm = Mapper.Map<TagViewModel>(_tagService.Buscar(x=>x.Id == id).First());

            return View(tagVm);
        }

        // GET: Admin/Tag/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Tag/Create
        [HttpPost]
        public ActionResult Create(TagViewModel tagVm)
        {
            var repetida =  _tagService.Buscar(x => x.Descripcion.Equals(tagVm.Descripcion)).FirstOrDefault();

            if (repetida == null)
            {
                if (ModelState.IsValid)
                {
                    Tag entidad = Mapper.Map<Tag>(tagVm);

                    var e = _tagService.Guardar(entidad, ContextoApp.Usuario.NombreUsuario);

                    AddMessage("Guardado correctamente", Infraestructura.Managers.Imp.MessageType.Normal);

                    return RedirectToAction("Edit", new { id = e.Id });

                }

                AddMessage("hay datos incorrectos", Infraestructura.Managers.Imp.MessageType.Error);
            }
            else
            {
                AddMessage("Ya existe el tag '" + tagVm.Descripcion+"'", Infraestructura.Managers.Imp.MessageType.Error);
            }

            

            return View(tagVm);
        }

        // GET: Admin/Tag/Edit/5
        public ActionResult Edit(int id)
        {
            TagViewModel tagVm = Mapper.Map<TagViewModel>(_tagService.Buscar(x => x.Id == id).First());

            return View(tagVm);
        }

        // POST: Admin/Tag/Edit/5
        [HttpPost]
        public ActionResult Edit(TagViewModel tagVm)
        {
            if (ModelState.IsValid)
            {
                Tag entidad = Mapper.Map<Tag>(tagVm);

               var e =  _tagService.Modificar(entidad, ContextoApp.Usuario.NombreUsuario);

                AddMessage("Guardado correctamente", Infraestructura.Managers.Imp.MessageType.Normal);

                return RedirectToAction("Edit", new { id = e.Id });
               
            }

            AddMessage("hay datos incorrectos", Infraestructura.Managers.Imp.MessageType.Error);

            return View(tagVm);
        }

        // GET: Admin/Tag/Delete/5
        public ActionResult Delete(int id)
        {
            var entidad = Mapper.Map<TagViewModel>(_tagService.Buscar(wh => wh.Id == id).First());

            if(entidad==null)
            {
                AddMessage("Entidad no encontrada", Infraestructura.Managers.Imp.MessageType.Error);

                return RedirectToAction("Index");
            }

            

            return View(entidad);
        }

        // POST: Admin/Tag/Delete/5
        [HttpPost]
        public ActionResult Delete(TagViewModel tagVm)
        {

            _tagService.Eliminar(x => x.Id == tagVm.Id, ContextoApp.Usuario.NombreUsuario);

            AddMessage("Eliminado tag correctamente", Infraestructura.Managers.Imp.MessageType.Normal);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetTagsPorNombre( string nombre)
        {
           var r = _tagService.Buscar(x => x.Descripcion.Contains(nombre)).Select(s=> s.Descripcion).ToList();

            return Json(r);
        }

        [HttpPost]
        public JsonResult ObtenerOCrearTag(string tag)
        {
            Tag tagEntidad = new Tag();



            ResultadoJson resultado = new ResultadoJson();

            try
            {
                 tagEntidad = _tagService.Buscar(x => x.Descripcion.Equals(tag)).FirstOrDefault();

                if (tagEntidad == null)
                {
                    Tag newTipo = new Tag();
                    newTipo.Descripcion = tag;
                    tagEntidad = _tagService.Guardar(newTipo, ContextoApp.Usuario.NombreUsuario);
                }


            }
            catch(Exception exp)
            {
                resultado.AddErrores("Hubo un erro al asignar el tag");
            }


            resultado.Datos.Add(tagEntidad);


            return Json(resultado);
        }
            
    }
}
