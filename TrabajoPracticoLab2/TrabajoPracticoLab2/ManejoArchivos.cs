using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLab2
{
    public class ManejoArchivos
    {
        public static bool PrinteoBarcos(ref List<Barco> barcos)
        {
            FileStream archivo = new FileStream(Constantes.FileNameBarcos, FileMode.Open);
            StreamReader lector = new StreamReader(archivo);

            if (File.Exists(Constantes.FileNameBarcos))
            {
                lector.ReadLine();
                int i = 0;
                while (lector.EndOfStream == false)
                {
                    string line = lector.ReadLine();
                    string[] lines = line.Split(',');

                    barcos[i].Destino = lines[1];
                    barcos[i].FormaExportacion = lines[2];
                    barcos[i].HorarioSalida = lines[3];
                    barcos[i].HorarioLlegada = lines[4];
                    barcos[i].CantidadContainers = int.Parse(lines[5]);
                    barcos[i].TonBodega = int.Parse(lines[6]);
                    barcos[i].TonContainer = int.Parse(lines[7]);
                    i++;
                }
                lector.Close();
                archivo.Close();
                return true;
            }
            lector.Close();
            archivo.Close();
            return false;
        }

        public static string ChequeoUsuario(string cliente, ref List<Cliente> clientes)
        {
            FileStream archivo = new FileStream(Constantes.FileNameClientes, FileMode.Open);
            StreamReader lector = new StreamReader(archivo);
            lector.ReadLine();
            int i = 0;
            while (lector.EndOfStream == false)
            {
                string line = lector.ReadLine();
                string[] lines = line.Split(',');

                if (lines[0] == cliente)
                {
                    //Poner los objetos cliente en el mismo orden al csv
                    clientes[i].CodigoCliente = lines[0];
                    clientes[i].NombreCliente = lines[1];
                    Console.WriteLine("Ingrese mercaderia a despachar"); string mercaderia = Console.ReadLine(); clientes[i].Mercaderia = mercaderia;
                    Console.WriteLine("Ingrese descripcion de la mercaderia"); string descMercaderia = Console.ReadLine(); clientes[i].DescripcionMercaderia = descMercaderia;

                    Console.WriteLine("Ingrese forma de exportacion (Contenedor o Bodega)"); string exportacion = Console.ReadLine(); clientes[i].Exportacion = exportacion;
                    lector.Close();
                    archivo.Close();
                    return cliente;
                }
                i++;
            }
            lector.Close();
            archivo.Close();
            throw new ClienteInexistenteException();
        }
    }
}
