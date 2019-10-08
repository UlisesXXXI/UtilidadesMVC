using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using utilidades.DAL.Repositorio;
using Utilidades.ViewModels.TipoArticulo;

namespace Utilidades.Infraestructura.Mapper
{
    public class TipoArticuloProfile:Profile
    {
        public TipoArticuloProfile()
        {
            CreateMap<Tipo, TipoArticuloViewModel>();

            CreateMap<Tipo, NuevoTipoArticuloViewModel>().ForMember(dest => dest.Descripcion,
                                                                                opt => opt.MapFrom(src => src.Descripcion));

            CreateMap<TipoArticuloViewModel, Tipo>().ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                                                    .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore())
                                                    .ForMember(dest => dest.UsuarioCreacion, opt => opt.Ignore())
                                                    .ForMember(dest => dest.UsuarioModificacion, opt => opt.Ignore());
                                                    

            CreateMap<NuevoTipoArticuloViewModel,Tipo >().ForMember(dest => dest.Descripcion,
                                                                                opt => opt.MapFrom(src => src.Descripcion));
        }
    }
}