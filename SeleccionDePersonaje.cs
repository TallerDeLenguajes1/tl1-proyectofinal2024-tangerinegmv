
using MensajesPorPantalla;
using EspacioPersonajes;
using EspacioPelea;

namespace SeleccionDePersonaje
{
    public class SeleccionDePersonaje
    {
      
        public static void SelectorDePersonaje(List<Personaje> listaPersonajes)
        {
            Console.WriteLine("----------------------- ");
            Console.WriteLine("Seleccione el Personaje con el que jugará (ID): ");
            Mensajes.mostrarPersonajes(listaPersonajes);

            int elegido;
            string Eleccion = Console.ReadLine();
            bool control = int.TryParse(Eleccion, out elegido);
            if (control)
            {
                var Protagonista = listaPersonajes[elegido];
                listaPersonajes.Remove(Protagonista);

                Pelea.Combate(listaPersonajes, Protagonista);
            }
        }
    }
}