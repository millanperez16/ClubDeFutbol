using System;
using System.Collections.Generic;

class Program
{
    static List<string> equipos = new List<string>();

    static void Main()
    {
        Menu();
    }

    static void Menu() 
    {
        int op = -1;

        while (op != 0)
        {
            Console.WriteLine("Gestión del club");
            Console.WriteLine("¿Qué quieres hacer?");
            Console.WriteLine("0. Salir del programa");
            Console.WriteLine("1. Listar equipos");
            Console.WriteLine("2. Añadir equipos");
            Console.WriteLine("3. Listar jugadores");
            Console.WriteLine("4. Añadir jugadores");
            op = Convert.ToInt32(Console.ReadLine());
            switch (op)
            {
                case 0:
                    Console.WriteLine("Adiós");
                    break;
                case 1:
                    ListarEquipos();
                    break;
                case 2:
                    Console.WriteLine("Introduce un nombre de equipo:");
                    string nombre = Console.ReadLine() ?? string.Empty;
                    AnadirEquipo(nombre);
                    break;
                case 3:
                    Console.WriteLine("Adiós");
                    break;
                case 4:
                    Console.WriteLine("Adiós");
                    break;
                default:
                    Console.WriteLine("Prueba otra opción");
                    break;
            }
        }
    }

    static void ListarEquipos() 
    {
        Console.Clear();
        Console.WriteLine("=== Lista de equipos ===");

        if (equipos.Count == 0)
            Console.WriteLine("No hay equipos registrados");
        else 
        {
            foreach (string equipo in equipos) 
            {
                Console.WriteLine(equipo);
            }
        }
    }

    static void AnadirEquipo(string nombre) 
    {
        if (!string.IsNullOrEmpty(nombre) && !equipos.Contains(nombre))
        { 
            equipos.Add(nombre);
            Console.WriteLine($"Has añadido al equipo '{nombre}'.");
        }
        else
            Console.WriteLine("No se pudo añadir: ya existe o no es válido");
    }
}