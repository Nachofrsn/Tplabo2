using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TpLab2
{
    public class Barco
    {
        private int _tonBodega;
        private int _tonContainer;
        private int _cantContainers;
        private string _destino;
        private string _fechaSalida;
        private string _fechaLlegada;
        private List<Barco> _barcoList;
        private string _disponibilidad;
        private string _formaExportacion;
        public Barco()
        {
            TonBodega = 0;
            TonContainer = 0;
            CantidadContainers = 0;
            Destino = "";
            HorarioSalida = "";
            HorarioLlegada = "";
            Disponibilidad = "Disponible";
            _barcoList = new List<Barco>();
            FormaExportacion = "";
        }
        public int TonBodega
        {
            get { return _tonBodega; }
            set { _tonBodega = value; }
        }
        public int TonContainer
        {
            get { return _tonContainer; }
            set { _tonContainer = value; }
        }
        public int CantidadContainers
        {
            get { return _cantContainers; }
            set { _cantContainers = value; }
        }
        public string Destino
        {
            get { return _destino; }
            set { _destino = value; }
        }
        public string HorarioSalida
        {
            get { return _fechaSalida; }
            set { _fechaSalida = value; }
        }
        public string HorarioLlegada
        {
            get { return _fechaLlegada; }
            set { _fechaLlegada = value; }
        }
        public string Origen
        {
            get { return "Buenos Aires"; }
        }

        public string Disponibilidad
        {
            get { return _disponibilidad; }
            set { _disponibilidad = value; }
        }

        public string FormaExportacion
        {
            get { return _formaExportacion; }
            set { _formaExportacion = value; }
        }
    }
}
