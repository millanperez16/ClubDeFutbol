using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int op = -1;

        while (op != 0) 
        { 
            Console.WriteLine("Gestión del club");
            Console.WriteLine("¿Qué quieres hacer?");
            Console.WriteLine("1. Añadir equipos");
            Console.WriteLine("2. Añadir equipos");
            Console.WriteLine("3. Añadir equipos");
            Console.WriteLine("4. Añadir equipos");
            op = Convert.ToInt32(Console.ReadLine());
            switch (op) 
            {
                case 0:
                    Console.WriteLine("Adiós");
                    break;
                default:
                    Console.WriteLine("Prueba otra opción");
                    break;
            }
        }
    }
}