using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TpLab2
{
    public class ObjetosCreados
    {
        public static void CreacionObjetos(ref List<Barco> barcos, ref List<Cliente> clientes, ref List<Contenedor> contenedores)
        {
            Barco A = new Barco();
            Barco B = new Barco();
            Barco C = new Barco();
            Barco D = new Barco();
            Barco E = new Barco();

            barcos.Add(A);
            barcos.Add(B);
            barcos.Add(C);
            barcos.Add(D);
            barcos.Add(E);


            Contenedor contenedor1 = new Contenedor(20, 20, 30);
            Contenedor contenedor2 = new Contenedor(10, 10, 20);
            Contenedor contenedor3 = new Contenedor(15, 20, 30);
            Contenedor contenedor4 = new Contenedor(18, 22, 28);
            Contenedor contenedor5 = new Contenedor(14, 23, 32);
            Contenedor contenedor6 = new Contenedor(11, 15, 22);
            Contenedor contenedor7 = new Contenedor(17, 27, 35);
            Contenedor contenedor8 = new Contenedor(18, 19, 20);

            contenedores.Add(contenedor1);
            contenedores.Add(contenedor2);
            contenedores.Add(contenedor3);
            contenedores.Add(contenedor4);
            contenedores.Add(contenedor5);
            contenedores.Add(contenedor6);
            contenedores.Add(contenedor7);
            contenedores.Add(contenedor8);

            //PREGUNTAR SI CADA CLIENTE NECESITA UNA LISTA DE CONTENEDORES (EL EJERCICIO DICE QUE EL CLIENTE PUEDE TENER MAS DE UN CONTENEDOR)
            Cliente Maximo = new Cliente();
            Maximo.AgregarContenedor(contenedor1);
            contenedor1.Numeracion = 1;
            Maximo.AgregarContenedor(contenedor2);
            contenedor2.Numeracion = 2;

            Cliente Ignacio = new Cliente();
            Ignacio.AgregarContenedor(contenedor3);
            contenedor3.Numeracion = 1;

            Cliente Julia = new Cliente();
            Julia.AgregarContenedor(contenedor4);
            contenedor4.Numeracion = 1;
            Julia.AgregarContenedor(contenedor5);
            contenedor5.Numeracion = 2;

            Cliente Lazaro = new Cliente();
            Lazaro.AgregarContenedor(contenedor6);
            contenedor6.Numeracion = 1;

            clientes.Add(Ignacio);
            clientes.Add(Julia);
            clientes.Add(Maximo);
            clientes.Add(Lazaro);
        }
    }
}
