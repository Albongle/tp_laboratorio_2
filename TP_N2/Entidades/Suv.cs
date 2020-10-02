using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        #region "Constructores"
        /// <summary>
        /// Constructor de SUV
        /// </summary>
        /// <param name="marca">Es la marca del SUV</param>
        /// <param name="chasis">Es el chasis del SUV</param>
        /// <param name="color">Es el color del SUV</param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Devuelve el tamaño del SUV
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Sobreescribe el metodo heredado adicionando las propiedades de SUV
        /// </summary>
        /// <returns>Una cadena con le informacion del vehiculo</returns>
        public override sealed string Mostrar()
        {
            StringBuilder returnAux = new StringBuilder();

            returnAux.AppendLine("SUV");
            returnAux.AppendLine(base.Mostrar());
            returnAux.AppendFormat("TAMAÑO: {0}\n", this.Tamanio);
            returnAux.AppendLine("---------------------");

            return returnAux.ToString();
        }
        #endregion
    }
}
