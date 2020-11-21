using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesExcepciones
{
    public class BaseDeDatosException : Exception
    {
        /// <summary>
        /// Constructor de Excepcion para BaseDeDatosException, tiene un mensasaje por defecto
        /// </summary>
        public BaseDeDatosException(string mensaje)
            : base(mensaje)
        {

        }
        /// <summary>
        /// Constructor de Excepcion para BaseDeDatosException
        /// </summary>
        /// <param name="mensaje">Es el mensaje de la excepcion</param>
        /// <param name="innerException">Es la Excepcion a cargar en el InnerException</param>
        public BaseDeDatosException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {

        }
    }
}
