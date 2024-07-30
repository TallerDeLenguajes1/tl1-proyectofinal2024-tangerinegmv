using EspacioPersonajes;
using EspacioApi;
using System.Text.Json;
using System.Net;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;
namespace EspacioFabricaDePersonajes
{
   

    public class FabricaDePersonajes
    {
        //tipo de personaje aleatorio
        private static T DecideTipo<T>() where T : Enum
        {
            Random random = new Random();

            T[] valores = (T[])Enum.GetValues(typeof(T));
            int indice = random.Next(valores.Length);

            return valores[indice];
        }

        //genera una fecha de nacimiento aleatoria
        private static DateTime FechaNac(int edad)
        {   
            int currentYear = 724;
            Random random = new Random();
            int birthYear = currentYear - edad;
            DateTime start = new DateTime(birthYear, 1, 1);
            DateTime end = new DateTime(birthYear, 12, 31);
            int range = (end - start).Days;
            DateTime FecNac = start.AddDays(random.Next(range + 1));
            return FecNac;
        }
        private static Personaje NuevoPersonaje(PersonajeDatos personaje)
        {
            Random random = new Random();
            var Nuevo = new Personaje();
            Nuevo.Nombre = personaje.name;
            Nuevo.Tipo = DecideTipo<TipoPersonaje>();
            Nuevo.Edad = personaje.age;
            Nuevo.FecNac = FechaNac(Nuevo.Edad);
            Nuevo.Genero = personaje.gender;
            Nuevo.Salud = 100;
            if (Nuevo.Tipo == TipoPersonaje.Colosal)
            {
                Nuevo.Fuerza=random.Next(9,11);
                Nuevo.Velocidad = random.Next(5,11);
                Nuevo.Destreza = random.Next(4,6);
                Nuevo.Nivel = random.Next(1,5);
                Nuevo.Armadura = random.Next(1,2);
                
            }

            if (Nuevo.Tipo == TipoPersonaje.Acorazado)
            {
                Nuevo.Fuerza=random.Next(7,11);
                Nuevo.Velocidad = random.Next(3,6);
                Nuevo.Destreza = random.Next(1,4);
                Nuevo.Nivel = random.Next(1,5);
                Nuevo.Armadura = random.Next(3,5);
            }
            
            if (Nuevo.Tipo == TipoPersonaje.Ataque)
            {
                Nuevo.Fuerza=random.Next(7,11);
                Nuevo.Velocidad = random.Next(7,11);
                Nuevo.Destreza = random.Next(2,4);
                Nuevo.Nivel = random.Next(1,5);
                Nuevo.Armadura = random.Next(1,3);
               
             }

            if (Nuevo.Tipo == TipoPersonaje.Bestia)
            {
                Nuevo.Fuerza=random.Next(5,8);
                Nuevo.Velocidad = random.Next(2,4);
                Nuevo.Destreza = random.Next(1,3);
                Nuevo.Nivel = random.Next(1,5);
                Nuevo.Armadura = random.Next(8,11);
               
            }

            return Nuevo;
        }

    

        public static List<Personaje> CreacionPersonajes(List<Personaje> listaPersonajes, List<PersonajeDatos> personajeDatos)
        {
            foreach (var personaje in personajeDatos)
            {
                Personaje personajeNuevo = NuevoPersonaje(personaje);
                listaPersonajes.Add(personajeNuevo);
            }
            return listaPersonajes;
        }
    }
    public class PersonajesJson
    {
        public void GuardarPersonajes(List<Personaje> Lista, string fileName)
        {
            string json = JsonSerializer.Serialize(Lista);
            File.WriteAllText(fileName,json);
        }

        public List<Personaje> LeerPersonajes(string fileName)
        {
            if (File.Exists(fileName))
            {
                String jsonString = File.ReadAllText(fileName);
                List<Personaje> personajesDeserializados = JsonSerializer.Deserialize<List<Personaje>>(jsonString);
                return personajesDeserializados;
            }else
            {
                System.Console.WriteLine("El archivo de nombre: " + fileName + " no existe");
                return null;
            }
        }

        public bool Existe(string fileName)
        {
            return File.Exists(fileName);
        }

        public void mostrarPersonajes(List<Personaje> lista)
        {
            foreach (var personaje in lista)
            {
                System.Console.WriteLine("Jugador de nombre: " + personaje.Nombre + ", Apodo: " + personaje.Apodo +", Edad: "+ personaje.Edad );
                System.Console.WriteLine("VEL.: " + personaje.Velocidad + " Destreza: " + personaje.Destreza + " Fuerza: " + personaje.Fuerza);
                System.Console.WriteLine("Nivel: " + personaje.Nivel + " Armadura: " + personaje.Armadura + " Salud: " + personaje.Salud);
            }
        }

    }

    
}
//https://api.namefake.com/