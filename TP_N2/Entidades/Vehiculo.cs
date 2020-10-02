using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region "Atributos"
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor de Vehiculos
        /// </summary>
        /// <param name="chasis">Es el chasis del vehiculo</param>
        /// <param name="marca">Es la Marca del Vehiculo</param>
        /// <param name="color">Es el color del vehiculo</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        #endregion

        #region "Propiedades"       
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get; }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region "Sobrecargas"
        public static explicit operator string(Vehiculo vehiculo)
        {
            StringBuilder returnAux = new StringBuilder();

            returnAux.AppendFormat("CHASIS: {0}\r\n", vehiculo.chasis);
            returnAux.AppendFormat("MARCA : {0}\r\n", vehiculo.marca.ToString());
            returnAux.AppendFormat("COLOR : {0}\r\n", vehiculo.color.ToString());
            returnAux.AppendFormat("---------------------");

            return returnAux.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="vehiculo1"></param>
        /// <param name="vehiculo2"></param>
        /// <returns>True si ambos vehiculos son iguales, caso contrario False</returns>
        public static bool operator ==(Vehiculo vehiculo1, Vehiculo vehiculo2)
        {
            return (vehiculo1.chasis == vehiculo2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="vehiculo1"></param>
        /// <param name="vehiculo2"></param>
        /// <returns>True si ambos vehiculos son distintos, caso contrario False</returns>
        public static bool operator !=(Vehiculo vehiculo1, Vehiculo vehiculo2)
        {
            return !(vehiculo1.chasis == vehiculo2.chasis);
        }
        #endregion
    }
}
