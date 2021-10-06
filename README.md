# Ppai_Implementacion_CU102

Se adjunta carpeta con la implementación del caso de uso y el script de la base de datos.
El nombre asignado a la base de datos es: Museo
Una vez cargada la base al motor de Base de Datos, realizar la conexión a la base desde el .Net
Una vez realizada la conexión, copiar la dirección de conexión y cambiarla en 
el archivo App.Config en la etiqueta <AppSettings>

Descripción del caso de uso: Realizar la implementación del registro de entradas de un complejo de museos
El mismo debe respetar el uso de POO y patrones GRASP, y los métodos definidos en el diagrama de clases
El sistema debe permitir el registro de una cantidad X de entradas, realizar el calculo correspondiente
y finalizar la venta registrandolo en la base de datos, haciendo que el registro de la venta sea persistente
actualizando el contador de cantidad entradas vendidas en el día y validando que no sea supere el limite diario.
si en caso supera el limite el sistema no debe permitir la venta de entradas
