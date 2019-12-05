using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.Entities.Constantes;

namespace Utilidades.Entities.Parametros
{

    public class Parametro
    {
        public string Id { get; set; }

        public TiposParametro Tipo { get; set; }

        public string Valor { get; set; }
    }
}
