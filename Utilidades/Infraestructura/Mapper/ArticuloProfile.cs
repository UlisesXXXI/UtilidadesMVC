using AutoMapper;
using utilidades.Entities.Repositorio;
using Utilidades.ViewModels.Articulo;

namespace Utilidades.Infraestructura.Mapper
{
    public class ArticuloProfile:Profile
    {
        public ArticuloProfile()
        {
            CreateMap<Articulo, ArticuloViewModel>();

            CreateMap<ArticuloViewModel, Articulo>();
        }
    }
}