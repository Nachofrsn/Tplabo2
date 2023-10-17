using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLab2
{
    public class Constantes
    {
        public const string FileNameClientes = "Clientes.csv";
        public const string FileNameBarcos = "Barcos.csv";
        public const string ClienteInexistenteErrorMessage = "El cliente ingresado no se encuentra en el sistema";
        public const string BarcoInexistenteErrorMessage = "El numero de barco ingresado es incorrecto o no se encuentra disponible";
        public const string CantidadToneladaBodegaErrorMessage = "Las toneladas a exportar son mayores a la capacidad de la bodega";
    }
}
