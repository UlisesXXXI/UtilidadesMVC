using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using utilidades.DAL.dbContext;
using utilidades.Entities.UsuarioYRoles;

namespace utilidades.BLL
{
    public class RoleService: RoleManager<ApplicationRole>
    {
        public RoleService(IRoleStore<ApplicationRole,string> roleStore)
            : base(roleStore) { }

        public static RoleService Create(IdentityFactoryOptions<RoleService> options, IOwinContext context)
        {
            var manager = new RoleService(new RoleStore<ApplicationRole>(context.Get<UtilidadesDbContext>()));

            return manager;
        }
    }
}
