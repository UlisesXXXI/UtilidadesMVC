using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using utilidades.BLL;
using Utilidades.Infraestructura;
using Utilidades.Infraestructura.Managers.Inter;
using Utilidades.ViewModels.Usuarios;

namespace Utilidades.Areas.Admin.Controllers
{
    
    public class UsuariosController : Controller
    {
        private UserService _userService;

        private SignInService _signInService;

        private IUsuariosManager _usuarioManager;

        private IUsuariosManager UsuarioManager
        {
            get
            {
                if (_usuarioManager == null)
                    return (((IUnityContainer)ContextoApp.Container).Resolve<IUsuariosManager>());
                else
                    return _usuarioManager;
            }
        }

        public UsuariosController(UserService userService, SignInService signInService)
        {
            _userService = userService;

            _signInService = signInService;

            
        }

        // GET: Admin/Usuarios
        public ActionResult Index()
        {
            

            return View();
        }


        public ActionResult LogIn()
        {
            return null;
        }

        public ActionResult LogOut()
        {
            return null;
        }

        public ActionResult Create()
        {
            var vm = UsuarioManager.RellenarNuevoUsuario();

            return View(vm);
        }

        public ActionResult Create(newUserViewModel usuario)
        {
            var vm = UsuarioManager.RellenarNuevoUsuario();

            return View(vm);
        }


        
    }
}