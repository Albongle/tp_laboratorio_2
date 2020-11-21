using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesExcepciones
{
    public class ArchivoException : Exception
    {
        /// <summary>
        /// Constructor de Excepcion para ArchivoException, tiene un mensasaje por defecto
        /// </summary>
        public ArchivoException(string mensaje)
            : base(mensaje)
        {

        }
        /// <summary>
        /// Constructor de Excepcion para ArchivoException
        /// </summary>
        /// <param name="mensaje">Es el mensaje de la excepcion</param>
        /// <param name="innerException">Es la Excepcion a cargar en el InnerException</param>
        public ArchivoException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {

        }
    }
}
