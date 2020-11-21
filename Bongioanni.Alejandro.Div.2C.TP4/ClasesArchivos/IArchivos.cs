using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesArchivos
{
    public interface IArchivos<T> 
    {
        void GuardarTicket(string archivo, T datos);
        void LeerTicket(string archivo, out T datos);
    }
}
