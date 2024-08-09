
using MensajesPorPantalla;
using EspacioPersonajes;
using EspacioPelea;
using EspacioHistorial;

namespace EspacioSeleccionDePersonaje
{
    public class SeleccionDePersonaje
    {
      
        public static async Task SelectorDePersonajeAsync(List<Personaje> listaPersonajes)
        {
            Console.WriteLine("----------------------- ");
            Console.WriteLine("Seleccione el Personaje 1 con el que jugará (ID): ");
            Mensajes.mostrarPersonajes(listaPersonajes);

            int elegido;
            string Eleccion = Console.ReadLine();
            bool control = int.TryParse(Eleccion, out elegido);
            if (control)
            {
                var PersonajeElegido = listaPersonajes[elegido];
                listaPersonajes.Remove(PersonajeElegido);

                await Pelea.InicioCombate(listaPersonajes,PersonajeElegido);
                
                


            }
        }
    }
}