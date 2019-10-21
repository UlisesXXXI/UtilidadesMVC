using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utilidades.Infraestructura.Comun.Json
{

    public enum enumEstadoResultado
    {
        Ok = 0,
        Error = 1
    }

    public class ResultadoJson
    {

        private enumEstadoResultado _resultado;

        private List<String> _errores;

        public ResultadoJson()
        {
            _errores = new List<string>();

            Datos = new List<object>();

            _resultado = new enumEstadoResultado();

            _resultado = enumEstadoResultado.Ok;
        }

        public bool HayErrores { get { return _errores.Count() > 0; } }

        public List<String> Errores { get { return _errores; } }

        public bool HayRedireccion { get { return !String.IsNullOrEmpty(UrlRedireccion); }  }

        public string UrlRedireccion { get; set; }

        public int Resultado { get { return (int)(_resultado); }  }

        public List<Object> Datos { get; set; }


        #region Metodos

        public void AddErrores(string msgError)
        {
            if(_errores == null)
            {
                _errores = new List<string>();
            }

            _errores.Add(msgError);

            if(_resultado == enumEstadoResultado.Ok)
            {
                _resultado = enumEstadoResultado.Error;
            }
        }

        public void AsignarEstado(enumEstadoResultado estado)
        {
            _resultado = estado;
        }

        


        #endregion

    }
}