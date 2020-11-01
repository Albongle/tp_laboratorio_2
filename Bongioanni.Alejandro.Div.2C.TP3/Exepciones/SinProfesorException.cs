using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exepciones
{
    public class SinProfesorException:Exception
    {
        private static string mensajeDefault;
        /// <summary>
        /// Constructor estatico para inicializar mensaje Default
        /// </summary>
        static SinProfesorException()
        {
            mensajeDefault = "No hay Profesor para la clase";
        }
        /// <summary>
        /// Constructor sin paramatros, asigna un mensaje de error por defecto
        /// </summary>
        public SinProfesorException()
            :this(SinProfesorException.mensajeDefault)
        {
        }
        /// <summary>
        /// Constructor con posibilidad de enviar un mensaje de excepcion
        /// </summary>
        /// <param name="mensaje">Es el mensaje de excepcion que se va a asignar</param>
        public SinProfesorException(string mensaje)
            :base(mensaje)
        {

        }
    }
}
