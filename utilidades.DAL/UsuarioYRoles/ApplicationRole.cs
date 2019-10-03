using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilidades.DAL.comun.inter;

namespace utilidades.DAL.UsuarioYRoles
{
    public class ApplicationRole: IdentityRole,IActivo,ISistema
    {

        public ApplicationRole()
        {

        }
        public bool Activo { get; set; }

        public bool Sistema { get; set; }
    }
}
