using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.comun.Filtro
{
    public enum Orden
    {
        ASC,
        DESC
    }

    public abstract class FiltroPaginadoBase 
    {

        #region Constantes

        private const int PAGINA_POR_DEFECTO = 1;

        private const Orden ORDEN_POR_DEFECTO = Orden.ASC;

        #endregion

        #region Privados

        private Orden _orden;

        private int _pagina;

        #endregion

        #region Constructor
        public FiltroPaginadoBase()
        {
            _pagina = PAGINA_POR_DEFECTO;

            Orden = Orden.ASC;


        }
        #endregion

        #region Propiedades

        public int Pagina
        {

            get
            {
                if (_pagina <= 0)
                    return PAGINA_POR_DEFECTO;
                return _pagina;
            }
            set
            {
                _pagina = value;
            }
        }

        public Orden Orden { get; set; }

        public string CampoOrden { get; set; }

        #endregion








    }
}
