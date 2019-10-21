using Infraestructura.comun.Configuraciones;
using System.Data.Entity.ModelConfiguration;
using utilidades.Entities.Repositorio;

namespace utilidades.DAL.Configuraciones
{
    public class TagsConfiguracion : EntityTypeConfiguration<Tag>
    {
        public TagsConfiguracion()
        {

            ToTable("Tags");

            HasKey(k => k.Id);

            Property(p => p.Descripcion).IsRequired().HasMaxLength(ConstantesGeneralesConfiguracion.TAMAÑO_CADENA_MEDIANO);

            HasMany(m => m.Articulos).WithMany(x => x.Tags);
        }
    }
}
