using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Utilidades.Areas.Admin.Controllers
{
    public class TipoArticuloController : Controller
    {
        // GET: Admin/TipoArticulo
        public ActionResult Index()
        {


            return View();
        }

        // GET: Admin/TipoArticulo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/TipoArticulo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/TipoArticulo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/TipoArticulo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/TipoArticulo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/TipoArticulo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/TipoArticulo/Delete/5
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
