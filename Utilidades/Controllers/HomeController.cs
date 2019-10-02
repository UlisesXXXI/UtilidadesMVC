using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilidades.Infraestructura;
using Utilidades.Infraestructura.Helpers.Controllers;

namespace Utilidades.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {

            string nombre = ContextoApp.Usuario.NombreUsuario();
            return View();

           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}