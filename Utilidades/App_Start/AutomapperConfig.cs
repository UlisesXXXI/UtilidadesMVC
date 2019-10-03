using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using utilidades.DAL.Repositorio;
using Utilidades.Infraestructura.Mapper;
using Utilidades.ViewModels.TipoArticulo;

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
                }
            );
        }
    }
}