using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.comun.Tareas
{
    public class Resultado
    {
        private EnumEstadoResultado _estado;

        private List<String> _errores;

        public EnumEstadoResultado Estado 
        { 
            get {
                return _estado;
            } 
        }

        public List<String> Errores 
        {
            get {
                return _errores;
            }
        }

        public string Mensaje { get; set; }

        public string UrlRedireccion { get; set; }

        public bool Redireccionar 
        { 
            get{
                return !String.IsNullOrEmpty(UrlRedireccion); 
            } 
        }

        public bool HayErrores
        {
            get
            {
                return (_errores != null && _errores.Count > 0); 
            }
        }

        public Resultado()
        {
            _estado = EnumEstadoResultado.Correcto;

            _errores = new List<string>();
        }

        protected void AniadirErrores(string msg){
            
            if(_errores == null)
            {
                _errores = new List<string>();
            }

            _errores.Add(msg);
        }

        public void AsignarEstado(EnumEstadoResultado estado)
        {
            _estado = estado;
        }

        
    }
}
