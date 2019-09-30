using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utilidades.DAL.UsuarioYRoles
{
    public class ApplicationRole: IdentityRole
    {
        public bool Activo { get; set; }
    }
}
