using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using utilidades.DAL.Configuraciones;
using utilidades.Entities.Repositorio;
using utilidades.Entities.UsuarioYRoles;

namespace utilidades.DAL.dbContext
{
    public class UtilidadesDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public UtilidadesDbContext()
            : base("DefaultConnection")
        {
            
            ConfiguracionDBContext();

            Database.Log = EscribirLog;

        }

        private void EscribirLog(string msg)
        {
            Debug.WriteLine(msg);
        }

        private void ConfiguracionDBContext()
        {
            this.Configuration.LazyLoadingEnabled = false;

            this.Configuration.AutoDetectChangesEnabled = false;

            this.Configuration.ValidateOnSaveEnabled = false;

            this.Configuration.ProxyCreationEnabled = false;
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
