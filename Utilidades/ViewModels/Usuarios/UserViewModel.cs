using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RECURSOS = Infraestructura.recursos;

namespace Utilidades.ViewModels.Usuarios
{
    public class UserViewModel:IRolesUsuario
    {

            public UserViewModel()
            {
                TodosLosRoles = new List<string>();

                RolesAsignados = new List<string>();
            }

            public string Id { get; set; }

            [Required]
            public string Usuario { get; set; }

            [Required]
            [DataType(dataType: DataType.EmailAddress)]
            public string Email { get; set; }

            [StringLength(utilidades.DAL.Configuraciones.ConstantesGeneralesConfiguracion.TAMAÑO_CADENA_MEDIANO)]
            public string Nombre { get; set; }


            public bool Activo { get; set; }


            public IEnumerable<string> RolesAsignados { get; set; }


            public IEnumerable<string> TodosLosRoles { get; set; }
        
    }
}