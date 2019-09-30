using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utilidades.DAL.dbContext
{
    public class UtilidadesDbContext:IdentityDbContext
    {
        public UtilidadesDbContext()
            : base("DefaultConnection")
        {

        }
    }
}
