using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using utilidades.BLL;
using utilidades.DAL.UsuarioYRoles;
using Utilidades.Infraestructura;
using Utilidades.Infraestructura.Managers.Inter;
using Utilidades.ViewModels.Usuarios;

namespace Utilidades.Areas.Admin.Controllers
{
    
    public class UsuariosController : Controller
    {
        private UserService _userService;

        private SignInService _signInService;

        private RoleService _roleService;

        private IUsuariosManager _usuarioManager;

        

        public UsuariosController(UserService userService, 
                                SignInService signInService, 
                                RoleService roleService,
                                IUsuariosManager usuariosManager)
        {
            _userService = userService;

            _signInService = signInService;

            _roleService = roleService;

            _usuarioManager = usuariosManager;
            
        }

        // GET: Admin/Usuarios
        public ActionResult Index()
        {
            var u = new ApplicationUser();

            var Roles = _roleService.Roles.ToList();
            
            var listado = _userService.Users.Select(s => new UserViewModel() { Id = s.Id,
                                                                            Activo = s.Activo,
                                                                            Email = s.Email,
                                                                            RolesAsignados = s.Roles.Select(x=>x.RoleId)
                                                                            
                                                                            
             }).ToList();

            foreach (var usu in listado)
            {
                    var lroles = new List<String>();
                    foreach (var rolAsig in usu.RolesAsignados)
                    {
                        var role = Roles.Where(w => w.Id == rolAsig).FirstOrDefault(); 
                        if(role != null)
                        {
                            lroles.Add(role.Name);
                            
                        }
                    }
                    usu.RolesAsignados = lroles;
               

            }

            return View(listado);
        }


        public ActionResult LogIn()
        {
            return null;
        }

        public ActionResult LogOut()
        {
            return null;
        }

        [HttpGet]
        public ActionResult Create()
        {
            var vm = _usuarioManager.RellenarNuevoUsuario();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(newUserViewModel usuario)
        {
            var vm = _usuarioManager.RellenarNuevoUsuario();

            return View(vm);
        }

        public ActionResult Edit(string id)
        {

           var usuario =  _userService.Users.Where(w => w.Id == id).Select(s => new UserViewModel()
            {
                Id = s.Id,
                Usuario = s.UserName,
                Email = s.Email,
                Activo = s.Activo

            }).FirstOrDefault();

            _usuarioManager.RellenarRolesUsuario(usuario, usuario.Id);

            return View(usuario);
        }


        
    }
}