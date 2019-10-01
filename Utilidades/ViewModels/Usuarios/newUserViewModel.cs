using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Utilidades.ViewModels.Usuarios
{
    public class newUserViewModel:IRolesUsuario
    {
        

        [Required]
        
        public string Usuario { get; set; }

        [Required]
        [DataType(dataType: DataType.EmailAddress)]
       
        public string Email { get; set; }

      
        public bool Activo { get; set; }

        [DataType(DataType.Password)]
       
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }

        public IEnumerable<string> RolesAsignados { get; set; }

        
        public IEnumerable<string> TodosLosRoles { get; set; }
       
    }
}