using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using utilidades.DAL.Repositorio;

namespace utilidades.DAL.Configuraciones
{
    public class ArticuloConfiguracion : EntityTypeConfiguration<Articulo>
    {
        public ArticuloConfiguracion()
        {
            

            HasKey(k => k.Id);

            Property(p => p.Titulo).IsRequired().HasMaxLength(ConstantesGeneralesConfiguracion.TAMAÑO_CADENA_GRANDE);

            Property(p => p.TipoId).IsRequired();

            HasRequired(hr => hr.Tipo).WithMany(wm => wm.Articulos).HasForeignKey(fk => fk.TipoId).WillCascadeOnDelete(false);

            HasMany(hm => hm.Tags).WithMany(wm => wm.Articulos)
                                  .Map(m => { m.ToTable("TagsArticulo"); 
                                              m.MapLeftKey("ArticuloId"); 
                                              m.MapRightKey("TagId"); 
                                             }
                                       );

        }
    }
}
