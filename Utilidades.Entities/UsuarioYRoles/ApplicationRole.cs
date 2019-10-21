using Microsoft.AspNet.Identity.EntityFramework;
using utilidades.Entities.Comun;

namespace utilidades.Entities.UsuarioYRoles
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
