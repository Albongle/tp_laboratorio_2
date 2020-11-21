using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesExcepciones
{
    public class PatenteException : Exception
    {
        /// <summary>
        /// Constructor de Excepcion para patente, tiene un mensasaje por defecto
        /// </summary>
        public PatenteException()
            :base("Patente Invalida")
        {

        }
        /// <summary>
        /// Constructor de Excepcion para patente
        /// </summary>
        /// <param name="mensaje">Es el mensaje de la excepcion</param>
        /// <param name="innerException">Es la Excepcion a cargar en el InnerException</param>
        public PatenteException(string mensaje, Exception innerException)
            :base(mensaje,innerException)
        {

        }
    }
}
