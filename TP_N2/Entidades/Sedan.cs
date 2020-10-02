using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        #region "Atributos"
        public enum ETipo { CuatroPuertas, CincoPuertas }
        private ETipo tipo;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor Sedan. Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : this(marca,chasis,color, ETipo.CuatroPuertas)
        {
            
        }
        /// <summary>
        /// Constructor Sedan con posibilidad de asignar TIPO
        /// </summary>
        /// <param name="marca">Es la marca del vehiculo</param>
        /// <param name="chasis">Es el chasis del vehiculo</param>
        /// <param name="color">Es el color del vehiculo</param>
        /// <param name="tipo">Es el tipo de Sedan</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Devuelve el tamaño de un Sedan
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Sobreescribe el metodo heredado adicionando las propiedades de Sedan
        /// </summary>
        /// <returns>Una cadena con le informacion del vehiculo</returns>
        public override sealed string Mostrar()
        {
            StringBuilder returnAux = new StringBuilder();

            returnAux.AppendLine("SEDAN");
            returnAux.AppendLine(base.Mostrar());
            returnAux.AppendFormat("TAMAÑO: {0}\n", this.Tamanio);
            returnAux.AppendLine("TIPO: " + this.tipo);
            returnAux.AppendLine("---------------------");

            return returnAux.ToString();
        }
        #endregion
    }
}
