using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using utilidades.Entities.UsuarioYRoles;

namespace utilidades.BLL
{
    public class SignInService : SignInManager<ApplicationUser,string>
    {
        public SignInService(UserService userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return  user.GenerateUserIdentityAsync((UserService)UserManager);
        }

        public static SignInService Create(IdentityFactoryOptions<UserService> options, IOwinContext context)
        {
            return new SignInService(context.GetUserManager<UserService>(), context.Authentication);
        }
    }
}
