using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Exepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda un archivo de tipo texto
        /// </summary>
        /// <param name="archivo">Es el nombre del archivo</param>
        /// <param name="datos">Son los datos a guardar</param>
        /// <returns>True en caso exitoso, de lo contrario lanzara ArchivosException</returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(archivo, false);
                streamWriter.WriteLine(datos);
                return true;
            }
            catch (Exception ex)
            {
                throw new ArchivosException(ex);
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
        /// Lee un archivo de tipo texto y guarda sus datos en una variable
        /// </summary>
        /// <param name="archivo">Es el nombre del archivo que se va a leer</param>
        /// <param name="datos">Es donde se van a guardar los datos leidos</param>
        /// <returns>True en caso exitoso, de lo contrario lanzara ArchivosException</returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader streamRead = null;
            try
            {
                streamRead = new StreamReader(archivo);
                string texto = string.Empty;
                string nuevaLinea = streamRead.ReadLine();
                while (nuevaLinea != null)
                {
                    texto += nuevaLinea + "\n";
                    nuevaLinea = streamRead.ReadLine();
                }
                datos = texto;
                return true;
            }
            catch(Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (streamRead != null)
                {
                    streamRead.Close();
                }
            }
        }
    }

}
