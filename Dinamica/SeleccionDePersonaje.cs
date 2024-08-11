
using MensajesPorPantalla;
using EspacioPersonajes;
using EspacioPelea;
using EspacioHistorial;
using EspacioAyuda;

namespace EspacioSeleccionDePersonaje
{
    public class SeleccionDePersonaje
    {
        public static async Task SelectorDePersonajes(List<Personaje> listaPersonajes)
        {
            Console.Clear();
            Ayuda.IntroduccionJuego();
            await SelectorDePersonajeAsync(listaPersonajes);

        }
      
        private static async Task SelectorDePersonajeAsync(List<Personaje> listaPersonajes)
        {
            
            Console.WriteLine("Seleccione el Personaje con el que jugará (ID): ");
            Mensajes.mostrarPersonajes(listaPersonajes);

            int elegido;
            string Eleccion = Console.ReadLine();
            bool control = int.TryParse(Eleccion, out elegido);
            if (control && elegido >= 0 && elegido <= 9)
            {
                
                var PersonajeElegido = listaPersonajes[elegido];
                listaPersonajes.Remove(PersonajeElegido);

                await Pelea.InicioCombate(listaPersonajes,PersonajeElegido);

            }else
            {
                Console.WriteLine("Entrada no válida. Por favor ingrese un número entre 0 y 9.");
                await Task.Delay(4000);
                await SelectorDePersonajeAsync(listaPersonajes);
            }
        }
    }
}