# Calculator Service

Solución creada con WebApi, C# y Visual Studio 2015.

## Descripción
Implementación un 'Servicio de calculadora' basado en HTTP/REST para realizar las operaciones aritméticas básicas, como sumar, restar, multiplicar, dividir y raíz cuadrada.  
Tiene un sistema de logs con información para poder diagnosticar problemas y un servicio de historial que realiza un seguimiento de las solicitudes que comparten un identificador común.

## Cliente 
Aplicación de consola para testear el servicio [Calculator.Service](https://github.com/Daniel-40/Calculator-Service.git)  

Para su funcionamiento es necesario ejecutar los dos proyectos.

La aplicación muestra al usuario el siguiente menú de opciones:

Enter an option: 1.Add | 2.Subtract | 3.Multiply | 4.Divide | 5.Square Root | 6.Query | 7.Exit

El usuario debe introducir por teclado el número de una de estas opciones para poder consumir el servicio web y la acción correspondiente. Después de seleccionar la opción para realizar una operación se le pregunta al usuario si quiere añadir un identificador de seguimiento para poder realizar una consulta y obtener las operaciones realizadas asociadas a ese identificador.

Este identificador es opcional y se debe añadir en la cabecera de la llamada al servicio.

Para salir del programa el usuario debe introducir el número 7 (exit).

## Servidor
El servidor contiene un servicio web con distintos métodos y acciones que permiten al usuario realizar operaciones aritméticas de suma, resta, multiplicación, división y raiz cuadrada.

Operaciones:

1.Suma
  - Realiza la suma de varios números y devuelve el resultado.
  - Este método recibe un objeto de tipo array de enteros y devuelve el resultado en formato JSON.
  
2.Resta
  - Realiza la resta de dos números y devuelve el resultado.
  - Este método recibe dos objetos de tipo entero y devuelve el resultado en formato JSON.
  
3.Multiplicación
  - Realiza la multiplicación de varios números y devuelve el resultado.
  - Este método recibe un objeto de tipo array de enteros y devuelve el resultado en formato JSON.
  
4.División
  - Realiza la división de dos números y devuelve el cociente y el resto.
  - Este método recibe dos objetos de tipo entero (dividendo y divisor) y devuelve el resultado en formato JSON.
  
5.Raíz cuadrada
  - Realiza la raíz cuadrada de un número.
  - Este método recibe un objeto de tipo entero para calcular su raíz cuadrada y devuelve el resultado en formato JSON.
  
6.Consulta
  - Devuelve una lista de operaciones registradas con un mismo identificador.
  - Este método recibe un string con el identificador y devuelve el resultado en formato JSON una lista con las operaciones registradas asociadas a ese identificador.
  
## Referencias externas

### NLog
NLog es una librería de registro para .NET con amplias capacidades de administración y enrutamiento de registros.  
NLog permite crear un fichero de log, diferenciando el tipo de entrada (Trace, Warm, Error, Fatal o Info).

Plataformas compatibles:  
- .NET Framework 3.5, 4, 4.5, 4.6, 4.7 y 4.8
- .NET Core 1, 2 y 3
- .NET Standard 1.3+ y 2.0+;
- Perfil de cliente de .NET Framework 4
- Xamarin Android, Xamarin iOs
- UWP
- Windows Phone 8
- Silverlight 4 y 5
- Mono 4

Instalación desde Package Manager Console `Install-Package NLog -Version 4.7.5`

Para la instalación desde NuGet Package Manager buscar NLog e instalar.

[NLog](https://www.nuget.org/packages/NLog)

### Newtonsoft.Json  
Newtonsoft.Json es un popular framework de alto rendimiento para .NET. Sirve para usar y manipular texto y objetos con formato JSON en .NET  

Instalación desde Package Manager Console `Install-Package Newtonsoft.Json -Version 12.0.3`  

Para la instalación desde NuGet Package Manager buscar Newtonsoft.Json e instalar.

[Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)

### RestShap
RestSharp es una popular librería para .Net que permite actuar como clientes para consumir una Api Rest.

Instalación desde Packet Manager Console `Install-Package RestSharp -Version 106.11.7`

Para la instalación desde NuGet Package Manager buscar RestSharp e instalar.

[RestSharp](https://www.nuget.org/packages/RestSharp/)
