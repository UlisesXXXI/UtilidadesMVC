using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilidades.DAL.UsuarioYRoles;
using utilidades.DAL.Repositorio;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using utilidades.DAL.Configuraciones;


namespace utilidades.DAL.dbContext
{
    public class UtilidadesDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public UtilidadesDbContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        #region DbSet's

        public DbSet<Articulo> Articulos { get; set; }

        public DbSet<Tipo> Tipos { get; set; }

        public DbSet<Tag> Tags { get; set; }

        #endregion


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            QuitarPonerConvenciones(modelBuilder);

            ConfiguracionEntidades(modelBuilder);
        }


        public void QuitarPonerConvenciones(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public void ConfiguracionEntidades(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ArticuloConfiguracion());
            modelBuilder.Configurations.Add(new TagsConfiguracion());
            modelBuilder.Configurations.Add(new TipoConfiguracion());
        }

    }
       
}
