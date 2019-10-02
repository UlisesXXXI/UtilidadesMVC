using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilidades.DAL.Repositorio;

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
