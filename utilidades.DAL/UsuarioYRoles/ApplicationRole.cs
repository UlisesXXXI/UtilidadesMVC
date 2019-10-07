using Microsoft.AspNet.Identity.EntityFramework;
using utilidades.DAL.comun;

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
