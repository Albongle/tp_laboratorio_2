using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesExcepciones;
using System.Xml.Serialization;

namespace ClasesVehiculos
{
    [Serializable]
    public sealed class Moto : Vehiculo
    {
        private static float valorHora;
        static Moto()
        {
            valorHora = 43;
        }
        public Moto()
        {

        }
        public Moto(string patente, DateTime horaIngreso)
            : base(patente, horaIngreso)
        {

        }
        public static string ValorHora
        {
            set
            {
                Moto.valorHora = Moto.ValidaValorHora(value);
            }
            get
            {
                return Moto.valorHora.ToString();
            }
        }
        public override Automovil.ETipo TipoVehiculo { get { return Automovil.ETipo.Moto; } }

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
            return base.CargoDeEstacionamiento() * Moto.valorHora;
        }
    }
}
