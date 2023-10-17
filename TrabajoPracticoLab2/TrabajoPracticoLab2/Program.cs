using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLab2
{
    public class Program
    {
        public static string[] menu = new string[] { "1-Generar Despacho.", "2-Salir." };
        static void Main(string[] args)
        {
            int FijadoColor = 0, LongitudMenu = 2;
            ConsoleKey key;
            bool OpcionMenuSalir = true;
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Bienvenido al menu: Muevase con las flechas hacia arriba y abajo. Presione enter para seleccionar. \n");
                    for (int MuestraMenu = 0; MuestraMenu < menu.Length; MuestraMenu++)
                    {
                        //SI LAS CONDICIONES SON IGUALES, IMPRIME EL COLOR DEL INDICE EN VERDE
                        if (MuestraMenu == FijadoColor) Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(menu[MuestraMenu]);
                        Console.ResetColor();
                    }
                    //OBTIENE EL SIGUIENTE CARACTER INGRESADO POR EL USUARIO
                    key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            //CONTADOR QUE HACE QUE CAMBIE EL COLOR CUANDO SE REINICIA EL FOR
                            FijadoColor--;
                            if (FijadoColor < 0) FijadoColor = 0;
                            break;

                        case ConsoleKey.DownArrow:
                            //CONTADOR QUE HACE QUE CAMBIE EL COLOR CUANDO SE REINICIA EL FOR
                            FijadoColor++;
                            if (FijadoColor > LongitudMenu - 1) FijadoColor = LongitudMenu - 1;
                            break;
                    }
                } while (key != ConsoleKey.Enter);

                switch (FijadoColor)
                {
                    case 0:
                        Console.Clear();

                        Random rnd = new Random(); //PARA EL CODIGO DE DESPACHO

                        List<Barco> barcos = new List<Barco>();
                        List<Cliente> clientes = new List<Cliente>();
                        List<Contenedor> contenedores = new List<Contenedor>();

                        ObjetosCreados.CreacionObjetos(ref barcos, ref clientes, ref contenedores);

                        Console.WriteLine("Barcos disponibles:\n");
                        //IMPRIME LOS BARCOS
                        for (int i = 0; i < barcos.Count; i++)
                        {
                            if (barcos[i].Disponibilidad == "Disponible")
                            {
                                Console.WriteLine($"Barco {i + 1}:\nPuerto de origen: {barcos[i].Origen}\nPuerto de destino: {barcos[i].Destino}" +
                                $"\nFecha de salida: {barcos[i].HorarioSalida}\nHorario de llegada: {barcos[i].HorarioLlegada}\n----------------------");
                            }
                        }

                        Console.WriteLine("\nSeleccione un barco");
                        int seleccion = int.Parse(Console.ReadLine());
                        Despacho despacho1 = new Despacho(barcos[seleccion - 1], rnd.Next(9000, 18000));

                        string cliente = "";
                        bool repeat = false;
                        List<Cliente> listaClienteDespacho = new List<Cliente>();

                        do
                        {
                            try
                            {
                                Console.WriteLine("Ingrese un cliente");
                                cliente = Console.ReadLine();
                                ChequeoUsuario(cliente, clientes, ref listaClienteDespacho);

                                Console.WriteLine("Cliente agregado al despacho, desea seguir ingresando? (ingrese 'si')");
                                string respuesta = Console.ReadLine();
                                if (respuesta == "si" || respuesta == "Si" || respuesta == "SI")
                                {
                                    repeat = false;
                                }
                                else { repeat = true; }
                            }
                            catch (ClienteInexistenteException e)
                            {
                                Console.WriteLine(e.Message);
                                repeat = false;
                            }
                        } while (repeat == false);

                        OpcionMenuSalir = false;
                        break;

                    case 1:
                        Console.WriteLine("Eligio salir del programa: cerrando...");
                        OpcionMenuSalir = false;
                        break;
                }
            } while (OpcionMenuSalir);

            Console.ReadKey();
        }
        public static bool ChequeoUsuario(string cliente, List<Cliente> clientes, ref List<Cliente> listaClienteDespacho)
        {
            foreach (Cliente aux in clientes)
            {
                if (cliente == aux.NombreCliente)
                {
                    Console.WriteLine("\nCliente encontrado!\n");
                    listaClienteDespacho.Add(aux);
                    if (aux.Exportacion == "Contenedor")
                    {
                        Console.WriteLine($"Mercaderia del cliente: {aux.Mercaderia}\n");
                        aux.MostrarContenedores();
                        return true;
                    }
                    else if (aux.Exportacion == "Bodega")
                    {
                        return false;
                    }
                }
            }
            throw new ClienteInexistenteException();
        }
    }
}