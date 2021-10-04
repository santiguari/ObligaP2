using System;
using ObligatorioP2Dominio;

namespace ObligatorioP2Web
{
    class Program
    {
        private static Sistema miSistema = new Sistema();

        static void Main(string[] args)
        {
            int opcion = -1;
            while (opcion != 0)
            {
                MostrarMenu();
                Console.WriteLine("Ingrese opción de menú");
                int.TryParse(Console.ReadLine(), out opcion);
                VerificarOpcion(opcion);
            }

            Console.ReadKey();
        }

        static void MostrarMenu()
        {
            Console.WriteLine("1-Alta cliente");
            Console.WriteLine("0-Salir");
        }

        static void VerificarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    Console.WriteLine(miSistema.MostrarActividades());
                    Console.ReadKey();

                    break;
                default:
                    Console.Clear();
                    break;
            }

        }
    }
}
