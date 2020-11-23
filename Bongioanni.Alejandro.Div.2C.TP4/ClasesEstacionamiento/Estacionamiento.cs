using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesVehiculos;
using ClasesExcepciones;

namespace ClasesEstacionamiento
{

    public class Estacionamiento<TVehiculo> where TVehiculo:Vehiculo
    {
        #region "Atributos"
        private int espacioDisponible;
        private string nombre;
        private List<TVehiculo> vehiculos;
        private static Estacionamiento<TVehiculo> singleton;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor privado de Estacionamiento
        /// </summary>
        private Estacionamiento()
        {
            this.vehiculos = new List<TVehiculo>();
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Propiedad estatica que devuelve una unica instancia de Estacionamiento
        /// </summary>
        public static Estacionamiento<TVehiculo> NuevoEstacionamiento
        {
            get
            {
                if (object.ReferenceEquals(singleton, null))
                {
                    singleton = new Estacionamiento<TVehiculo>();
                }
                return singleton;
            }
        }
        /// <summary>
        /// Establece y devuelve la capacidad del estacionamiento
        /// </summary>
        public int CapacidadEstacionamiento
        {
            get
            {
                return this.espacioDisponible;
            }
            set
            {
                if (value > 0)
                {
                    this.espacioDisponible = value;
                }
                else
                {
                    this.espacioDisponible = 0;
                }
            }
        }
        /// <summary>
        /// Establece y deveuelve un nombre para el Estacionamiento
        /// </summary>
        public string NombreEstacionamiento { get { return this.nombre; } set { this.nombre = value; } }
        /// <summary>
        /// Devuelve la lista de Vehiculos del Estacionamiento
        /// </summary>
        public List<TVehiculo> ListadoVehiculos
        {
            get
            {
                return this.vehiculos;
            }
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agrega un nuevo vehiculo al estacionamiento
        /// </summary>
        /// <param name="estacionamiento">Es el estacionamiento donde se va a agregar el vehiculo</param>
        /// <param name="vehiculo">Es el vehiculo a agregar al estacionamiento</param>
        /// <returns>Los datos del vehiculo ingresado</returns>
        /// <exception cref="VehiculoEstacionamientoException">Si el vehiculo ya existe o no hay mas espacio en el estacionamiento</exception>
        public static string operator +(Estacionamiento<TVehiculo> estacionamiento, TVehiculo vehiculo)
        {
            if (estacionamiento != vehiculo && !string.IsNullOrEmpty(vehiculo.Patente) && estacionamiento.ListadoVehiculos.Count < estacionamiento.CapacidadEstacionamiento)
            {
                estacionamiento.ListadoVehiculos.Add(vehiculo);
                return estacionamiento.InformarIngreso(vehiculo);
            }
            else
            {
                throw new VehiculoEstacionamientoException("No se pudo agregar el Vehiculo");
            }

        }
        /// <summary>
        /// Retira un vehiculo del Estacionamiento
        /// </summary>
        /// <param name="estacionamiento">Es el estacionamiento de donde se va a retirar el vehiculo</param>
        /// <param name="vehiculo">Es ek vehiculo a retirar del estacionamiento</param>
        /// <returns>Los datos del vehiculo con su cargo por la Jornada</returns>
        /// <exception cref="VehiculoEstacionamientoException">Si el vehiculo no es parte del Estacionamiento o aun no se le establecio una hora de salida</exception>
        public static string operator -(Estacionamiento<TVehiculo> estacionamiento, TVehiculo vehiculo)
        {
            try
            {
                if (estacionamiento.ListadoVehiculos.Count > 0 && estacionamiento == vehiculo)
                {
                    estacionamiento.ListadoVehiculos.Remove(vehiculo);
                    return estacionamiento.InformarSalida(vehiculo);
                }
                else
                {
                    throw new VehiculoEstacionamientoException("El vehículo no es parte del estacionamiento");
                }
            }
            catch (HoraDeEgresoException ex)
            {
                throw new VehiculoEstacionamientoException("No se pudo retirar el vehiculo", ex);
            }
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Verifica si un vehiculo pertece al Estacionamiento
        /// </summary>
        /// <param name="estacionamiento">Es el estacionamiento donde se va bucar el vehiculo</param>
        /// <param name="vehiculo">Es el vehiculo a buscar en el estacionamiento</param>
        /// <returns>True en caso de pertenecer al estacionamiento, de lo contrario False</returns>
        public static bool operator ==(Estacionamiento<TVehiculo> estacionamiento, TVehiculo vehiculo)
        {
            bool returAux = false;
            if (estacionamiento.ListadoVehiculos.Count > 0)
            {
                foreach (Vehiculo v in estacionamiento.vehiculos)
                {
                    if (v == vehiculo)
                    {
                        returAux = true;
                        break;
                    }
                }
            }
            return returAux;
        }
        /// <summary>
        /// Verifica si un vehiculo NO pertece al Estacionamiento
        /// </summary>
        /// <param name="estacionamiento">Es el estacionamiento donde se va bucar el vehiculo</param>
        /// <param name="vehiculo">Es el vehiculo a buscar en el estacionamiento</param>
        /// <returns>True en caso de NO pertenecer al estacionamiento, de lo contrario False</returns>
        public static bool operator !=(Estacionamiento<TVehiculo> estacionamiento, TVehiculo vehiculo)
        {
            return !(estacionamiento == vehiculo);
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Metodo privado para retornar los datos del vehiculo que ingresa
        /// </summary>
        /// <param name="vehiculo">Es el vehiculo que va a mostrar los datos</param>
        /// <returns>Los datos del vehiculo que ingreso al Estacionamiento</returns>
        private string InformarIngreso(TVehiculo vehiculo)
        {
            return vehiculo.ToString();
        }
        /// <summary>
        /// Metodo privado que adiciona la hora de salida y el cargo a los datos del Vehiculo
        /// </summary>
        /// <param name="vehiculo">Es el vehiculo que va a mostrar los datos</param>
        /// <returns>Los datos del vehiculo que se retira del estacionamiento</returns>
        private string InformarSalida(TVehiculo vehiculo)
        {
            StringBuilder returnAux = new StringBuilder();
            returnAux.AppendLine(vehiculo.ToString());
            returnAux.AppendLine($"Hora de salida: {vehiculo.HoraEgreso}");
            returnAux.AppendLine($"El cargo por estacionamiento es: {vehiculo.CargoDeEstacionamiento()}");
            return returnAux.ToString();
        }
        #endregion
    }
}
