using Exepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T> where T :new()
    {
        /// <summary>
        /// Guarda un tipo generico en un Archivo
        /// </summary>
        /// <param name="archivo">Es el nombre del Archivo</param>
        /// <param name="datos">Son los datos que se van a guardar</param>
        /// <returns>True en caso exitoso, de lo contrario lanzara ArchivosException</returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter xmlWriter = null;
            XmlSerializer serializer = null;
            try
            {
                xmlWriter = new XmlTextWriter(archivo, Encoding.UTF8);
                xmlWriter.Formatting = Formatting.Indented;
                serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(xmlWriter, datos);
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (xmlWriter != null)
                {
                    xmlWriter.Close();
                }
            }
        }
        /// <summary>
        /// Lee un archivo y lo guarda como dato generico
        /// </summary>
        /// <param name="archivo">Es el nombre del archivo que se va a leer</param>
        /// <param name="datos">Donde se van a almacenar los datos leidos</param>
        /// <returns>True en caso exitoso, de lo contrario lanzara ArchivosException</returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader xmlReader = null;
            XmlSerializer serializer = null;
            try
            {
                xmlReader = new XmlTextReader(archivo);
                serializer= new XmlSerializer(typeof(T));
                datos = (T)serializer.Deserialize(xmlReader);
                return true;
            }
            catch(Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (xmlReader != null)
                {
                    xmlReader.Close();
                }
            }
        }
    }
}
