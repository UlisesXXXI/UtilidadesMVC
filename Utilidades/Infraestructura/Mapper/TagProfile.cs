using AutoMapper;
using utilidades.Entities.Repositorio;
using Utilidades.ViewModels.Tag;

namespace Utilidades.Infraestructura.Mapper
{
    public class TagProfile: Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagViewModel>();

            CreateMap<TagViewModel,Tag>();
        }
    }
}