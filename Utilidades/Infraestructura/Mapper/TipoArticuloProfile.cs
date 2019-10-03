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
        }
    }
}