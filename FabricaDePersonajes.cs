namespace EspacioFabricaDePersonajes
{
    using EspacioPersonajes;
    using EspacioApi;
    using System.Text.Json;
    using System.Net;

    public class FabricaDePersonajes
    {
        static DateTime start = new DateTime(2700,1,1);
        static DateTime end = new DateTime(3000,1,1);
        static int range = (end - start).Days;
        public Personaje NuevoPersonaje(string Nombre, TipoPersonaje type, string apodo)
        {
            Random random = new Random();
            var Nuevo = new Personaje();
            Nuevo.Nombre = Nombre;
            Nuevo.Apodo = apodo;
            Nuevo.Tipo = type;

            if (Nuevo.Tipo == TipoPersonaje.Klingon)
            {
                Nuevo.Fuerza=random.Next(9,11);
                Nuevo.Velocidad = random.Next(5,11);
                Nuevo.Destreza = random.Next(4,6);
                Nuevo.Nivel = random.Next(1,5);
                Nuevo.Armadura = random.Next(1,2);
                Nuevo.Salud = random.Next(30,45);
                Nuevo.FecNac = start.AddDays(random.Next(range));
                Nuevo.Edad = start.Year - Nuevo.FecNac.Year;
            }

            if (Nuevo.Tipo == TipoPersonaje.Navi)
            {
                Nuevo.Fuerza=random.Next(7,11);
                Nuevo.Velocidad = random.Next(3,6);
                Nuevo.Destreza = random.Next(1,4);
                Nuevo.Nivel = random.Next(1,5);
                Nuevo.Armadura = random.Next(3,5);
                Nuevo.Salud = random.Next(50,80);
                Nuevo.FecNac = start.AddDays(random.Next(range));
                Nuevo.Edad =  Nuevo.FecNac.Year - start.Year;
            }
            
            if (Nuevo.Tipo == TipoPersonaje.Ood)
            {
                Nuevo.Fuerza=random.Next(7,11);
                Nuevo.Velocidad = random.Next(7,11);
                Nuevo.Destreza = random.Next(2,4);
                Nuevo.Nivel = random.Next(1,5);
                Nuevo.Armadura = random.Next(1,3);
                Nuevo.Salud = random.Next(30,55);
                Nuevo.FecNac = start.AddDays(random.Next(range));
                Nuevo.Edad =  Nuevo.FecNac.Year - start.Year;
            }

            if (Nuevo.Tipo == TipoPersonaje.Wookie)
            {
                Nuevo.Fuerza=random.Next(5,8);
                Nuevo.Velocidad = random.Next(2,4);
                Nuevo.Destreza = random.Next(1,3);
                Nuevo.Nivel = random.Next(1,5);
                Nuevo.Armadura = random.Next(8,11);
                Nuevo.Salud = random.Next(80,101);
                Nuevo.FecNac = start.AddDays(random.Next(range));
                Nuevo.Edad = start.Year - Nuevo.FecNac.Year;
            }

            return Nuevo;
        }

    }

    public class PersonajesJson
    {
        //public void GuardarPersonajes
    }
}
