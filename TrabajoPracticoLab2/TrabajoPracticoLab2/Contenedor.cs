using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLab2
{
    public class Contenedor
    {
        private int _alto;
        private int _ancho;
        private int _largo;
        private int _numeracion;
        public string _seleccion;
        public Contenedor(int largo, int ancho, int alto)
        {
            Largo = largo;
            Ancho = ancho;
            Alto = alto;
            Numeracion = 0;
            Seleccion = "";
        }

        public string Seleccion
        {
            get { return _seleccion; }
            set { _seleccion = value; }
        }

        public int Numeracion
        {
            get { return _numeracion; }
            set { _numeracion = value; }
        }

        public int TarifaContenedor
        {
            get { return 5000; }
        }

        public int Largo
        {
            get { return _largo; }
            set { _largo = value; }
        }

        public int Ancho
        {
            get { return _ancho; }
            set { _ancho = value; }
        }

        public int Alto
        {
            get { return _alto; }
            set { _alto = value; }
        }
    }
}
