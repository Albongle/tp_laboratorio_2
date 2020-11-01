using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exepciones
{
    public class ArchivosException:Exception
    {
        private static string mensajeDefault;
        /// <summary>
        /// Constructor estatico para inicializar mensaje Default
        /// </summary>
        static ArchivosException ()
        {
            mensajeDefault = "Error en el Archivo";
        }
        /// <summary>
        /// Constructor sin paramatros, asigna un mensaje de error por defecto
        /// </summary>
        public ArchivosException()
            :this(ArchivosException.mensajeDefault)
        {

        }
        /// <summary>
        /// Constructor con posibilidad de enviar un mensaje de excepcion
        /// </summary>
        /// <param name="mensaje">Es el mensaje de excepcion que se va a asignar</param>
        public ArchivosException(string mensaje)
            :base(mensaje)
        {

        }
        /// <summary>
        /// Constructor con posibilidad de enviar una excepcion capturada
        /// </summary>
        /// <param name="innerException">Es la excepcion capturada al momento de la ejecucion</param>
        public ArchivosException(Exception innerException)
            :base(ArchivosException.mensajeDefault, innerException)
        {

        }
    }
}
