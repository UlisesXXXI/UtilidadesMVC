using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Unity;
using utilidades.BLL;
using utilidades.DAL.UsuarioYRoles;
using Utilidades.Infraestructura.Helpers.Controllers;
using Utilidades.Infraestructura.Managers.Imp;
using Utilidades.Infraestructura.Managers.Inter;
using Utilidades.ViewModels.Usuarios;

namespace Utilidades.Areas.Admin.Controllers
{
    [Authorize(Roles = Infraestructura.Constantes.Roles.ADMINISTRADOR)]
    public class UsuariosController : BaseController
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
                                                                            Usuario = s.UserName,
                                                                            Email = s.Email,
                                                                            Nombre = s.Nombre,
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


        [HttpGet]
        public ActionResult Create()
        {
            var vm = _usuarioManager.RellenarNuevoUsuario();

            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Create(NuevoUsuarioViewModel usuVm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser newUser = new ApplicationUser()
                {
                    Activo = usuVm.Activo,
                    UserName = usuVm.Usuario,
                    Email = usuVm.Email,
                    Nombre = usuVm.Nombre,
                };


                var resultado = await _userService.CreateAsync(newUser, usuVm.Password);

                if (resultado.Succeeded)
                {
                    var usuarioB = await _userService.FindByNameAsync(usuVm.Usuario);

                    var role = usuVm.RolesAsignados.First();

                    await _userService.AddToRoleAsync(usuarioB.Id, role);

                    AddMessage("Usuario Creado correctamente", MessageType.Normal);

                    return RedirectToAction("Edit","Usuarios", new {id = usuarioB.Id });
                }
            }

            AddMessage("Hay datos no correctos", MessageType.Error);

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
                Activo = s.Activo,
                Nombre = s.Nombre

            }).FirstOrDefault();

            _usuarioManager.RellenarRolesUsuario(usuario, usuario.Id);

            return View(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserViewModel user)
        {

            if (ModelState.IsValid)
            {
                
                var usuarioB = await _userService.FindByIdAsync(user.Id);

                if (usuarioB == null) return HttpNotFound();

                usuarioB.Email = user.Email;

                usuarioB.Activo = user.Activo;

                usuarioB.Nombre = user.Nombre;

                var rolesAsignados = usuarioB.Roles.Select(s => s.RoleId).ToList();

                var roles = _roleService.Roles.Where(w =>rolesAsignados.Contains(w.Id)).Select(s => s.Name).ToList();

                await _userService.UpdateAsync(usuarioB);

                await _userService.RemoveFromRolesAsync(usuarioB.Id, roles.ToArray());

                string nuevoRol = user.RolesAsignados.First();

                var r = await _userService.AddToRoleAsync(usuarioB.Id,nuevoRol);

                AddMessage("Usuario Creado correctamente", MessageType.Normal);

                return RedirectToAction("Edit", "Usuarios", new { id = usuarioB.Id });
            }

            AddMessage("Hay datos no correctos", MessageType.Error);

            _usuarioManager.RellenarRolesUsuario(user, user.Id);

            return View(user);
        }




    }
}