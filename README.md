Integrantes:
Adrián Bonilla Calderón
Nahun Castro Vega
Camila Luna Castro
Saúl Retana Mora

Enlace GitHub: https://github.com/lunacastrocamila/Progra_AvanzadaWeb/

a. Arquitectura del proyecto
El proyecto desarrollado es una aplicación web que utiliza el patrón de arquitectura Modelo-Vista-Controlador, implementado con ASP.NET Core MVC y programado en C# y HTML.

Organización del Proyecto:
Modelos: Contienen las clases que representan las entidades de la base de datos y la lógica de negocio.
Vistas: Archivos HTML que se encargan de la presentación de la información al usuario.
Controladores: Gestionan las solicitudes del usuario, interactúan con los modelos y devuelven las vistas adecuadas.
Base de Datos: SQL Server Management Studio.
Herramienta de Desarrollo: Visual Studio 2022.

b. Librerias o Paquetes NuGet Utilizados
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Migrations
Microsoft.EntityFrameworkCore.Infrastructure
Microsoft.EntityFrameworkCore.Metadata
Microsoft.EntityFrameworkCore.Storage.ValueConversion

c. Principios de SOLID y patrones de diseño utilizados

1. Single Responsibility Principle (SRP)
Cada clase tiene una única responsabilidad específica, cumpliendo con el SRP:

Controladores:
Cada controlador maneja exclusivamente las operaciones relacionadas con una entidad específica:

AsignacionController.cs: Gestiona asignaciones.
NotificacionController.cs: Realiza las operaciones CRUD para notificaciones.
TecnicoController.cs: Administra los técnicos y su información.
SolicitudController.cs: Controla las solicitudes de servicio.
UsuarioController.cs: Gestiona las operaciones de los usuarios.

Modelos:
Cada archivo en la carpeta Models representa una entidad de la base de datos (Notificacion, Tecnico, Solicitud, etc.) y contiene únicamente las propiedades y relaciones necesarias.

2. Open/Closed Principle (OCP)
El código está diseñado para ser abierto a la extensión pero cerrado a la modificación:
Las operaciones CRUD en los controladores (Index, Create, Edit, Delete) están organizadas en métodos separados. Si se requiere una nueva funcionalidad (como filtrar registros), puede añadirse como un nuevo método sin afectar el código existente.
Entity Framework Core permite extender la estructura de la base de datos sin modificar la lógica del controlador.

3. Liskov Substitution Principle (LSP)
Las clases derivadas pueden sustituir a sus clases base sin alterar el funcionamiento del programa.
En este proyecto, el contexto de base de datos ServiciosSoporteContext se inyecta en los controladores mediante Dependency Injection. Lo cual permite reemplazar el contexto por una implementación diferente sin necesidad de modificar el código del controlador.

4. Interface Segregation Principle (ISP)
Las entidades y controladores solo dependen de lo que realmente necesitan. Si en una fase posterior se introducen interfaces, estas deben ser específicas y segmentadas según las necesidades de cada controlador o repositorio.

5. Dependency Inversion Principle (DIP)
Se implementó inyección de dependencias para evitar dependencias directas con módulos de bajo nivel:
El contexto de base de datos ServiciosSoporteContext se inyecta en los controladores a través de su constructor. Esto desacopla el controlador de la implementación concreta de acceso a datos.

6. Patrones de diseño utilizados

6.1 Patrón MVC (Modelo-Vista-Controlador)
La arquitectura del proyecto está basada en el patrón Modelo-Vista-Controlador (MVC), que separa las responsabilidades de la aplicación en tres componentes principales:

Modelo: Representa la lógica de la aplicación y la estructura de los datos. Las clases en la carpeta Models (Notificacion, Tecnico, Solicitud, etc.) definen las entidades del sistema y sus propiedades.
Vista: Contiene las interfaces de usuario, que muestran los datos y permiten la interacción del usuario.
Controlador: Gestiona las solicitudes del usuario, recupera los datos desde el modelo y los envía a la vista. 

6.2 Dependency Injection (DI)
La inyección de dependencias se utiliza para resolver dependencias y desacoplar los controladores del contexto de base de datos
En cada controlador, el contexto ServiciosSoporteContext se inyecta a través del constructor

public NotificacionController(ServiciosSoporteContext context)
{
    _context = context;
}

6.3 Active Record (a través de Entity Framework Core)
Entity Framework Core implementa el patrón Active Record, donde cada clase de modelo representa una tabla en la base de datos, y sus objetos encapsulan tanto los datos como el comportamiento relacionado.
