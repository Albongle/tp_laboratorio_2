using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ClasesExcepciones;

namespace ClasesVehiculos
{
    [Serializable]
    [XmlInclude(typeof(Automovil)), XmlInclude(typeof(Moto)), XmlInclude(typeof(Camioneta))]
    public abstract class Vehiculo
    {
        #region "Atributos"
        private DateTime horaIngreso;
        private DateTime horaEgreso;
        public enum ETipo { Auto, Camioneta, Moto };
        private string patente;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor por defecto para Vehiculo
        /// </summary>
        public Vehiculo()
        {

        }
        /// <summary>
        /// Constructor con parametros para Vehiculos
        /// </summary>
        /// <param name="patente">Es la patente del vehiculo</param>
        /// <param name="horaIngreso">Es la hora en la que ingresa el vehiculo</param>
        protected Vehiculo(string patente, DateTime horaIngreso)
        {
            this.horaIngreso = horaIngreso;
            this.Patente = patente;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Establece y devuelve la patente del vehiculo
        /// </summary>
        /// <exception cref="PatenteException"></exception>
        public string Patente
        {
            get
            {
                return this.patente;
            }
            set
            {
                if (this.ValidarPatente(value))
                {
                    this.patente = value;
                }
                else
                {
                    throw new PatenteException();
                }
            }
        }
        /// <summary>
        /// Devuelve el tipo de Vehiculo "Automovil, Camioneta o Moto"
        /// </summary>
        public abstract ETipo TipoVehiculo { get; }
        /// <summary>
        /// Estableces y devuelve la hora de ingreso del Vehiculo
        /// </summary>
        public DateTime HoraIngreso { get { return this.horaIngreso; } set { this.horaIngreso = value; } }
        /// <summary>
        /// Esteblece y devuelve la hora de egreso del vehiculo. Esta no puede ser menor a la de ingreso
        /// </summary>
        /// <exception cref="HoraDeEgresoException"></exception>
        public DateTime HoraEgreso
        {
            get
            {
                return this.horaEgreso;
            }
            set
            {
                if (value > this.HoraIngreso)
                {
                    this.horaEgreso = value;
                }
                else
                {
                    throw new HoraDeEgresoException("La hora de Egreso no puede ser menor a la de Ingreso");
                }
            }
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Metodo privado que validara que la patente recibida sea correcta.
        /// Esta solo debe poseer solamente numeros, letras. Siendo la cantidad de caracteres en 6 y 7
        /// </summary>
        /// <param name="patente">Es la patente a validar</param>
        /// <returns>True en caso de una patente valida, de lo contrario False</returns>
        private bool ValidarPatente(string patente)
        {
            bool returnAux = false;
            if (!string.IsNullOrEmpty(patente) && patente.Length >= 6 && patente.Length < 8)
            {
                foreach (char caracter in patente)
                {
                    if (!char.IsNumber(caracter) && !char.IsLetter(caracter))
                    {
                        return returnAux;
                    }
                }
                returnAux = true;
            }
            return returnAux;
        }
        /// <summary>
        /// Metodo virtual usado para aplicar un cargo de estacionamiento para los vehiculos.
        /// </summary>
        /// <returns>La cantidad de horas generadas por el vehiculo</returns>
        public virtual double CargoDeEstacionamiento()
        {
            if (this.HoraEgreso > this.HoraIngreso)
            {
                double horasDiasAcumulados = (this.HoraEgreso - this.HoraIngreso).TotalHours;
                return horasDiasAcumulados;
            }
            else
            {
                throw new HoraDeEgresoException("Debe ingresar una hora de salida");
            }

        }
        /// <summary>
        /// Metodo protegido que muestra los datos del vehiculo
        /// </summary>
        /// <returns>Los datos del vehiculo</returns>
        protected string MostrarDatos()
        {
            StringBuilder returnAux = new StringBuilder();
            returnAux.AppendLine($"Tipo: {this.TipoVehiculo}, Ingreso: {this.HoraIngreso} ");
            returnAux.AppendLine($"Patente {this.Patente}");
            return returnAux.ToString();
        }
        /// <summary>
        /// Sobreesctirura del metodo ToString que hace publico los datos del vehiculo
        /// </summary>
        /// <returns>Los datos del vehiculo</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Dos vehiculos son iguales si su patente es igual
        /// </summary>
        /// <param name="v1">Es el primer vehiculo a comprar</param>
        /// <param name="v2">Es el segundo vehiculo a comparar</param>
        /// <returns>True si los vehiculos son iguales, de lo contrario False</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.Patente == v2.Patente);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su patente es distinta
        /// </summary>
        /// <param name="v1">Es el primer vehiculo a comprar</param>
        /// <param name="v2">Es el segundo vehiculo a comparar</param>
        /// <returns>True si los vehiculos son distintos, de lo contrario False</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        #endregion
    }
}