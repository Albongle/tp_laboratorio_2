using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Exepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region "Atributos"
        public enum EClases {Programacion, Laboratorio,Legislacion,SPD};
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor de Universidad
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Propiedad Alumnos, devuelve y establece un listado de Alumnos
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
        /// Propiedad Instructores, devuelve y establece un listado de Profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        /// <summary>
        /// Propiedad Jornadas, devuelve y establece un listado de Jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        /// <summary>
        /// Propiedad Jornada con Indexador
        /// </summary>
        /// <param name="i">Es el indice de la lista de Jornada</param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                if(i>=0 && i< this.Jornadas.Count)
                {
                    return this.Jornadas[i];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (i >= this.Jornadas.Count)
                {
                    this.Jornadas.Add(value);
                }
            }
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Metodo estatico que muestra todos los datos de la Universidad
        /// </summary>
        /// <param name="uni">Es la universidad a mostrar</param>
        /// <returns>Una cadena de texto con los datos de la Universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder returnAux = new StringBuilder();
            returnAux.AppendLine("****Jornada****");
            foreach (Jornada jornada in uni.Jornadas)
            {
                returnAux.AppendLine(jornada.ToString());
            }
            return returnAux.ToString();
        }
        /// <summary>
        /// Sobrescritura del moetodo ToString
        /// </summary>
        /// <returns>Todos los datos de la Universidad</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        /// Guarda la universidad serializada en XML en el Debug del Proyecto
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>True en caso exitoso, False de lo contrario</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> archivoXlm = new Xml<Universidad>();
            return archivoXlm.Guardar("ArchivoUniversidad.xml", uni);
        }
        /// <summary>
        /// Lee la Universidad serializada en XML Guardado en el Debug del Proyecto
        /// </summary>
        /// <returns>Una Universidad</returns>
        public static Universidad Leer()
        {
            Universidad returnAux=null;
            Xml<Universidad> archivoXlm = new Xml<Universidad>();
            archivoXlm.Leer("ArchivoUniversidad.xml", out returnAux);
            return returnAux;
        }
        #endregion

        #region "SobreCargas"
        /// <summary>
        /// Verificar si un Alumno pertenece a la Universidad
        /// </summary>
        /// <param name="u">Es la universidad</param>
        /// <param name="a">Es el Alumno</param>
        /// <returns>True en caso exitoso, Flase de lo contrario</returns>
        public static bool operator == (Universidad u, Alumno a)
        {
            bool returnAux = false;
            foreach (Alumno alumno in u.Alumnos)
            {
                if(alumno==a)
                {
                    returnAux = true;
                    break;
                }
            }
            return returnAux;
        }
        /// <summary>
        /// Verificar si un Alumno NO pertenece a la Universidad
        /// </summary>
        /// <param name="u">Es la universidad</param>
        /// <param name="a">Es el Alumno</param>
        /// <returns>True en caso exitoso, Flase de lo contrario</returns>
        public static bool operator !=(Universidad u, Alumno a)
        {
            return !(u == a);
        }
        /// <summary>
        /// Verificar si un Profesor pertenece a la Universidad
        /// </summary>
        /// <param name="u">Es la Universidad</param>
        /// <param name="p">Es el Profesor</param>
        /// <returns>True en caso exitoso, False de lo contrario</returns>
        public static bool operator ==(Universidad u, Profesor p)
        {
            bool returnAux = false;
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor == p)
                {
                    returnAux = true;
                    break;
                }
            }
            return returnAux;
        }
        /// <summary>
        /// Verificar si un Profesor NO pertenece a la Universidad
        /// </summary>
        /// <param name="u">Es la Universidad</param>
        /// <param name="p">Es el Profesor</param>
        /// <returns>True en caso exitoso, Flase de lo contrario</returns>
        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }
        /// <summary>
        /// Verifica de la lista de Profesores cual puede dar la Clase
        /// </summary>
        /// <param name="u">Es la Universidad</param>
        /// <param name="clase">Es la Clase</param>
        /// <returns>En la primera coincidencia en caso exitoso, de lo contrario lanza SinProfesorException</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor profesor in u.Instructores)
            {
                if(profesor==clase)
                {
                    return profesor;
                }                              
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Verifica de la lista de Profesores cual NO puede dar la Clase
        /// </summary>
        /// <param name="u">Es la Universidad</param>
        /// <param name="clase">Es la Clase</param>
        /// <returns>En la primera coincidencia en caso exitoso, de lo contrario lanza SinProfesorException</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor returnAux = null;
            foreach (Profesor profesor in u.Instructores)
            {
                if (profesor != clase)
                {
                    returnAux= profesor;
                    break;
                }
            }
            return returnAux;
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agrega una Clase a la Universidad con Jornada y Alumnos
        /// </summary>
        /// <param name="u">Es la Universidad a la que se va agregar la Clase</param>
        /// <param name="clases">Es la Clase que se va a agregar a la Universidad</param>
        /// <returns>Una Universidad</returns>
        public static Universidad operator +(Universidad u, EClases clases)
        {
            Profesor profesorAux = u == clases;
            Jornada jornada = new Jornada(clases,profesorAux);
            foreach (Alumno alumno in u.Alumnos)
            {
                if(alumno==clases)
                {
                    jornada += alumno;
                }
            }
            u.Jornadas.Add(jornada);
            return u;
        }
        /// <summary>
        /// Agrega un Alumno a la Universidad
        /// </summary>
        /// <param name="u">Es la Universidad donde se va a gregar el Alumno</param>
        /// <param name="a">Es el Alumno que se va a agregar a la Universidad</param>
        /// <returns>Una Universidad</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if(u!=a)
            {
                u.Alumnos.Add(a);
                return u;
            }
            throw new AlumnoRepetidoException();
           
        }
        /// <summary>
        /// Agrega un Profesor a la Universidad
        /// </summary>
        /// <param name="u">Es la Universidad donde se va a gregar el Profesor</param>
        /// <param name="p">Es eñ Profesor que se va a agregar a la Universidad</param>
        /// <returns>Una Universidad</returns>
        public static Universidad operator +(Universidad u, Profesor p)
        {
            if (u != p)
            {
                u.Instructores.Add(p);
            }
            return u;
        }
        #endregion

    }
}
