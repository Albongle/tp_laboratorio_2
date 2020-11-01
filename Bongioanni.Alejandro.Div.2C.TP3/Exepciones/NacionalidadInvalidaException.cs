using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        private static string mensajeDefault;
        /// <summary>
        /// Constructor estatico para inicializar mensaje Default
        /// </summary>
        static NacionalidadInvalidaException()
        {
            mensajeDefault = "La nacionalidad no se condice con el numero de DNI";
        }
        /// <summary>
        /// Constructor sin paramatros, asigna un mensaje de error por defecto
        /// </summary>
        public NacionalidadInvalidaException()
            :this(NacionalidadInvalidaException.mensajeDefault)
        {
        }
        /// <summary>
        /// Constructor con posibilidad de enviar un mensaje de excepcion
        /// </summary>
        /// <param name="mensaje">Es el mensaje de excepcion que se va a asignar</param>
        public NacionalidadInvalidaException(string mensaje)
            :base(mensaje)
        {

        }
    }
}
