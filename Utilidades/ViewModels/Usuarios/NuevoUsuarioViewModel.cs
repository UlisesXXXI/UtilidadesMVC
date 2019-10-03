using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using utilidades.DAL.UsuarioYRoles;

namespace Utilidades.ViewModels.Usuarios
{
    public class NuevoUsuarioViewModel:IRolesUsuario
    {


        public NuevoUsuarioViewModel()
        {

            
            
            Activo = true;

            RolesAsignados = new List<string>() { Infraestructura.Constantes.Roles.EDITOR };

            TodosLosRoles = new List<String>();
        }

        [Required]
        public string Usuario { get; set; }

        [Required]
        [DataType(dataType: DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(utilidades.DAL.Configuraciones.ConstantesGeneralesConfiguracion.TAMAÑO_CADENA_MEDIANO)]
        public string Nombre { get; set; }

        public bool Activo { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        [Required]
        public string RePassword { get; set; }

        public IEnumerable<string> RolesAsignados { get; set; }

        
        public IEnumerable<string> TodosLosRoles { get; set; }
       
    }
}