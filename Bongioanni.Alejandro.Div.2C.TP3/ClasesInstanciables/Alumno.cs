using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;


namespace ClasesInstanciables
{
    public sealed class Alumno:Universitario
    {
        #region "Atributos"
        public enum EEstadoCuenta {AlDia, Deudor, Becado}
        private Universidad.EClases clasesQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor sin parametros para Alumno
        /// </summary>
        public Alumno()
        {

        }
        /// <summary>
        /// Constructor de Alumno
        /// </summary>
        /// <param name="id">Es el legajo del Alumno</param>
        /// <param name="nombre">Es el nombre del Alumnoi</param>
        /// <param name="apellido">Es el apellido del Alumno</param>
        /// <param name="dni">Es el DNI del Alumno</param>
        /// <param name="nacionalidad">Es la nacionalidad del Alumno</param>
        /// <param name="clasesQueToma">Es la clase que toma el Alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesQueToma = clasesQueToma;
        }
        /// <summary>
        /// Constructor de Alumno con estado de cuenta
        /// </summary>
        /// <param name="id">Es el legajo del Alumno</param>
        /// <param name="nombre">Es el nombre del Alumnoi</param>
        /// <param name="apellido">Es el apellido del Alumno</param>
        /// <param name="dni">Es el DNI del Alumno</param>
        /// <param name="nacionalidad">Es la nacionalidad del Alumno</param>
        /// <param name="estadoCuenta">Es el estado de la cuenta del Alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta)
            : this(id,nombre,apellido,dni,nacionalidad,clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Metodo sobrescrito que retorna los datos del Alumno
        /// </summary>
        /// <returns>Los datos del Alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder returnAux = new StringBuilder();
            returnAux.AppendLine(base.MostrarDatos());
            returnAux.AppendLine($"{this.ParticipacionEnClase()}");
            returnAux.AppendLine($"Estado de cuenta: {this.estadoCuenta}");
            return returnAux.ToString();
        }
        /// <summary>
        /// Muestra la participacion en clase para Alumno
        /// </summary>
        /// <returns>Una cadena con las clases que toma el Alumno</returns>
        protected override string ParticipacionEnClase()
        {
            StringBuilder returnAux = new StringBuilder();
            returnAux.AppendLine($"Toma Clase de {this.clasesQueToma}");
            return returnAux.ToString();
        }
        /// <summary>
        /// Sobre escritura del metodo ToString, que hace publico los datos del Alumno
        /// </summary>
        /// <returns>Los datos del Alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region "SobreCargas"
        /// <summary>
        /// Verifica si un Alumno toma una determinada Clase
        /// </summary>
        /// <param name="a">Es el Alumno a verirficar</param>
        /// <param name="clase">Es la Clase a verificar</param>
        /// <returns>True en caso Exitoso, de lo contrario False</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.clasesQueToma == clase) && (a.estadoCuenta != EEstadoCuenta.Deudor);
        }
        /// <summary>
        /// Verifica si un Alumno NO toma una determinada Clase
        /// </summary>
        /// <param name="a">Es el Alumno a verirficar</param>
        /// <param name="clase">Es la Clase a verificar</param>
        /// <returns>True en caso Exitoso, de lo contrario False</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return (a.clasesQueToma != clase);
        }
        #endregion
    }
}
