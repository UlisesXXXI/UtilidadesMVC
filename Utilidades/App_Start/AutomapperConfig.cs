using AutoMapper;
using Utilidades.Infraestructura.Mapper;

namespace Utilidades.App_Start
{
    public class AutomapperConfig
    {
        public static void Load()
        {
            Mapper.Initialize(
                cfg =>
                {
                    cfg.AddProfile(new TipoArticuloProfile());

                    cfg.AddProfile(new TagProfile());

                    cfg.AddProfile(new ArticuloProfile());

                }
            );
        }
    }
}