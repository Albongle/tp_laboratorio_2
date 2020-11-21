using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesExcepciones
{
    public class HoraDeEgresoException: Exception
    {
        /// <summary>
        /// Constructor de Excepcion para HoraDeEgresoException, tiene un mensasaje por defecto
        /// </summary>
        public HoraDeEgresoException(string mensaje) 
            :base(mensaje)
        {

        }
        /// <summary>
        /// Constructor de Excepcion para HoraDeEgresoException
        /// </summary>
        /// <param name="mensaje">Es el mensaje de la excepcion</param>
        /// <param name="innerException">Es la Excepcion a cargar en el InnerException</param>
        public HoraDeEgresoException(string mensaje, Exception innerException)
            :base(mensaje, innerException)
        {

        }
    }
}
