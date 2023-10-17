using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLab2
{
    public class ClienteInexistenteException : Exception
    {
        public ClienteInexistenteException() : base(Constantes.ClienteInexistenteErrorMessage)
        {

        }
    }
}
