# **Torneo de Titanes** (AOT AU)

**Torneo de Titanes** es un juego de rol (RPG) basado en un universo alternativo de Attack on Titan. Los jugadores pueden enfrentarse en un torneo épico, eligiendo entre diversos titanes y luchando en un combate estratégico por turnos hasta alcanzar la victoria final.

## **Acerca del Juego**

**Torneo de Titanes** ofrece una experiencia en la que los jugadores asumen el rol de titanes en un torneo de combate. Cada titan tiene estadísticas únicas y habilidades que influyen en el desarrollo de la pelea. El objetivo es avanzar a través de las rondas del torneo, derrotando a otros titanes y mejorando tus habilidades hasta convertirte en el campeón.

## **Modo de Juego**

1. **Selección de Personaje**:
   - Los jugadores seleccionan entre varios titanes con atributos como velocidad, fuerza, destreza y armadura. Cada personaje tiene habilidades distintas que afectan la dinámica de las peleas.

2. **Combate por Turnos**:
   - En el combate, los jugadores enfrentan a sus titanes en rondas de combate por turnos. El combate se realiza en rondas donde el personaje elegido lucha contra un adversario al azar. Tras cada victoria, el personaje ha mejorado en estadísticas y preparación para la siguiente ronda.

3. **Progresión y Mejora**:
   - Con cada victoria, los titanes mejoran sus estadísticas como armadura, salud y otras habilidades.
4. **Historial de Ganadores**:
   - Al finalizar el torneo, el juego muestra un Historial de ganadores, con todos los Titanes que han llegado a ser el Titán Primordial y datos de fecha y hora de la victoria.

## Uso de la API

En este proyecto se ha utilizado la API **Attack on Titan API**, que devuelve información detallada del anime, donde se puede elegir entre cinco categorias de datos.
   **characters**	"https://api.attackontitanapi.com/characters"
   **episodes**	"https://api./attackontitanapi.com/episodes"
   **locations**	"https://api.attackontitanapi.com/locations"
   **organizations**	"https://api.attackontitanapi.com/organizations"
   **titans**	"https://api.attackontitanapi.com/titans"

En este juego se utiliza la categoria **characters**, y se le agrega como parametro, el id de los personajes de los que quiero informacion, de la siguiente manera:
```https://api.attackontitanapi.com/characters/1,2,3,4,5,8,10,12,57,66,67,74,86,87,88,89,90,91,95,101,184,193,188```

Esto devuelve una lista de 23 personajes con sus repectivos datos, tales como, su nombre, edad, tipo de titan, etc.
La API devuelve la siguiente estructura al solicitarla con extension .json:
```{
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("img")]
        public string img { get; set; }

        [JsonPropertyName("alias")]
        public List<string> alias { get; set; }

        [JsonPropertyName("species")]
        public List<string> species { get; set; }

        [JsonPropertyName("gender")]
        public string gender { get; set; }

        [JsonPropertyName("age")]
        public object age { get; set; }

        [JsonPropertyName("height")]
        public string height { get; set; }

        [JsonPropertyName("relatives")]
        public List<Relative> relatives { get; set; }

        [JsonPropertyName("birthplace")]
        public string birthplace { get; set; }

        [JsonPropertyName("residence")]
        public string residence { get; set; }

        [JsonPropertyName("status")]
        public string status { get; set; }

        [JsonPropertyName("occupation")]
        public string occupation { get; set; }

        [JsonPropertyName("groups")]
        public List<Group> groups { get; set; }

        [JsonPropertyName("roles")]
        public List<string> roles { get; set; }

        [JsonPropertyName("episodes")]
        public List<string> episodes { get; set; }
    }
    ```

#### ¿Cómo se usa en el juego?

En el proceso de creación de personajes para el juego, se hace una solicitud a la API para obtener información aleatoria sobre los personajes del anime. Luego, estos datos son adaptados para ajustarse al sistema de combate y estadísticas del juego, permitiendo que cada partida tenga una selección única y variada de personajes con los que competir.

#### Enlace a la API

Puedes encontrar más información sobre la API utilizada en este proyecto y explorar su documentación en el siguiente enlace:  
[API de Attack on Titan](https://www.attackontitanapi.com/)

## **Requisitos del Sistema**

1. **Sistema Operativo**: Windows, MacOS, Linux
2. **.NET Core**: Versión 8.0 o superior.
3. **Clonar el Repositorio**: Desde una terminal de Visual Studio Code o Git Bash, usa el siguiente comando para descargar el juego:
   
    ```bash
    git clone https://github.com/TallerDeLenguajes1/tl1-proyectofinal2024-tangerinegmv
    ```

4. **Ejecutar el Juego**: Abre la carpeta descargada en Visual Studio Code, abre una nueva terminal y ejecuta:
   
    ```bash
    dotnet run
    ```


## **Contacto**

Para cualquier duda, sugerencia o comentario, puedes contactarme en:

- **Correo**: gimenezmariavictoria@gmail.com
- **GitHub**: [tangerinegmv](https://github.com/tangerinegmv)

