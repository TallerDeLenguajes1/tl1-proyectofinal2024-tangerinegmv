using EspacioPersonajes;
using EspacioApi;
using EspacioFabricaDePersonajes;
using System.Text.Json;

namespace EspacioJson
{
    public class CargarDatos
    {
        public static async Task CargandoPersonajes()
        {
            await CargarDatosPersonajesAsync();
        }

        private static async Task CargarDatosPersonajesAsync()
        {
           
            List<PersonajeDatos> listaPersonajesApi = new List<PersonajeDatos>();
            List<Personaje> listaPersonajes = new List<Personaje>();

            listaPersonajesApi = await TraerInfoAPI(listaPersonajesApi);
            listaPersonajes = FabricaDePersonajes.CreacionPersonajes(listaPersonajes, listaPersonajesApi);
            PersonajesJson.GuardarPersonajes(listaPersonajes, "Json/Personajes.json");
        }

        private static async Task<List<PersonajeDatos>> TraerInfoAPI(List<PersonajeDatos> listaPersonajes) 
        {
            try
            {
                HttpClient cliente = new HttpClient();
                var url = "https://api.attackontitanapi.com/characters";
                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                respuesta.EnsureSuccessStatusCode();

                string responseBody = await respuesta.Content.ReadAsStringAsync();
                var contenidoApi = JsonSerializer.Deserialize<Root>(responseBody, new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
    
                if (contenidoApi != null && contenidoApi.Items != null)
                {
                    foreach (var personaje in contenidoApi.Items)
                    {
                        listaPersonajes.Add(personaje);
                    
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                return null;
            }

            return listaPersonajes;
        }

    }
    public class PersonajesJson{
        public static void GuardarPersonajes(List<Personaje> Lista, string fileName)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(Lista, options);
            File.WriteAllText(fileName,json);
        }
        public static List<Personaje> LeerPersonajes(string fileName)
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
         public static bool Existe(string fileName)
        {
            return File.Exists(fileName);
        }

        public static async Task RecargaDePersonajes(string fileName)
        {
            if (Existe(fileName))
            {
                Console.WriteLine("Existe una lista de personajes precargada, quieres usarla?(S/N)");
                string answer = Console.ReadLine();
                if (answer == "N" || answer =="n")
                {
                    Console.WriteLine("Se borrará la lista y se creará una nueva.");
                    File.Delete(fileName);
                    Console.WriteLine("Creando nuevos personajes...");
                    await CargarDatos.CargandoPersonajes();
                }else
                {
                    Console.WriteLine("Se usará la lista de personajes precargada.");
                    await Task.Delay(3000);
                }
            }
        }
    }
        

        

       
/* 
        public void mostrarPersonajes(List<Personaje> lista)
        {
            foreach (var personaje in lista)
            {
                System.Console.WriteLine("Jugador de nombre: " + personaje.Nombre + ", Apodo: " + personaje.Apodo +", Edad: "+ personaje.Edad );
                System.Console.WriteLine("VEL.: " + personaje.Velocidad + " Destreza: " + personaje.Destreza + " Fuerza: " + personaje.Fuerza);
                System.Console.WriteLine("Nivel: " + personaje.Nivel + " Armadura: " + personaje.Armadura + " Salud: " + personaje.Salud);
            }
        } */

    }
