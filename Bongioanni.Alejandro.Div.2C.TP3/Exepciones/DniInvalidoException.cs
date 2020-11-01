using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exepciones
{
    public class DniInvalidoException : Exception
    {
        private static string mensajeDefault;
        /// <summary>
        /// Constructor estatico para inicializar mensaje Default
        /// </summary>
        static DniInvalidoException()
        {
            mensajeDefault = "DNI Invalido";
        }
        /// <summary>
        /// Constructor sin paramatros, asigna un mensaje de error por defecto
        /// </summary>
        public DniInvalidoException()
            :this(DniInvalidoException.mensajeDefault)
        {

        }
        /// <summary>
        /// Constructor con posibilidad de enviar una excepcion capturada
        /// </summary>
        /// <param name="innerException">Es la excepcion capturada al momento de la ejecucion</param>
        public DniInvalidoException(Exception innerException)
            :this(DniInvalidoException.mensajeDefault, innerException)
        {

        }
        /// <summary>
        /// Constructor con posibilidad de enviar un mensaje de excepcion
        /// </summary>
        /// <param name="mensaje">Es el mensaje de excepcion que se va a asignar</param>
        public DniInvalidoException (string mensaje)
            :base(mensaje)
        {

        }
        /// <summary>
        /// Constructor con posibilidad de enviar un mensaje y una excepcion capturada
        /// </summary>
        /// <param name="mensaje">Es el mensaje de excepcion que se va a asignar</param>
        /// <param name="innerException">Es la excepcion capturada al momento de la ejecucion</param>
        public DniInvalidoException (string mensaje, Exception innerException)
            :base(mensaje, innerException)
        {

        }
    }
}
