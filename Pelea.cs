using EspacioPersonajes;
using EspacioApi;
using EspacioJson;
using EspacioFabricaDePersonajes;
using MensajesPorPantalla;
using System.Text.Json;
using System.Net;
using Microsoft.VisualBasic;
namespace Pelea
{
    public class Pelea
    {
        

       public static async Task SeleccionDePersonaje()
       {
            Random random = new Random();
            int ronda = 0;
            await CargarDatos.CargarDatosApi();
            List<Personaje> listaPersonajes = new List<Personaje>();
            listaPersonajes = PersonajesJson.LeerPersonajes("Json/Personajes.json");
            Console.WriteLine("----------------------- ");
            Console.WriteLine("Seleccione el Personaje con el que jugará (ID): ");
            Mensajes.mostrarPersonajes(listaPersonajes);
            int elegido ;
            string Eleccion = Console.ReadLine();
            bool control = int.TryParse(Eleccion, out elegido);
            if (control)
            {
                var Protagonista = listaPersonajes[elegido];
                listaPersonajes.Remove(Protagonista);
                int saludOriginal = 100;
                do
                {
                    if (ronda == 9)
                    {
                        break;  
                    }
                    Console.WriteLine("Eres " + Protagonista.Nombre);
                    var Enemigo = new Personaje();
                    int IndiceEnemigo = random.Next(0,9-ronda);
                    Enemigo = listaPersonajes[IndiceEnemigo];
                    Console.WriteLine("Peleas contra " + Enemigo.Nombre);
                    Enemigo = EscalamientoPorRonda(Enemigo, ronda);


                } while (true);
                
            }

            
       }
        
        public static Personaje EscalamientoPorRonda(Personaje personaje, int ronda)
        {
            personaje.Armadura = personaje.Armadura + ronda;
            personaje.Destreza = personaje.Destreza + ronda;
            personaje.Velocidad = personaje.Armadura + ronda;
            personaje.Fuerza = personaje.Destreza + ronda;
            personaje.Nivel = personaje.Nivel + ronda;
            personaje.Salud = personaje.Salud + ronda*3;
            return personaje;
        }

        public static void DinamicaDePelea()
        {
            int ataque = 0;
            int defensa = 0;
            int efectividad = 0;
            int balance = 250;
            int danio = 0;
            int turno = random.Next(1,3);

            if (Turno == 1) {
                ataque = Protagonista.Destreza * Protagonista.Fuerza * Protagonista.Nivel ;
                Efectividad = random.Next(20,101);
                defensa = enemigo.Armadura * enemigo.Velocidad;
                danio = ((ataque*Efectividad)-defensa)/Balance;
                control = int.TryParse(Eleccion, out DanioCritico);
                if(danio ==0){
                    Console.WriteLine("El enemigo ha esquivado tu ataque");
                }
                if(DanioCritico == random.Next(0,11) && danio != 0){
                        enemigo.Salud = enemigo.Salud - (danio*2);
                        Console.WriteLine("Has hecho "+ danio + " De daño Critico\n");
                }else {
                    enemigo.Salud = enemigo.Salud - (danio);
                    Console.WriteLine("Has hecho "+ danio + " De daño \n");
                }
            } else {
                ataque = enemigo.Destreza * enemigo.Fuerza * enemigo.Nivel;
                Efectividad = random.Next(20,101);
                defensa = Protagonista.Armadura * Protagonista.Velocidad;
                danio = ((ataque*Efectividad)-defensa)/Balance;
                control = int.TryParse(Eleccion, out DanioCritico);
                  if(danio ==0){
                    Console.WriteLine("has esquivado el ataque enemigo");
                }
                if(DanioCritico == random.Next(0,11) && danio !=0){
                        Protagonista.Salud = Protagonista.Salud - (danio*2);
                        
                        Console.WriteLine("Has recibido "+ danio + " De daño Critico\n");
                }else {
                     Protagonista.Salud = Protagonista.Salud - danio;
                Console.WriteLine("Has recibido "+ danio + " De daño \n");
                }
            }
        }while (Protagonista.Salud > 0 && enemigo.Salud > 0 );
        if (Protagonista.Salud <= 0){
            Console.WriteLine("Has perdido contra " + enemigo.Apodo +", Vuelve a intentarlo la proxima vez");
            break;
        }else {
    
            var Probabilidad = usoAPI.TraerProbabilidad();
            double? objetoDouble = Probabilidad % random.Next(0,51);
            int objeto = (int)objetoDouble; 
            Console.WriteLine("Su Objeto es " + objeto);
            

            Console.WriteLine("Has Ganado a " + enemigo.Apodo +", has recuperado tu salud y has subido de nivel");
             if (objeto == 0){
                Console.WriteLine("Has encontrado Un Filo infinito,¡¡tu Fuerza Aumenta en 5 !!");
                Protagonista.Fuerza += 5;
            }
            if (objeto == 10){
                Console.WriteLine("Has encontrado Un Cefiro,¡¡tu Destreza Aumenta en 4 !!");
                Protagonista.Destreza += 4;
            }
            if (objeto == 20){
                Console.WriteLine("Has encontrado Un Corazon de hierro,¡¡tu salud Aumenta en 15 !!");
                Protagonista.Salud += 15;
            }
             if (objeto == 30){
                Console.WriteLine("Has encontrado un presagio de Randuin,¡¡tu armadura Aumenta en 5 !!");
                Protagonista.Armadura += 5;
            }
            if (objeto == 40){
                Console.WriteLine("Has encontrado una Daga de Stattik,¡¡ tu velocidad a aumentado en 7!!");
                Protagonista.Velocidad+=7;
            }
            if (objeto == 50){
                Console.WriteLine("Has encontrado La maldicion de Nilah,¡¡ Has subido 2 niveles!!");
                Protagonista.Nivel+=2;
            }
            ronda ++;
            Protagonista.Nivel++;
            Protagonista.Salud = saludOriginal;
            Protagonista.Armadura = Protagonista.Armadura + random.Next(1,3);
            Protagonista.Destreza = Protagonista.Destreza + random.Next(1,3);
            Protagonista.Fuerza = Protagonista.Fuerza + random.Next(1,3);
            Protagonista.Salud = Protagonista.Salud + random.Next(5,25);  
            saludOriginal = Protagonista.Salud;
            Protagonista.Velocidad = Protagonista.Velocidad + random.Next(1,3);
            ListaDePersonajes.Remove(enemigo);
            /* Logros desbloqueables */
           
        }

        }
    }
}

 