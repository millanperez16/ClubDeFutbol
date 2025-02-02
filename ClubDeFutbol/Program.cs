using System;
using System.Collections.Generic;

class Program
{
    class Jugador
    {
        public string Nombre { get; set; }
        public string Posicion { get; set; }

        public Jugador(string nombre, string posicion)
        {
            Nombre = nombre;
            Posicion = posicion;
        }
    }

    // Lista de equipos con sus jugadores y posiciones indicadas.
    static Dictionary<string, List<Jugador>> equipos = new Dictionary<string, List<Jugador>>
    {
        { "FC Barcelona Masculino", new List<Jugador>
            {
                new Jugador("#1 Ter Stegen", "Portero"), new Jugador("#13 Iñaki Peña", "Portero"), new Jugador("#25 Wojciech Szcesny", "Portero"),
                new Jugador("#2 Pau Cubarsí", "Defensa"), new Jugador("#3 Alejandro Balde", "Defensa"), new Jugador("#4 Ronald Araujo", "Defensa"),
                new Jugador("#5 Iñigo Martínez", "Defensa"), new Jugador("#23 Jules Koundé", "Defensa"), new Jugador("#24 Eric García", "Defensa"),
                new Jugador("#6 Gavi", "Centrocampista"), new Jugador("#8 Pedri", "Centrocampista"), new Jugador("#16 Fermín Lopez", "Centrocampista"),
                new Jugador("#17 Marc Casadó", "Centrocampista"), new Jugador("#20 Dani Olmo", "Centrocampista"), new Jugador("#21 Frenkie de Jong", "Centrocampista"),
                new Jugador("#7 Ferran Torres", "Delantero"), new Jugador("#9 Robert Lewandowski", "Delantero"), new Jugador("#10 Ansu Fekas", "Delantero"),
                new Jugador("#11 Raphinha", "Delantero"), new Jugador("#18 Pau Víctor", "Delantero"), new Jugador("#19 Lamine Yamal", "Delantero")
            }
        },
        { "FC Barcelona Femenino", new List<Jugador>
            {
                new Jugador("#1 Gemma Font", "Portero"), new Jugador("#13 Cata Coll", "Portero"), new Jugador("#25 Ellie Roebuck", "Portero"),
                new Jugador("#2 Irene Paredes", "Defensa"), new Jugador("#4 Mapi León", "Defensa"), new Jugador("#5 Jana Fernández", "Defensa"),
                new Jugador("#8 Marta Torrejón", "Defensa"), new Jugador("#22 Ona Batlle", "Defensa"), new Jugador("#35 Judit Pujols", "Defensa"),
                new Jugador("#11 Alexia Putellas", "Centrocampista"), new Jugador("#12 Patri Guijarro", "Centrocampista"), new Jugador("#14 Aitana Bonmatí", "Centrocampista"),
                new Jugador("#19 Vicky Lopez", "Centrocampista"), new Jugador("#23 Ingrid Engen", "Centrocampista"), new Jugador("#24 Esmee Brugts", "Centrocampista"),
                new Jugador("#7 Salma Paralluelo", "Delantero"), new Jugador("#9 Claudia Pina", "Delantero"), new Jugador("#10 Caroline Graham Hansen", "Delantero"),
                new Jugador("#16 Fridolina Rolfö", "Delantero"), new Jugador("#17 Ewa Pajor", "Delantero"), new Jugador("#18 Kika Nazareth", "Delantero")
            }
        }
    };

    static void Main()
    {
        Menu();
    }

    static void Menu() 
    {
        int op = -1;

        while (op != 0)
        {
            // \n Sirve para dar una linea de espacio.
            Console.WriteLine("\nGestión del club");
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
                    ListarJugadores();
                    break;
                case 4:
                    AnadirJugador();
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
            foreach (var equipo in equipos) 
            {
                Console.WriteLine(equipo);
            }
        }
    }

    static void AnadirEquipo(string nombre) 
    {
        if (!string.IsNullOrEmpty(nombre) && !equipos.ContainsKey(nombre))
        { 
            equipos.Add(nombre, new List<Jugador>());
            Console.WriteLine($"Has añadido al equipo '{nombre}'.");
        }
        else
            Console.WriteLine("No se pudo añadir: ya existe o no es válido");
    }
    static void ListarJugadores()
    {
        Console.Clear();
        Console.WriteLine("=== Listar jugadores ===");
        Console.WriteLine("Introduce el nombre del equipo:");

        string equipo = Console.ReadLine() ?? string.Empty;

        if (equipos.ContainsKey(equipo))
        {
            List<Jugador> jugadores = equipos[equipo];

            if (jugadores.Count == 0)
                Console.WriteLine($"El equipo {equipo} no tiene jugadores registrados.");
            else
            {
                // De esta manera se agrupa y muestra a los jugadores por su posición.
                var porteros = jugadores.Where(j => j.Posicion == "Portero").ToList();
                var defensas = jugadores.Where(j => j.Posicion == "Defensa").ToList();
                var centrocampistas = jugadores.Where(j => j.Posicion == "Centrocampista").ToList();
                var delanteros = jugadores.Where(j => j.Posicion == "Delantero").ToList();

                MostrarListaPorPosicion("PORTEROS", porteros);
                MostrarListaPorPosicion("DEFENSAS", defensas);
                MostrarListaPorPosicion("CENTROCAMPISTAS", centrocampistas);
                MostrarListaPorPosicion("DELANTEROS", delanteros);
            }
        }
        else
            Console.WriteLine("El equipo no existe.");
    }
    static void MostrarListaPorPosicion(string titulo, List<Jugador> jugadores)
    {
        Console.WriteLine($"\n{titulo} ({jugadores.Count}):");
        if (jugadores.Count == 0)
            Console.WriteLine("No hay jugadores en esta posición.");
        else
        {
            foreach (Jugador jugador in jugadores)
            {
                Console.WriteLine(jugador.Nombre);
            }
        }
    }
    static void AnadirJugador()
    {
        Console.Clear();
        Console.WriteLine("=== Añadir jugador ===");
        Console.WriteLine("Introduce el nombre del equipo:");

        string equipo = Console.ReadLine() ?? string.Empty;

        if (equipos.ContainsKey(equipo))
        {
            Console.WriteLine("Introduce el nombre del jugador:");
            string nombreJugador = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Introduce la posición del jugador (Portero, Defensa, Centrocampista, Delantero):");
            string posicion = Console.ReadLine() ?? string.Empty;

            List<string> posicionesValidas = new List<string> { "Portero", "Defensa", "Centrocampista", "Delantero" };
            if (!posicionesValidas.Contains(posicion))
            {
                Console.WriteLine("Posición no válida. Debe ser Portero, Defensa, Centrocampista o Delantero.");
                return;
            }

            equipos[equipo].Add(new Jugador(nombreJugador, posicion));
            Console.WriteLine($"Jugador {nombreJugador} añadido al {equipo} como {posicion}.");
        }
        else
            Console.WriteLine("El equipo no existe.");
    }
}