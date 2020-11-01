using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region "Atributos"
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor privado, iniclializa la lista de Alumnos
        /// </summary>
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor de Jornada
        /// </summary>
        /// <param name="clase">Es la clase que se va a asignar a la Jornada</param>
        /// <param name="instructor">Es el profesor de la Jornada</param>
        public Jornada (Universidad.EClases clase, Profesor instructor)
            :this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Propiedad Lista de Alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        /// <summary>
        /// Propiedad Clase de la Jornada
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        /// <summary>
        /// Propiedad Instrunctor de tipo Profesor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region "SobreCargas"
        /// <summary>
        /// Verifica si un Alumno pertenece a la Clase de la Jornada
        /// </summary>
        /// <param name="j">Es la Jornada</param>
        /// <param name="a">Es el Alumno a verificar</param>
        /// <returns>True en caso exitoso, False de lo contrario</returns>
        public static bool operator == (Jornada j, Alumno a)
        {
            bool returnAux = false;
            foreach (Alumno alumno in j.Alumnos)
            {
                if(a==alumno)
                {
                   returnAux=true;
                   break;
                }      
            }
            return returnAux;
        }
        /// <summary>
        /// Verifica si un Alumno NO pertenece a la Clase de la Jornada
        /// </summary>
        /// <param name="j">Es la Jornada</param>
        /// <param name="a">Es el Alumno a verificar</param>
        /// <returns>True en caso exitoso, False de lo contrario</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agrega un Alumno a la Jornada si este No pertenece a la Clase
        /// </summary>
        /// <param name="j">Es la Jornada</param>
        /// <param name="a">Es el Alumno</param>
        /// <returns>Una Jonada</returns>
        public static Jornada operator + (Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Sobrescritura del meotodo ToString
        /// </summary>
        /// <returns>Los datos de la Jornada</returns>
        public override string ToString()
        {
            StringBuilder returnAux = new StringBuilder();
            returnAux.AppendLine($"Clase de {this.Clase}, dictadad por {this.Instructor.ToString()}");
            returnAux.AppendLine("Alumnos de la Jornada:");
            foreach (Alumno alumno in this.Alumnos)
            {
                returnAux.AppendLine(alumno.ToString());
            }
            returnAux.AppendLine("<-------------------------------------------------->");
            return returnAux.ToString();
        }
        /// <summary>
        /// Lee la Jornada desde un Archivo de Texto guardado en el Debug del Proyecto
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string returnAux = string.Empty;
            Texto archivoTexto = new Texto();
            archivoTexto.Leer("ArchivoJornada.txt", out returnAux);
            return returnAux;
        }
        /// <summary>
        /// Guarda la Jornada en un archivo de Texto en el Debug del Proyecto
        /// </summary>
        /// <param name="j">Es la Jornada que se va a guardar</param>
        /// <returns>True en caso exitoso, False de lo contrario</returns>
        public static bool Guardar(Jornada j)
        {
            Texto archivoTexto = new Texto();            
            return archivoTexto.Guardar("ArchivoJornada.txt", j.ToString());
        }
        #endregion
    }
}
