using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesVehiculos;
using ClasesExcepciones;
using System.Xml.Serialization;

namespace ClasesVehiculos
{
    [Serializable]
    public sealed class Camioneta : Vehiculo
    {
        #region "Atributos"
        private static float valorHora;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor de clase que establece el valor de la hora por defecto para Camioneta
        /// </summary>
        static Camioneta()
        {
            valorHora = 97;
        }
        /// <summary>
        /// Constructor por defecto para Camioneta
        /// </summary>
        public Camioneta()
        {

        }
        /// <summary>
        /// Constructor con parametros para Camioneta
        /// </summary>
        /// <param name="patente">Es la patente del Camioneta</param>
        /// <param name="horaIngreso">Es la hora de ingreso del Camioneta</param>
        public Camioneta(string patente, DateTime horaIngreso)
            : base(patente, horaIngreso)
        {

        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Establece y devuelve como texto el Valor de la Hora para Camioneta
        /// </summary>
        /// <exception cref="ImporteHoraException"></exception>
        public static string ValorHora
        {
            set
            {
                Camioneta.valorHora = Camioneta.ValidaValorHora(value);
            }
            get
            {
                return Camioneta.valorHora.ToString();
            }
        }
        /// <summary>
        /// Devuelve el Tipo de Vehiculo, por defecto sera Camioneta
        /// </summary>
        public override Automovil.ETipo TipoVehiculo { get { return Automovil.ETipo.Camioneta; } }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Verifica que el importe recibido sea un numero positivo mayor a 0
        /// </summary>
        /// <param name="valor">Es el valor enviado como cadena de texto</param>
        /// <returns>El importe recibido</returns>
        /// <exception cref="ImporteHoraException"></exception>
        private static float ValidaValorHora(string valor)
        {
            float returnAux = 0;

            if (!string.IsNullOrEmpty(valor) && float.TryParse(valor, out returnAux))
            {
                if (returnAux < 0)
                {
                    throw new ImporteHoraException("El valor de la hora no puede ser negativo");
                }
            }
            else
            {
                throw new ImporteHoraException("Error, valor invalido");
            }
            return returnAux;
        }
        /// <summary>
        /// Sobreesctirura del metodo cargo de estacionamiento, multiplica el valor de la hora para Camioneta por la cantidad de horas
        /// </summary>
        /// <returns>El cargo de horas para Automovil</returns>
        public override double CargoDeEstacionamiento()
        {
            return base.CargoDeEstacionamiento() * Camioneta.valorHora;
        }
        #endregion
    }
}
