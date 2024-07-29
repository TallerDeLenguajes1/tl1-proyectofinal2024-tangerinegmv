
namespace EspacioPersonajes
{
    public enum TipoPersonaje
    {
        Colosal,
        Acorazado,
        Bestia,
        Ataque,
    }
   
    public class Personaje
    {
        private int velocidad;
        private int destreza;
        private int fuerza;
        private int nivel;
         private int armadura;
        private int salud;

        private TipoPersonaje tipo;
        private string nombre;

        private string apodo;

        private DateTime fechaDeNacimiento;

        private int edad;

        public int Velocidad {get => velocidad; set => velocidad = value;}
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public int Salud { get => salud; set => salud = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime FecNac { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public int Edad { get => edad; set => edad = value; }
        public TipoPersonaje Tipo  { get => tipo; set => tipo = value; }
    }  
    
     
}
