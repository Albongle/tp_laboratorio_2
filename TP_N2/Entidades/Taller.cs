using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public class Taller
    {
        #region "Atributos"
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Es el constructor privado de Taller, donde se inicilizara la lista de vehiculos
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        /// <summary>
        /// Es el constructor que recibira el espacio disponible para el taller
        /// </summary>
        /// <param name="espacioDisponible">Cantidad de vehiculos que podra almacenar el taller</param>
        public Taller(int espacioDisponible) : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>Una cadena con le informacion del taller y sus vehiculos</returns>
        public static string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder returnAux = new StringBuilder();

            returnAux.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            returnAux.AppendLine("");
            foreach (Vehiculo vehiculo in taller.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Ciclomotor:
                        {
                            if (vehiculo is Ciclomotor)
                            {
                                returnAux.AppendLine(vehiculo.Mostrar());
                            }
                            break;
                        }
                    case ETipo.Sedan:
                        {
                            if (vehiculo is Sedan)
                            {
                                returnAux.AppendLine(vehiculo.Mostrar());
                            }
                            break;
                        }
                    case ETipo.SUV:
                        {
                            if (vehiculo is Suv)
                            {
                                returnAux.AppendLine(vehiculo.Mostrar());
                            }
                            break;
                        }
                    default:
                        {
                            returnAux.AppendLine(vehiculo.Mostrar());
                            break;
                        }
                }
            }
            return returnAux.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un vehiculo a la lista, en caso que exista espacio y este aun no se encuentre en dicho taller
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns>Taller con un nuevo vehiculo</returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            int flag = 0;
            if (taller.vehiculos.Count < taller.espacioDisponible)
            {
                foreach (Vehiculo vehiculoAux in taller.vehiculos)
                {
                    if (vehiculoAux == vehiculo)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    taller.vehiculos.Add(vehiculo);
                }
            }
            return taller;
        }
        /// <summary>
        /// Quitará un elemento de la lista en caso de que exista en ella
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns>Taller sin el elemento</returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo vehiculoAux in taller.vehiculos)
            {
                if (vehiculoAux == vehiculo)
                {
                    taller.vehiculos.Remove(vehiculo);
                    break;
                }
            }
            return taller;
        }
        #endregion
    }
}
