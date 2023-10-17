using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLab2
{
    public class Program
    {
        public static string[] menu = new string[] { "1-Generar Despacho.", "2-Listar Despachos.", "3-Salir." };
        static void Main(string[] args)
        {
            int FijadoColor = 0, LongitudMenu = 3;
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

                        string cliente = "";
                        bool repeat = false;
                        do
                        {
                            try
                            {
                                Console.WriteLine("Ingrese un codigo de cliente");
                                cliente = ManejoArchivos.ChequeoUsuario(Console.ReadLine(), ref clientes);
                                Console.Clear();
                                Console.WriteLine("Cliente encontrado!");
                                repeat = true;
                            }
                            catch (ClienteInexistenteException e)
                            {
                                Console.WriteLine(e.Message);
                                repeat = false;
                            }
                        } while (repeat == false);


                        ManejoArchivos.PrinteoBarcos(ref barcos);
                        Console.WriteLine("Barcos disponibles:\n");

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
                        foreach (Cliente aux in clientes)
                        {
                            if (aux.CodigoCliente == cliente)
                            {
                                despacho1.Cliente = aux;
                                if (despacho1.Cliente.Exportacion == "contenedor" || despacho1.Cliente.Exportacion == "Contenedor")
                                {
                                    Console.WriteLine($"Descripcion del producto a exportar: {despacho1.Cliente.DescripcionMercaderia}\n");
                                    despacho1.Cliente.MostrarContenedores();

                                    Console.WriteLine("Seleccione contenedor a despachar");
                                    int eleccion = int.Parse(Console.ReadLine());

                                    Console.WriteLine($"\n\n\nResumen del despacho numero: {despacho1.NumeroDespacho}\n\n");
                                    Console.WriteLine($"Cliente: {despacho1.Cliente.NombreCliente}\nCodigo cliente: {despacho1.Cliente.CodigoCliente}" +
                                        $"\nMercaderia: {despacho1.Cliente.Mercaderia}\nDescripcion mercaderia: {despacho1.Cliente.DescripcionMercaderia}" +
                                        $"\n\n");
                                    despacho1.Cliente.ListarContenedor(eleccion);

                                    Console.WriteLine("\nDesea despachar otro contenedor? (si)"); string eleccion2 = Console.ReadLine();
                                    if (eleccion2 == "si" || eleccion2 == "SI" || eleccion2 == "Si")
                                    {
                                        despacho1.Cliente.MostrarContenedores();
                                        Console.WriteLine("\nIngrese numero de contenedor a despachar"); eleccion = int.Parse(Console.ReadLine());
                                        Console.WriteLine($"\n\nCliente: {despacho1.Cliente.NombreCliente}\nCodigo cliente: {despacho1.Cliente.CodigoCliente}" +
                                        $"\nMercaderia: {despacho1.Cliente.Mercaderia}\nDescripcion mercaderia: {despacho1.Cliente.DescripcionMercaderia}" +
                                        $"\n\n");
                                        despacho1.Cliente.ListarContenedor(eleccion);
                                    }
                                    else Console.WriteLine("Se cerrara el programa");
                                }
                                else if (despacho1.Cliente.Exportacion == "bodega" || despacho1.Cliente.Exportacion == "Bodega")
                                {
                                    bool repetir = false;
                                    while (repetir == false)
                                    {
                                        try
                                        {
                                            ChequeoToneladas(ref despacho1);
                                            repetir = true;
                                        }
                                        catch (CantidadToneladaBodegaException e)
                                        {
                                            Console.WriteLine(e.Message);
                                            Console.WriteLine($"La capacidad que tiene este barco en bodega es de {despacho1.Barco.TonBodega} toneladas");
                                            repetir = false;
                                        }
                                    }
                                }
                            }
                        }
                        OpcionMenuSalir = false;
                        break;

                    case 1:
                        int a = 1;
                        if (listaDespacho.Count == 0)
                        {
                            Console.WriteLine("Aun no se ha realizado un despacho");
                        }
                        else
                        {
                            foreach (Despacho aux in listaDespacho)
                            {
                                Console.WriteLine($"Despacho {1}:\n\n{aux.Barco}{aux.NumeroDespacho}{aux.Cliente.NombreCliente}{aux.Cliente.CodigoCliente}");
                                a++;
                            }
                        }
                        OpcionMenuSalir = false;
                        break;
                    case 2:
                        Console.WriteLine("Eligio salir del programa: cerrando...");
                        OpcionMenuSalir = false;
                        break;
                }
            } while (OpcionMenuSalir);
            Console.ReadKey();
        }

        public static bool ChequeoToneladas(ref Despacho despacho1)
        {
            Console.WriteLine("Ingrese cantidad de toneladas a exportar"); int toneladas = int.Parse(Console.ReadLine()); despacho1.Cliente.Toneladas = toneladas;
            if (despacho1.Barco.TonBodega >= despacho1.Cliente.Toneladas)
            {
                Console.WriteLine($"Descripcion de mercaderia: {despacho1.Cliente.DescripcionMercaderia}\nToneladas a exportar " +
                $"por el cliente: {despacho1.Cliente.Toneladas}");
                return true;
            }
            else throw new CantidadToneladaBodegaException();
        }
    }
}
