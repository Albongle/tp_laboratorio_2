using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClasesInstanciables
{
    public sealed class Profesor:Universitario
    {
        #region "Atributos"
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor estatico que iniciliza el atributo Random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// Constructor sin paramatros para Profesor
        /// </summary>
        public Profesor()
        {
            
        }
        /// <summary>
        /// Constructor de Profesor
        /// </summary>
        /// <param name="id">Es el legajo del Profesor</param>
        /// <param name="nombre">Es el nombre del Profesor</param>
        /// <param name="apellido">Es el apellido del Profesor</param>
        /// <param name="dni">Es el DNI del Profesor</param>
        /// <param name="nacionalidad">Es la nacionalidad del Profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Metodo que realiza un random para asignara 2 clases al azar al Profesor
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 3));
            Thread.Sleep(3000);
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 3));
        }
        /// <summary>
        /// Muestra la participacion en clase para Profesor
        /// </summary>
        /// <returns>Una cadena con las clases que dal el Profesor</returns>
        protected override string ParticipacionEnClase()
        {
            StringBuilder returnAux = new StringBuilder();
            returnAux.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                returnAux.AppendLine(clase.ToString());
            }
            return returnAux.ToString();
        }
        /// <summary>
        /// Metodo sobrescrito que muestra los datos del Profesor
        /// </summary>
        /// <returns>Una cadena con los datos del Profesor y la Participacion en Clase</returns>
        protected override string MostrarDatos()
        {
            StringBuilder returnAux = new StringBuilder();
            returnAux.AppendLine($"{base.MostrarDatos()}");
            returnAux.AppendLine($"{this.ParticipacionEnClase()}");
            return returnAux.ToString();
        }
        /// <summary>
        /// Sobre escritura del metodo ToString, que hace publico los datos del Profesor
        /// </summary>
        /// <returns>Los datos del Profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region "SobreCargas"
        /// <summary>
        /// Verifica si un profesor tiene asignada dicha clase
        /// </summary>
        /// <param name="p">Es el Profesor a comparar</param>
        /// <param name="clase">Es la clase a comparar con el profesor</param>
        /// <returns>True en caso Exitoso, de lo contrario False</returns>
        public static bool operator ==(Profesor p, Universidad.EClases clase)
        {
            bool returnAux = false;
            foreach (Universidad.EClases c in p.clasesDelDia)
            {
                if(c==clase)
                {
                    returnAux = true;
                    break;
                }
            }
            return returnAux;
        }
        /// <summary>
        /// Verifica si un profesor NO tiene asignada dicha clase
        /// </summary>
        /// <param name="p">Es el Profesor a comparar</param>
        /// <param name="clase">Es la clase a comparar con el profesor</param>
        /// <returns>True en caso Exitoso, de lo contrario False</returns>
        public static bool operator !=(Profesor p, Universidad.EClases clase)
        {
            return !(p == clase);
        }
        #endregion

    }
}
