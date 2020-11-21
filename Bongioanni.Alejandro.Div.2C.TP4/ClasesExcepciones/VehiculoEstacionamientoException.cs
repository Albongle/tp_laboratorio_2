using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesExcepciones
{
    public class VehiculoEstacionamientoException : Exception
    {
        /// <summary>
        /// Constructor de Excepcion para VehiculoEstacionamientoException, que recibe un menssaje
        /// </summary>
        /// <param name="mensaje">Es el mensaje de la excepcion</param>
        public VehiculoEstacionamientoException(string mensaje)
            :base(mensaje)
        {

        }
        /// <summary>
        /// Constructor de Excepcion VehiculoEstacionamientoException 
        /// </summary>
        /// <param name="mensaje">Es el mensaje de la excepcion</param>
        /// <param name="innerException">Es la Excepcion a cargar en el InnerException</param>
        public VehiculoEstacionamientoException(string mensaje, Exception innerException)
            :base(mensaje, innerException)
        {

        }
    }
}
