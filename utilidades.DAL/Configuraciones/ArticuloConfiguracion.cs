using Infraestructura.comun.Configuraciones;
using System.Data.Entity.ModelConfiguration;
using utilidades.Entities.Repositorio;

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
