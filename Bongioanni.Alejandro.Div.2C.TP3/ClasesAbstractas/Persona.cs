using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Exepciones;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        #region "Atributos"
        public enum ENacionalidad { Argentino, Extranjero }
        private string apellido;
        private string nombre;
        private int dni;
        private ENacionalidad nacionalidad;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor sin parametros para Persona
        /// </summary>
        public Persona()
        {

        }
        /// <summary>
        /// Constructor Persona
        /// </summary>
        /// <param name="nombre">Es el nombre de la Persona</param>
        /// <param name="apellido">Es el apellido de la Persona</param>
        /// <param name="nacionalidad">Es la nacionalidad de la Persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor Persona que recibe el DNI como entero
        /// </summary>
        /// <param name="nombre">Es el nombre de la Persona</param>
        /// <param name="apellido">Es el apellido de la Persona</param>
        /// <param name="dni">Es el dni de la Persona</param>
        /// <param name="nacionalidad">Es la nacionalidad de la Persona</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// Constructor Persona que recibe el DNI como cadena de texto
        /// </summary>
        /// <param name="nombre">Es el nombre de la Persona</param>
        /// <param name="apellido">Es el apellido de la Persona</param>
        /// <param name="dni">Es el dni de la Persona</param>
        /// <param name="nacionalidad">Es la nacionalidad de la Persona</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region "Propiedades"
        /// <summary>
        /// Propiedad Apellido de la Persona
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad DNI de la Persona 
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }
        /// <summary>
        /// Propiedad Nacionalidad de la Persona
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        /// <summary>
        /// Propiedad Nombre de la Persona
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad DNI de la Persona de tipo String
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.DNI = ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Realiza la validacion del DNI recibido teniendo en cuenta su Nacionalidad
        /// </summary>
        /// <param name="nacionalidad">Es la nacionalidad de la Persona</param>
        /// <param name="dato">Es el DNI a validar</param>
        /// <returns>El DNI en caso que sea correcto, de los contratrio lanzara Excepcion NacionalidadInvalidaException</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if ((ENacionalidad.Argentino == nacionalidad && dato >= 1 && dato <= 89999999) || (ENacionalidad.Extranjero == nacionalidad && dato >= 90000000 && dato <= 99999999))
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }

        }
        /// <summary>
        /// Realiza la validacion del DNI recibido como string verificando que todos sus caracteres sean correctos
        /// </summary>
        /// <param name="nacionalidad">Es la nacionalidad de la Persona</param>
        /// <param name="dato">Es el DNI a validar</param>
        /// <returns>El DNI como INT en caso correcto, de lo contrario lanzara Excepcion DniInvalidoException</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int longitudDato = dato.Length;

            try
            {
                if (!string.IsNullOrEmpty(dato) && longitudDato > 0 && longitudDato < 9)
                {
                    foreach (char caracter in dato)
                    {
                        if (!char.IsDigit(caracter))
                        {
                            throw new DniInvalidoException();
                        }
                    }
                    return ValidarDni(nacionalidad, int.Parse(dato));
                }
                else
                {
                    throw new DniInvalidoException("Cadena vacia o con mas digitos de lo permitido");
                }
            }
            //El objetivo es capturar la Excepcion que pudiera lanzar int.Parse o bien por un caracter invalido
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo utilizado para evaluar que las cadenas de texto posea caracteres validos para Nombre y Apellido de Persona
        /// </summary>
        /// <param name="dato">Es la cadena a verificar</param>
        /// <returns>La cadena recibida, en caso de error retorna un String.Empty</returns>
        private string ValidarNombreApellido(string dato)
        {
            // Se verifica que la cadena no sea Null o vacia y Permite el ingreso con 1 solo espacio
            string returAux = string.Empty;
            bool flag = false;
            if (!string.IsNullOrEmpty(dato))
            {
                foreach (char caracter in dato)
                {
                    if (!char.IsLetter(caracter) && (char.IsWhiteSpace(caracter) && flag))
                    {
                        return returAux;
                    }
                    else if (char.IsWhiteSpace(caracter))
                    {
                        flag = true;
                    }
                }
                returAux = dato;
            }
            return returAux;
        }
        /// <summary>
        /// Sobre escritura del metodo ToString
        /// </summary>
        /// <returns>Los datos de la Persona</returns>
        public override string ToString()
        {
            StringBuilder returnAux = new StringBuilder();
            returnAux.AppendLine($"Nombre Completo: {this.Apellido}, {this.Nombre}\nDNI: {this.DNI}\nNacionalidad: {this.Nacionalidad}");
            return returnAux.ToString();
        }
        #endregion
    }
}
