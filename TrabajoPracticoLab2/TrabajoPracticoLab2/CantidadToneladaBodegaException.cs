using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLab2
{
    public class CantidadToneladaBodegaException : Exception
    {
        public CantidadToneladaBodegaException() : base(Constantes.CantidadToneladaBodegaErrorMessage)
        {

        }
    }
}
