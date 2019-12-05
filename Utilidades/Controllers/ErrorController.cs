using System.Web.Mvc;
using Utilidades.infraestructura.Comun;

namespace Utilidades.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(AppError appError)
        {
            return PartialView(appError);
        }

        public ActionResult NotFound()
        {
            return PartialView();
        }
    }
}