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
                VerificarOpcion(opcion) ;
            }

            Console.ReadKey();
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\n" +"▒▒▒▒▒▒▒▒▒▒▒▒▒ Menú de Actividades ▒▒▒▒▒▒▒▒▒▒▒▒▒" + "\n");
            Console.WriteLine("1-Mostrar Actividades");
            Console.WriteLine("2-Cambiar valor del aforo máximo");
            Console.WriteLine("3-Cambiar precio de butacas en lugares abiertos");
            Console.WriteLine("4-Mostrar Actividades por categoria y fecha");
            Console.WriteLine("5-Mostrar Actividades para todo publico");
            Console.WriteLine("0-Salir" + "\n");
        }

        static void VerificarOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    Console.WriteLine(miSistema.MostrarActividades());
                    break;
                case 2:
                    Console.WriteLine("\n" + "Ingrese el nuevo valor del aforo máximo");
                    int.TryParse(Console.ReadLine(), out int nuevoAforoMaximo);
                    if (nuevoAforoMaximo > 0)
                    {
                        Console.WriteLine(miSistema.CambiarAforoMaximo(nuevoAforoMaximo));
                    }
                    else
                    {
                        Console.WriteLine("\n" + "El valor ingresado no es correcto");
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("\n" + "Ingrese el nuevo precio por butaca en lugares abiertos");
                    decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio);
                    if (nuevoPrecio > 0)
                    {
                        Console.WriteLine(miSistema.CambiarPrecioButaca(nuevoPrecio));
                    }
                    else
                    {
                        Console.WriteLine("\n" + "El valor ingresado no es correcto");
                    }
                    Console.ReadKey();
                    break;
                case 4:
                    Console.WriteLine("\n" + "Ingrese una categoria");
                    string nombreCategoria = Console.ReadLine();
                    Console.WriteLine("Ingrese fecha inicial");
                    DateTime.TryParse(Console.ReadLine(), out DateTime fechaDesde);
                    Console.WriteLine("Ingrese fecha final");
                    DateTime.TryParse(Console.ReadLine(), out DateTime fechaHasta);
                    if (fechaDesde > DateTime.MinValue && fechaHasta > DateTime.MinValue)
                    {
                        Console.WriteLine(miSistema.ListarActividadesDeCategoria(nombreCategoria, fechaDesde, fechaHasta));
                    }
                    else
                    {
                        Console.WriteLine("\n" + "Los datos no son correctos");
                    }
                    Console.ReadKey();
                    break;
                case 5:
                    Console.WriteLine(miSistema.MostrarActividadesTodoPublico());
                    Console.ReadKey();
                    break;
                default:
                    Console.Clear();
                    break;
            }

        }
    }
}