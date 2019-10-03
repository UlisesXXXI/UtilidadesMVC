using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Utilidades.ViewModels.Usuarios
{
    public class LoginUsuarioViewModel
    {
        [Required]
        public string Usuario { get; set; }
        
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}