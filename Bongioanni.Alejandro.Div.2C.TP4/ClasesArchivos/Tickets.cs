using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ClasesExcepciones;
using System.Xml;
using System.Xml.Serialization;
using ClasesVehiculos;

namespace ClasesArchivos
{
    public class Tickets : IArchivos<string>, IArchivos<Vehiculo>
    {
        #region "Atributos"
        private static string rutaDefault;
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor de clase que establece la ruta del escritorio por defecto
        /// </summary>
        static Tickets()
        {
            rutaDefault = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\";
        }
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Tickets()
        {

        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Metodo privado que crea una directorio en el Escritorio en caso de no existir
        /// </summary>
        /// <param name="ruta">Es el path del directorio a crear</param>
        /// <returns>True al crear el directorio, en caso de no poder lanzara excepcion</returns>
        /// <exception cref="ArchivoException"></exception>
        private bool CreaDirectorio(string ruta)
        {
            bool returnAux = false;
            try
            {
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }
                returnAux = true;
            }
            catch (Exception ex)
            {
                throw new ArchivoException("No se pudo crear el directorio", ex);
            }
            return returnAux;
        }
        /// <summary>
        /// Guarda datos en un archivo de tipo Texto
        /// </summary>
        /// <param name="archivo">Es el nombre del archivo a generar</param>
        /// <param name="datos">Son los datos a guardar en el archivo</param>
        public void GuardarTicket(string archivo, string datos)
        {
            string rutaAux = string.Empty;
            StreamWriter streamWriter = null;
            try
            {
                rutaAux = $"{rutaDefault}Facturas";
                if (this.CreaDirectorio(rutaAux))
                {
                    rutaAux += $"\\{archivo}";
                    streamWriter = new StreamWriter(rutaAux,false);
                    streamWriter.WriteLine(datos);
                }
            }
            catch (ArchivoException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ArchivoException("No se pudo generar el Ticket", ex);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }
        }
        /// <summary>
        /// Lee un archivo de Texto
        /// </summary>
        /// <param name="archivo">Es el archivo a leer</param>
        /// <param name="datos">Es donde donde se van a guardar los datos leidos</param>
        public void LeerTicket(string archivo,out string datos)
        {
            StreamReader streamRead = null;
            try
            {
                streamRead = new StreamReader(archivo);
                string texto = string.Empty;
                string linea = streamRead.ReadLine();
                while (linea != null)
                {
                    texto += linea + "\n";
                    linea = streamRead.ReadLine();
                }
                datos= texto;

            }
            catch (Exception ex)
            {
                throw new ArchivoException("No se pudo leer el Ticket", ex);
            }
            finally
            {
                if (streamRead != null)
                {
                    streamRead.Close();
                }
            }
        }
        /// <summary>
        /// Guarda los datos de un vehiculo en un Archivo de tipo XML
        /// </summary>
        /// <param name="archivo">Es el nombre del archivo a generar</param>
        /// <param name="vehiculo">Son los datos a guardar en el archivo</param>
        void IArchivos<Vehiculo>.GuardarTicket(string archivo, Vehiculo vehiculo)
        {
            XmlTextWriter writer = null;
            XmlSerializer serializer = null;
            string rutaAux = string.Empty;
            try
            {
                rutaAux = $"{rutaDefault}Facturas\\XML";
                if (this.CreaDirectorio(rutaAux))
                {
                    rutaAux += $"\\{archivo}";
                    writer = new XmlTextWriter(rutaAux, Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    serializer = new XmlSerializer(typeof(Vehiculo));
                    serializer.Serialize(writer, vehiculo);
                }
            }
            catch (Exception ex)
            {
                throw new ArchivoException("No se pudo serializar", ex);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
        /// <summary>
        /// Genera un vehiculo desde la Lectura de un archivo XML
        /// </summary>
        /// <param name="archivo">Es el nombre del archivo a generar</param>
        /// <param name="vehiculo">Es el vehiculo donde se van a guardar los datos leidos</param>
        void IArchivos<Vehiculo>.LeerTicket(string archivo, out Vehiculo vehiculo)
        {
            XmlTextReader xmlReader = null;
            XmlSerializer serializer = null;
            try
            {
                xmlReader = new XmlTextReader(archivo);
                serializer = new XmlSerializer(typeof(Vehiculo));
                vehiculo = (Vehiculo)serializer.Deserialize(xmlReader);
            }
            catch (Exception ex)
            {
                throw new ArchivoException("No se pudo leer", ex);
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
            }
        }
        #endregion
    }
}
