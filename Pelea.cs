using Historial;
using EspacioPersonajes;
using MensajesPorPantalla;


namespace EspacioPelea
{
    public class Pelea
    {
        public static Random random = new Random();

        public static void Combate(List<Personaje> listaPersonajes, Personaje Protagonista)
        {
            int ronda = 0;
            
            while (listaPersonajes.Count > 0)
            {
                Mensajes.MostrarMensajeRonda(ronda+1);
                if (ronda == 9) break;

                Console.WriteLine($"\nEres {Protagonista.Nombre} (Titán {Protagonista.Tipo})");
                int IndiceContrincante = random.Next(0, listaPersonajes.Count);
                var Contrincante = listaPersonajes[IndiceContrincante];

                Console.WriteLine($"Peleas contra {Contrincante.Nombre} (Titán {Contrincante.Tipo})\n");

                var ganador = DinamicaDePelea(Protagonista, Contrincante);

                if (ganador == Protagonista)
                {
                    listaPersonajes.Remove(Contrincante);
                    MejorarEstadisticas(ganador);
                    Console.WriteLine($"\n¡Has vencido a {Contrincante.Nombre}! Tus estadísticas han mejorado.");
                }
                else
                {
                    listaPersonajes.Remove(Protagonista);
                    MejorarEstadisticas(ganador);
                    Console.WriteLine($"\nHas sido derrotado por {Contrincante.Nombre}. ¡Mejoran sus estadísticas!");
                    Protagonista = Contrincante; // Cambia el protagonista si pierde
                }

                ronda++;
            }

                Console.WriteLine($"\n{Protagonista.Nombre} ha ganado el torneo y se convierte en el Titán Primordial. ¡Felicidades!");
                Console.WriteLine("Sus estadísticas finales son:");
                Mensajes.MostrarPersonaje(Protagonista);

                // Añadir al historial de ganadores
                var historial = HistorialJson.LeerGanadores();
                HistorialJson.CargarDatos(Protagonista, historial);
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
                        Console.WriteLine("Comienza atacando " + prota.Nombre);
                    }
                    Ataque(prota, contrincante);
                    turno = 0;
                }
                else
                {
                    if (primeraVuelta)
                    {
                        Console.WriteLine("Comienza atacando " + contrincante.Nombre);
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
            Console.WriteLine($"\nEl Titán {ataca.Tipo} ({ataca.Nombre}) ataca al Titán {defiende.Tipo} ({defiende.Nombre}) y causa {daño} puntos de daño. Salud restante de {defiende.Nombre}: {defiende.Salud}");
        }

        private static int Daño(Personaje personaje)
        {
            double Ataque = (personaje.Destreza) * (personaje.Fuerza) * (personaje.Nivel);
            double Efectividad = random.Next(1, 101);
            double Defensa = (personaje.Armadura) * (personaje.Velocidad);
            double CteDeAjuste = 500;
            double dañoProvocado = ((Ataque * Efectividad) - Defensa) / CteDeAjuste;
            return (int)dañoProvocado;
        }

        private static void MejorarEstadisticas(Personaje personaje)
        {
            personaje.Salud += 10;
            personaje.Armadura += 5;
            personaje.Fuerza += 3;
            personaje.Velocidad += 2;
            personaje.Nivel += 1;
        }
    }
} 

