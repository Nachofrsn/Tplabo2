using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TpLab2
{
    public class Cliente
    {
        private string _nombre;
        private string _mercaderia;
        private string _descripcionMercaderia;
        private List<Cliente> _listaClientes;
        private List<Contenedor> _listaContainers;
        private string _formaExportacion;
        private int _toneladas;
        private string _codigoCliente;

        public Cliente()
        {
            NombreCliente = "";
            Mercaderia = "";
            DescripcionMercaderia = "";
            _listaClientes = new List<Cliente>();
            _listaContainers = new List<Contenedor>();
            Exportacion = "";
            Toneladas = 0;
        }

        public string CodigoCliente
        {
            get { return _codigoCliente; }
            set { _codigoCliente = value; }
        }
        public string NombreCliente
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string DescripcionMercaderia
        {
            get { return _descripcionMercaderia; }
            set { _descripcionMercaderia = value; }
        }
        public string Mercaderia
        {
            get { return _mercaderia; }
            set { _mercaderia = value; }
        }

        public string Exportacion
        {
            get { return _formaExportacion; }
            set { _formaExportacion = value; }
        }

        public int Toneladas
        {
            get { return _toneladas; }
            set { _toneladas = value; }
        }

        public void AgregarContenedor(Contenedor contenedor)
        {
            _listaContainers.Add(contenedor);
        }

        public void MostrarContenedores()
        {
            int i = 1;
            foreach (Contenedor aux in _listaContainers)
            {
                if (aux.Seleccion != "seleccionado")
                {
                    Console.WriteLine($"Contenedor {i}\nLargo: {aux.Largo}\nAlto: {aux.Alto}\nAncho: {aux.Ancho}\n---------------------");
                }
                i++;
            }
        }

        public void ListarContenedor(int seleccion)
        {
            int i = 1;
            foreach (Contenedor aux in _listaContainers)
            {
                if (aux.Numeracion == seleccion)
                {
                    aux.Seleccion = "seleccionado";
                }
                if (aux.Seleccion == "seleccionado")
                {
                    Console.WriteLine($"\nMedidas del contenedor {i}:\n\nLargo: {aux.Largo}\nAlto: {aux.Alto}\nAncho: {aux.Ancho}");
                }
                i++;
            }
        }
    }
}