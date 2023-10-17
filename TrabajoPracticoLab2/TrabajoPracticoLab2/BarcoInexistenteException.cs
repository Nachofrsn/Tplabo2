using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLab2
{
    public class BarcoInexistenteException : Exception
    {
        public BarcoInexistenteException() : base(Constantes.BarcoInexistenteErrorMessage)
        {

        }
    }
}
