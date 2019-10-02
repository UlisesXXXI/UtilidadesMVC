using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utilidades.infraestructura.Comun
{
    public class AppError
    {
        public string Id { get; set; }

        public string MessageError { get; set; }

        public string Trace { get; set; }
    }
}