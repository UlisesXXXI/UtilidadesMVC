using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilidades.DAL.UsuarioYRoles;

namespace utilidades.DAL.dbContext
{
    public class UtilidadesDbContext:IdentityDbContext<ApplicationUser,ApplicationRole,string,IdentityUserLogin,IdentityUserRole,IdentityUserClaim>
    {
        public UtilidadesDbContext()
            : base("DefaultConnection")
        {

        }
    }
}
