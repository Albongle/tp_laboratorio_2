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
        private DateTime horaIngreso;
        private DateTime horaEgreso;
        public enum ETipo { Auto, Camioneta, Moto };
        private string patente;
        public Vehiculo()
        {

        }
        protected Vehiculo(string patente, DateTime horaIngreso)
        {
            this.horaIngreso = horaIngreso;
            this.Patente = patente;
        }

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
        public abstract ETipo TipoVehiculo { get; }
        public DateTime HoraIngreso { get { return this.horaIngreso; } set { this.horaIngreso = value; } }
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
        public virtual double CargoDeEstacionamiento()
        {
            if (this.HoraEgreso > this.HoraIngreso)
            {
                double horasDiasAcumulados = ((this.HoraEgreso - this.HoraIngreso).TotalDays) * 24;
                double horasDeldia = (this.HoraEgreso.TimeOfDay - this.HoraIngreso.TimeOfDay).TotalHours;
                return horasDeldia + horasDiasAcumulados;
            }
            else
            {
                throw new HoraDeEgresoException("Debe ingresar una hora de salida");
            }

        }
        protected string MostrarDatos()
        {
            StringBuilder returnAux = new StringBuilder();
            returnAux.AppendLine($"Tipo: {this.TipoVehiculo}, Ingreso: {this.HoraIngreso} ");
            returnAux.AppendLine($"Patente {this.Patente}");
            return returnAux.ToString();
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.Patente == v2.Patente);
        }
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
    }
}