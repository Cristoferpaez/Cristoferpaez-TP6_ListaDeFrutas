using System;
using System.Collections.Generic;

namespace fruta
{
    class Program
    {
        interface IFruta
        {
            string Nombre { get; }
            string Color { get; }
        }

        class Manzana : IFruta
        {
            public string Nombre => "Manzana";
            public string Color => "Rojo";
        }

        class Pera : IFruta
        {
            public string Nombre => "Pera";
            public string Color => "Verde";
        }

        class Banana : IFruta
        {
            public string Nombre => "Banana";
            public string Color => "Amarillo";
        }

        class Naranja : IFruta
        {
            public string Nombre => "Naranja";
            public string Color => "Naranja";
        }

        static void Main(string[] args)
        {
            Console.WriteLine("---------FRUTAS--------");

            List<IFruta> frutas = new List<IFruta>
            {
                new Manzana(),
                new Pera(),
                new Banana(),
                new Naranja()
            };

            bool salir = false;
            while (!salir)
            {

                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Mostrar lista de frutas");
                Console.WriteLine("2. Agregar una fruta");
                Console.WriteLine("3. Eliminar una fruta");
                Console.WriteLine("4. Salir");

                Console.Write("\nSelecciona una opción: ");

                string opcion = Console.ReadLine();

                Console.Clear(); // Limpiar la consola

                switch (opcion)
                {
                    case "1":
                        MostrarFrutas(frutas);
                        break;
                    case "2":
                        AgregarFruta(frutas);
                        break;
                    case "3":
                        EliminarFruta(frutas);
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                        break;
                }
            }
        }

        static void MostrarFrutas(List<IFruta> frutas)
        {
            Console.WriteLine("\nLista de Frutas:");
            foreach (var fruta in frutas)
            {
                Console.WriteLine($"Nombre: {fruta.Nombre}, Color: {fruta.Color}");
            }
        }

        static void AgregarFruta(List<IFruta> frutas)
        {
            Console.Write("\nIngrese el nombre de la fruta: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el color de la fruta: ");
            string color = Console.ReadLine();

            IFruta nuevaFruta = new FrutaPersonalizada(nombre, color);
            frutas.Add(nuevaFruta);

            Console.WriteLine("Fruta agregada con éxito.");
        }

        static void EliminarFruta(List<IFruta> frutas)
        {
            Console.Write("\nIngrese el nombre de la fruta que desea eliminar: ");
            string nombre = Console.ReadLine();

            IFruta frutaEncontrada = frutas.Find(fruta => fruta.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (frutaEncontrada != null)
            {
                frutas.Remove(frutaEncontrada);
                Console.WriteLine("Fruta eliminada con éxito.");
            }
            else
            {
                Console.WriteLine("Fruta no encontrada.");
            }
        }

        class FrutaPersonalizada : IFruta
        {
            public string Nombre { get; }
            public string Color { get; }

            public FrutaPersonalizada(string nombre, string color)
            {
                Nombre = nombre;
                Color = color;
            }
        }
    }
}
