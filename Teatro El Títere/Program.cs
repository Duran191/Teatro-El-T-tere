using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TeatroReservas
{
    class Program
    {
        const int Filas = 10;
        const int AsientosPorFila = 10;
        static char[,] mapaAsientos = new char[Filas, AsientosPorFila];

        static void Main(string[] args)
        {
            InicializarMapaAsientos();
            bool continuar = true;
            Console.WriteLine("Bienvenidos al teatro ¨EL títere¨");
            while (continuar)
            {
                Console.WriteLine("\n¿Qué desea hacer?");
                Console.WriteLine("1. Muestrame el mapa de asientos");
                Console.WriteLine("2. Reservar asiento");
                Console.WriteLine("3. Salir");
                Console.Write("Elija una opción: ");
                int opcion;
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        MostrarMapaAsientos();
                        break;
                    case 2:
                        ReservarAsiento();
                        break;
                    case 3:
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        static void InicializarMapaAsientos()
        {
            for (int i = 0; i < Filas; i++)
            {
                for (int j = 0; j < AsientosPorFila; j++)
                {
                    mapaAsientos[i, j] = 'L'; 
                }
            }
        }

        static void MostrarMapaAsientos()
        {
            Console.WriteLine("\nVista de los Asientos:");
            for (int i = 0; i < Filas; i++)
            {
                for (int j = 0; j < AsientosPorFila; j++)
                {
                    Console.Write(mapaAsientos[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void ReservarAsiento()
        {
            Console.Write("Ingrese el número de fila (0-9): ");
            int fila;
            if (!int.TryParse(Console.ReadLine(), out fila) || fila < 0 || fila >= Filas)
            {
                Console.WriteLine("Error: Intente otra vez.");
                return;
            }

            Console.Write("Ingrese el número de asiento (0-9): ");
            int asiento;
            if (!int.TryParse(Console.ReadLine(), out asiento) || asiento < 0 || asiento >= AsientosPorFila)
            {
                Console.WriteLine("Error: Intente otra vez.");
                return;
            }

            if (mapaAsientos[fila, asiento] == 'L')
            {
                mapaAsientos[fila, asiento] = 'X'; 
                Console.WriteLine("El asiento ha sido reservado.");
            }
            else
            {
                Console.WriteLine("Error: El asiento ya está reservado. Por favor, elija otro.");
            }
        }
    }
}
