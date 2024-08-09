using EspacioHistorial;
using EspacioPersonajes;
using MensajesPorPantalla;
using FinJuego;

namespace EspacioPelea
{
    public class Pelea
    {
        public static Random random = new Random();

        public static async Task InicioCombate(List<Personaje> listaPersonajes, Personaje PersonajeElegido)
        {
            Console.Clear();
            
            int ronda = 0;
            var Ganador = new Personaje();
            Mensajes.MostrarMensaje("COMIENZA LA BATALLA");

            await Task.Delay(1000);

            Ganador = Combate(listaPersonajes, PersonajeElegido, ronda, Ganador);
            
            Mensajes.MostrarMensaje("FIN DEL TORNEO");
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            await FinalDeJuego.Final(Ganador);
            

            
        }

        private static Personaje Combate(List<Personaje> listaPersonajes, Personaje PersonajeElegido, int ronda, Personaje Ganador)
        {
            while (listaPersonajes.Count > 0)
            {
                PersonajeElegido.Salud = 100;
                if (ronda == 9) break;
                 Mensajes.MostrarMensajeRonda(ronda+1);  

                int IndiceContrincante = random.Next(0, listaPersonajes.Count);
                var Contrincante = listaPersonajes[IndiceContrincante];
                listaPersonajes.Remove(Contrincante);

                Console.WriteLine($"{PersonajeElegido.Nombre} (Titán {PersonajeElegido.Tipo}) contra {Contrincante.Nombre} (Titán {Contrincante.Tipo})\n");

                Ganador = DinamicaDePelea(PersonajeElegido, Contrincante);

                Console.WriteLine(Ganador.Nombre + " es el ganador de esta ronda!");
                MejorarEstadisticas(Ganador);
                PersonajeElegido = Ganador;
               
                Console.WriteLine("Presione una tecla para jugar la siguiente ronda...");
                Console.ReadKey();
                ronda++;
            }

            return Ganador;
        }
    

        private static Personaje DinamicaDePelea(Personaje prota, Personaje contrincante)
        {
            int turno = random.Next(0, 2);
            bool primeraVuelta = true;

            while (prota.Salud > 0 && contrincante.Salud > 0)
            {
                if (turno == 1)
                {
                    if (primeraVuelta)
                    {
                        Mensajes.MostrarMensaje($"COMIENZA ATACANDO: {prota.Nombre}");
                    }
                    Ataque(prota, contrincante);
                    turno = 0;
                }
                else
                {
                    if (primeraVuelta)
                    {
                        Mensajes.MostrarMensaje($"COMIENZA ATACANDO: {contrincante.Nombre}");
                    }
                    Ataque(contrincante, prota);
                    turno = 1;
                }
                primeraVuelta = false;
            }

            return prota.Salud > 0 ? prota : contrincante;
        }

        private static void Ataque(Personaje ataca, Personaje defiende)
        {
            int daño = Daño(ataca);
            defiende.Salud = defiende.Salud - daño;
            if (defiende.Salud < 0)
            {
                defiende.Salud = 0;
            }
            Console.WriteLine($"\nEl Titán {ataca.Tipo} ({ataca.Nombre}) ataca al Titán {defiende.Tipo} ({defiende.Nombre}) y causa {daño} puntos de daño. ");
            Console.WriteLine($"Salud restante de {defiende.Nombre}: {defiende.Salud}");
            Console.WriteLine("--------------------------------------------------------------------------");
        }

        private static int Daño(Personaje personaje)
        {
            double Ataque = (personaje.Destreza) * (personaje.Fuerza) * (personaje.Nivel);
            double Efectividad = random.Next(1, 101);
            double Defensa = (personaje.Armadura) * (personaje.Velocidad);
            double CteDeAjuste = 50.0;
            double dañoProvocado = ((Ataque * Efectividad) - Defensa) / CteDeAjuste;
            if (dañoProvocado>100)
            {
                dañoProvocado =100;
            }
            if (dañoProvocado<0)
            {
                dañoProvocado=0;
            }
            return (int)dañoProvocado;
        }

        private static void MejorarEstadisticas(Personaje personaje)
        {
            if (personaje.Armadura <=5)
            {
                personaje.Armadura += 5;
            }else
            {
                personaje.Armadura = 10;
            }
            

            Console.WriteLine(personaje.Nombre + " ha mejorado sus estadísticas tras la victoria!");
        }
    }
} 

