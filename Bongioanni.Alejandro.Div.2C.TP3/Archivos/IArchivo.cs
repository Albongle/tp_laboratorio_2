using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Metodo Guardar de Interface a Implementar
        /// </summary>
        /// <param name="archivo">Es el nombre del archivo</param>
        /// <param name="datos">Son los datos que se van a guardar</param>
        /// <returns>True en caso exitoso, de lo contrario lanzara ArchivosException</returns>
        bool Guardar(string archivo, T datos);
        /// <summary>
        /// Metodo Leer de Interface a Implementar
        /// </summary>
        /// <param name="archivo">Es el nombre del archivo</param>
        /// <param name="datos">Es donde se van a guardar los datos leidos</param>
        /// <returns>True en caso exitoso, de lo contrario lanzara ArchivosException</returns>
        bool Leer(string archivo, out T datos);
    }
}
