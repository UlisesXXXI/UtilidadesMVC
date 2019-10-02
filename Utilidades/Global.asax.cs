using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Utilidades.App_Start;
using Utilidades.Controllers;
using Utilidades.infraestructura.Comun;

namespace Utilidades
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            UnityConfig.RegisterComponents();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var t =InicioAplicacion.ComprobarUsuarios().GetAwaiter();
        }

        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            Response.Clear();

            HttpException httpException = ex as HttpException;

            if (httpException != null)
            {
                RouteData routeData = new RouteData();
                routeData.Values.Add("controller", "Error");
                switch (httpException.GetHttpCode())
                {
                    case 404:
                        // page not found
                        routeData.Values.Add("action", "Index");
                        break;
                    case 500:
                        // server error
                        routeData.Values.Add("action", "Index");
                        break;
                    default:
                        routeData.Values.Add("action", "Index");
                        break;
                }

                routeData.Values.Add("error", ex);
                // clear error on server
                Server.ClearError();
                var appError = SanitizarError(httpException);
                routeData.Values.Add("appError", appError);
                IController ctl = new ErrorController();
                ctl.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
                // at this point how to properly pass route data to error controller?
            }




        }

        private AppError SanitizarError(HttpException httpException)
        {
            AppError customError = new AppError();
            customError.Id = Guid.NewGuid().ToString();
            customError.MessageError = httpException.Message;
            customError.Trace = httpException.StackTrace;
            return customError;
        }
    }
}
