using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utilidades.Infraestructura;
using Utilidades.Infraestructura.Comun;
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

    }
}