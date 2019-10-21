using Infraestructura.comun.Configuraciones;
using System.Data.Entity.ModelConfiguration;
using utilidades.Entities.Repositorio;

namespace utilidades.DAL.Configuraciones
{
    public class TipoConfiguracion : EntityTypeConfiguration<Tipo>
    {

        public TipoConfiguracion()
        {
            ToTable("Tipo");

            HasKey(k => k.Id);

            Property(p => p.Descripcion).IsRequired().HasMaxLength(ConstantesGeneralesConfiguracion.TAMAÑO_CADENA_MEDIANO);

            HasMany(p => p.Articulos).WithRequired(r => r.Tipo).WillCascadeOnDelete(false);
        }
    }
}
