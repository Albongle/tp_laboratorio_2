using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exepciones
{
    public class AlumnoRepetidoException : Exception
    {
        private static string mensajeDefault;
        /// <summary>
        /// Constructor estatico para inicializar mensaje Default
        /// </summary>
        static AlumnoRepetidoException()
        {
            mensajeDefault = "Alumno repetido";
        }
        /// <summary>
        /// Constructor sin paramatros, asigna un mensaje de error por defecto
        /// </summary>
        public AlumnoRepetidoException()
            :this(AlumnoRepetidoException.mensajeDefault)
        {

        }
        /// <summary>
        /// Constructor con posibilidad de enviar un mensaje de excepcion
        /// </summary>
        /// <param name="mensaje">Es el mensaje de excepcion que se va a asignar</param>
        public AlumnoRepetidoException(string mensaje)
            :base(mensaje)
        {

        }
    }
}
