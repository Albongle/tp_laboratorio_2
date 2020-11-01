using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region "Atributos"
        private int legajo;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor sin parametros para Universitario
        /// </summary>
        public Universitario()
        {

        }
        /// <summary>
        /// Constructor con parametros para Universitario
        /// </summary>
        /// <param name="legajo">Es el legajo del Universitario</param>
        /// <param name="nombre">Es el nombre de la Persona</param>
        /// <param name="apellido">Es el Apellido de la Persona</param>
        /// <param name="dni">Es el DNI de la Persona</param>
        /// <param name="nacionalidad">Es la Nacionalidad de la Persona</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Metodo que retorna los datos del Universitario
        /// </summary>
        /// <returns>Los datos del universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder returnAux = new StringBuilder();
            returnAux.AppendLine(base.ToString());
            returnAux.AppendLine($"Legajo: {this.legajo}");
            return returnAux.ToString();
        }
        /// <summary>
        /// Metodo abstracto y protegido, mostrara la participacion en clase para Profesor y Alumno
        /// </summary>
        /// <returns>La cadena "TOMA CLASE DE " junto al nombre de la clase que toma</returns>
        protected abstract string ParticipacionEnClase();
        /// <summary>
        /// Verifica que dos objetos sean del mismo tipo
        /// </summary>
        /// <param name="obj">Es el objeto a comparar</param>
        /// <returns>True en caso exitoso, False de lo contrario</returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }
        #endregion

        #region "SobreCargas"
        /// <summary>
        /// Compara que 2 Universitarios sean iguales, segun su Tipo, Legajo o DNI
        /// </summary>
        /// <param name="uni1">Es uno de los Universitarios a comparar</param>
        /// <param name="uni2">Es uno de los Universitarios a comparar</param>
        /// <returns>True en caso exitoso, False de lo contrario</returns>
        public static bool operator ==(Universitario uni1, Universitario uni2)
        {
            return uni1.Equals(uni2) && (uni1.legajo == uni2.legajo || uni1.DNI == uni2.DNI);
        }
        /// <summary>
        /// Compara que 2 Universitarios sean distintos, segun su Tipo, Legajo o DNI
        /// </summary>
        /// <param name="uni1">Es uno de los Universitarios a comparar</param>
        /// <param name="uni2">Es uno de los Universitarios a comparar</param>
        /// <returns>True en caso exitoso, False de lo contrario</returns>
        public static bool operator !=(Universitario uni1, Universitario uni2)
        {
            return !(uni1 == uni2);
        }
        #endregion

    }
}
