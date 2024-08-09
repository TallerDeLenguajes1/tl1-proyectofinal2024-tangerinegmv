using EspacioPersonajes;
using EspacioApi;
using EspacioFabricaDePersonajes;
using EspacioJson;
using EspacioHistorial;
using System;
namespace MensajesPorPantalla
{
    public static class Mensajes
    {
        public static void MostrarIntroduccion()
        {
            Console.Clear();
            Console.WriteLine("==========================================================================================");
            Console.WriteLine("                            __        __   _       _          _  ");
            Console.WriteLine("                            \\ \\      / /  | |     | |        | | ");
            Console.WriteLine("                             \\ \\_/ /__ | |_   _ | |  ___  | |_ ");
            Console.WriteLine("                              \\   / _ \\| | | | || | / _ \\ | __|");
            Console.WriteLine("                               | |  __/| | |_| || || (_) || |_ ");
            Console.WriteLine("                               |_|\\___/ |_|\\__,_||_| \\___/  \\__|");
            Console.WriteLine();
            Console.WriteLine("==========================================================================================");
            Console.WriteLine();
            Console.WriteLine("En las profundidades de la Isla Paradis, un antiguo secreto se esconde entre las sombras.");
            Console.WriteLine("Cada ser nacido en esta tierra posee un poder aterrador: el poder de un Titán.");
            Console.WriteLine("Con el tiempo, estos seres colosales se enfrentan en un torneo sagrado para determinar al Titán Primordial.");
            Console.WriteLine("Un torneo donde solo el más fuerte, el más astuto y el más valiente se alzará como el gobernante supremo.");
            Console.WriteLine();
            Console.WriteLine("¡Prepárate para forjar tu destino en esta épica batalla por el poder y la gloria!");
            Console.WriteLine("==========================================================================================");
            Console.WriteLine();
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadKey();
        }
        public static void mostrarPersonajes(List<Personaje> lista)
        {
            // Imprimir encabezados
            Console.WriteLine("===================================================================================================================================");
            Console.WriteLine("ID |      Nombre             | Genero  | Edad | Titán        | Velocidad | Destreza | Fuerza | Nivel | Armadura | Salud ");
            Console.WriteLine("===================================================================================================================================");

            int id = 0;
            foreach (var personaje in lista)
            {
                // Imprimir cada personaje con formato, incluyendo el tipo de personaje
                Console.WriteLine($"{id,-2} | {personaje.Nombre,-23} | {personaje.Genero,-7} | {personaje.Edad,-4} | {personaje.Tipo,-12} | {personaje.Velocidad,-9} | {personaje.Destreza,-8} | {personaje.Fuerza,-6} | {personaje.Nivel,-5} | {personaje.Armadura,-8} | {personaje.Salud,-5}");
                id++;
            }

            Console.WriteLine("===================================================================================================================================");
        }


  

        public static void MostrarHistorial(List<HistorialJson> listaHistorial)
        {
            if (listaHistorial == null || listaHistorial.Count == 0)
            {
                Console.WriteLine("No hay registros en el historial.");
                return;
            }

            Console.WriteLine("========================================================");
            Console.WriteLine("           Historial de Ganadores                       ");
            Console.WriteLine("========================================================");
            Console.WriteLine("Nombre del Ganador         | Fecha y Hora               ");
            Console.WriteLine("--------------------------------------------------------");

            foreach (var registro in listaHistorial)
            {
                
                
                Console.WriteLine($"{registro.Ganador.Nombre,-25} | {registro.Hora}");
            }

            Console.WriteLine("========================================================");
        }

        internal static void MostrarPersonaje(Personaje personaje)
        {
            // Imprimir encabezados
        Console.WriteLine("==========================================================================================================");
        Console.WriteLine("Nombre          | Genero  | Edad | Velocidad | Destreza | Fuerza | Nivel | Armadura | Salud | Tipo");
        Console.WriteLine("==========================================================================================================");

        // Imprimir el personaje con formato
        Console.WriteLine($"{personaje.Nombre,-15} | {personaje.Genero,-7} | {personaje.Edad,-4} | {personaje.Velocidad,-9} | {personaje.Destreza,-8} | {personaje.Fuerza,-6} | {personaje.Nivel,-5} | {personaje.Armadura,-8} | {personaje.Salud,-5} | {personaje.Tipo,-4}");

        Console.WriteLine("==========================================================================================================");
    
          

        }

        public static void MostrarMenuPrincipal()
        {
            Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("       MENÚ PRINCIPAL");
                Console.WriteLine("=======================================");
                Console.WriteLine("1. Empezar el Juego");
                Console.WriteLine("2. Ver Historial de Ganadores");
                Console.WriteLine("3. Salir");
                Console.WriteLine("=======================================");
                Console.Write("Seleccione una opción (1-3): ");
        }
        public static void MostrarMensajeRonda(int ronda)
        {
            Console.WriteLine("==========================================================================================");
            Console.WriteLine($"                           Ronda {ronda}");
            Console.WriteLine("==========================================================================================");
        }

        public static void MostrarMensaje(string mensaje)
        {
            Console.WriteLine("==========================================================================================");
            Console.WriteLine($"                {mensaje}");
            Console.WriteLine("==========================================================================================");
        }
    }

  }