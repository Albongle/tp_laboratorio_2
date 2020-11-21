using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ClasesExcepciones;

namespace ClasesVehiculos
{
    [Serializable]
    public sealed class Automovil : Vehiculo
    {
        private static float valorHora;
        static Automovil()
        {
            valorHora = 57;
        }
        public Automovil()
        {

        }
        public Automovil(string patente, DateTime horaIngreso)
            : base(patente, horaIngreso)
        {

        }
        public static string ValorHora 
        {
            set
            {
                Automovil.valorHora = Automovil.ValidaValorHora(value);
            }
            get
            {
                return Automovil.valorHora.ToString();
            }
        }
        public override Automovil.ETipo TipoVehiculo { get { return Automovil.ETipo.Auto;} }

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

        public override double CargoDeEstacionamiento()
        {
            return base.CargoDeEstacionamiento()*Automovil.valorHora;
        }
    }
}
