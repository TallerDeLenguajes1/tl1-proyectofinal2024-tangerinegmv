using EspacioPersonajes;
using EspacioApi;
using EspacioFabricaDePersonajes;
using EspacioJson;
using System;
namespace MensajesPorPantalla
{
    public static class Mensajes
    {
        public static void mostrarPersonajes(List<Personaje> lista)
        {
            // Imprimir encabezados
            Console.WriteLine("==========================================================================================================");
            Console.WriteLine("ID |      Nombre             | Genero  | Edad | Velocidad | Destreza | Fuerza | Nivel | Armadura | Salud ");
            Console.WriteLine("==========================================================================================================");

            int id = 0;
            foreach (var personaje in lista)
            {
                // Imprimir cada personaje con formato
                Console.WriteLine($"{id,-2} | {personaje.Nombre,-23} | {personaje.Genero,-7} | {personaje.Edad,-4} | {personaje.Velocidad,-9} | {personaje.Destreza,-8} | {personaje.Fuerza,-6} | {personaje.Nivel,-5} | {personaje.Armadura,-8} | {personaje.Salud,-5}");
                id++;
            }

            Console.WriteLine("=========================================================================================================");
        }

    }
}