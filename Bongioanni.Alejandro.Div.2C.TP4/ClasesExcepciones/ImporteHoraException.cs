using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesExcepciones
{
    public class ImporteHoraException : Exception
    {
        /// <summary>
        /// Constructor de Excepcion para ImporteValorHora, que recibe un menssaje
        /// </summary>
        /// <param name="mensaje">Es el mensaje de la excepcion</param>
        public ImporteHoraException(string mensaje) 
            :base(mensaje)
        {

        }
        /// <summary>
        /// Constructor de Excepcion ImporteValorHora
        /// </summary>
        /// <param name="mensaje">Es el mensaje de la excepcion</param>
        /// <param name="innerException">Es la Excepcion a cargar en el InnerException</param>
        public ImporteHoraException(string mensaje, Exception innerException)
            :base(mensaje, innerException)
        {

        }
    }
}
