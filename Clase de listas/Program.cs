using System;
using System.Collections.Generic;

namespace fruta
{
    // Definición de la interfaz IFruta que representa las propiedades comunes de una fruta
    interface IFruta
    {
        string Nombre { get; }
        string Color { get; }
    }

    // Clase que implementa la interfaz IFruta para representar una manzana
    class Manzana : IFruta
    {
        public string Nombre => "Manzana";
        public string Color => "Rojo";
    }

    // Clase que implementa la interfaz IFruta para representar una pera
    class Pera : IFruta
    {
        public string Nombre => "Pera";
        public string Color => "Verde";
    }

    // Clase que implementa la interfaz IFruta para representar una banana
    class Banana : IFruta
    {
        public string Nombre => "Banana";
        public string Color => "Amarillo";
    }

    // Clase que implementa la interfaz IFruta para representar una naranja
    class Naranja : IFruta
    {
        public string Nombre => "Naranja";
        public string Color => "Naranja";
    }

    class Program
    {
        // Método principal del programa
        static void Main(string[] args)
        {
            Console.WriteLine("---------FRUTAS--------");

            // Creación de una lista de frutas con algunas frutas predefinidas
            List<IFruta> frutas = new List<IFruta>
            {
                new Manzana(),
                new Pera(),
                new Banana(),
                new Naranja()
            };

            // Variable para controlar si el usuario desea salir del programa
            bool salir = false;

            // Bucle principal del menú
            while (!salir)
            {
                // Mostrar el menú
                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Mostrar lista de frutas");
                Console.WriteLine("2. Agregar una fruta");
                Console.WriteLine("3. Eliminar una fruta");
                Console.WriteLine("4. Salir");

                // Solicitar al usuario que seleccione una opción
                Console.Write("\nSelecciona una opción: ");
                string opcion = Console.ReadLine();

                // Limpiar la consola
                Console.Clear();

                // Procesar la opción seleccionada por el usuario
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

        // Método para mostrar la lista de frutas
        static void MostrarFrutas(List<IFruta> frutas)
        {
            Console.WriteLine("\nLista de Frutas:");
            foreach (var fruta in frutas)
            {
                Console.WriteLine($"Nombre: {fruta.Nombre}, Color: {fruta.Color}");
            }
        }

        // Método para agregar una nueva fruta a la lista
        static void AgregarFruta(List<IFruta> frutas)
        {
            Console.Write("\nIngrese el nombre de la fruta: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el color de la fruta: ");
            string color = Console.ReadLine();

            // Crear una nueva fruta personalizada y agregarla a la lista
            IFruta nuevaFruta = new FrutaPersonalizada(nombre, color);
            frutas.Add(nuevaFruta);

            Console.WriteLine("Fruta agregada con éxito.");
        }

        // Método para eliminar una fruta de la lista
        static void EliminarFruta(List<IFruta> frutas)
        {
            Console.Write("\nIngrese el nombre de la fruta que desea eliminar: ");
            string nombre = Console.ReadLine();

            // Buscar la fruta en la lista y eliminarla si se encuentra
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

        // Clase que representa una fruta personalizada con un nombre y un color definidos por el usuario
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
