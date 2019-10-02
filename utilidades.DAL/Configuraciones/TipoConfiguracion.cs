using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using utilidades.DAL.Repositorio;
using System.Data.Entity.ModelConfiguration;

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
