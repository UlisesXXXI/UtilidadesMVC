using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace utilidades.Entities.UsuarioYRoles
{
    using utilidades.Entities.Comun;

    public class ApplicationUser:  IdentityUser,IActivo,ISistema
    {
      

        public ApplicationUser()
        {

        }

        [MaxLength(Infraestructura.comun.Configuraciones.ConstantesGeneralesConfiguracion.TAMAÑO_CADENA_MEDIANO)]
        public string Nombre { get; set; }

        public bool Activo { get; set; }

        public bool Sistema { get; set; }

        public byte[] Imagen { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser,string> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
