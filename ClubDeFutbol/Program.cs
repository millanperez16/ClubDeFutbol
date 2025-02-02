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
                new Jugador("#5 Iñigo Martínez", "Defensa"), new Jugador("Marcos Alonso", "Defensa"), new Jugador("Eric García", "Defensa"),
                new Jugador("Pedri", "Centrocampista"), new Jugador("Gavi", "Centrocampista"), new Jugador("De Jong", "Centrocampista"),
                new Jugador("Romeu", "Centrocampista"), new Jugador("Sergi Roberto", "Centrocampista"), new Jugador("Fermín", "Centrocampista"),
                new Jugador("Lewandowski", "Delantero"), new Jugador("Ferran Torres", "Delantero"), new Jugador("Raphinha", "Delantero"),
                new Jugador("Ansu Fati", "Delantero"), new Jugador("Joao Félix", "Delantero"), new Jugador("Vitor Roque", "Delantero")
            }
        },
        { "FC Barcelona Femenino", new List<Jugador>
            {
                new Jugador("Sandra Paños", "Portero"), new Jugador("Cata Coll", "Portero"), new Jugador("Gemma Font", "Portero"),
                new Jugador("Mapi León", "Defensa"), new Jugador("Irene Paredes", "Defensa"), new Jugador("Jana Fernández", "Defensa"),
                new Jugador("Lucy Bronze", "Defensa"), new Jugador("Ona Batlle", "Defensa"), new Jugador("Ingrid Engen", "Defensa"),
                new Jugador("Alexia Putellas", "Centrocampista"), new Jugador("Aitana Bonmatí", "Centrocampista"), new Jugador("Patri Guijarro", "Centrocampista"),
                new Jugador("Keira Walsh", "Centrocampista"), new Jugador("Clàudia Pina", "Centrocampista"), new Jugador("Bruna Vilamala", "Centrocampista"),
                new Jugador("Caroline Graham", "Delantero"), new Jugador("Asisat Oshoala", "Delantero"), new Jugador("Mariona Caldentey", "Delantero"),
                new Jugador("Salma Paralluelo", "Delantero"), new Jugador("Geyse Ferreira", "Delantero"), new Jugador("Vicky López", "Delantero")
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