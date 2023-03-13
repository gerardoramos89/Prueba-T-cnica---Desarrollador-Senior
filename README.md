1.	Requerimientos
Se desarrollo una aplicación siguiendo el diagrama de arquitectura todos los archivos se encuentran en la carpeta recursos y pueden ver en la documentación, lo necesario para la instalación y con los recursos adjuntos o con el siguiente repositorio público:
https://github.com/gerardoramos89/Prueba-T-cnica---Desarrollador-Senior

2.	Base de datos

 Ver archivo Adjunto Sentencias.sql

3.	Documentación WebApi_CODIFICO

En los archivos Adjuntos encontraran la solucion CODIFICO con dos proyectos, el UnitTesting.Tests y WebApi_CODIFICO.

3.1	Ejecutar pruebas de conexión a la base de datos

Primero para ejecutar las pruebas de Integración en UnitTesting.Tests, y obtengan  una ejecución correcta se debe cambiar la instancia SQL Server en la linea 27 cambiándola con una cadena de conexión activa.
 
![image](https://user-images.githubusercontent.com/57040617/224812864-8cee7ba5-59c3-44f7-a47b-04f0828a2cb1.png)



Luego Ejecutar pruebas en CustomerValidatorShould 
 
![image](https://user-images.githubusercontent.com/57040617/224812916-aa040deb-4231-4d71-b053-767d5cd54f98.png)
![image](https://user-images.githubusercontent.com/57040617/224820367-8d6d0543-cf30-478e-9e2e-0094e3c8bb32.png)


Si la instancia SQL Responde con la cadena de conexión que cambiaron y la base de datos de prueba se puede ver las pruebas ejecutadas y correctas como la imagen siguiente:
 
 ![image](https://user-images.githubusercontent.com/57040617/224812942-e39fa029-49a0-4c4d-a1b6-d492f20df12d.png)

Esta prueba de integración confirma, que las Api de consulta de Ordenes y Clientes responde correctamente con HttpStatusCode.OK y confirma el correcto funcionamiento de la base de datos y el DML WebApi_CODIFICO al listar ordenes y productos.
Así las cosas, como ya tenemos las pruebas correctas podemos cambiar la cadena de conexión para el proyecto WebApi_CODIFICO en appsettings.json en la linea 10 como se hizo en el archivo de pruebas.
Ver imagen:

![image](https://user-images.githubusercontent.com/57040617/224812955-8702132a-f505-4736-b44c-58d6caa5b3de.png)

 
Con eso, ya podemos ejecutar el proyecto y visualizar lo siguientes servicios Api en Swagger:
 
 ![image](https://user-images.githubusercontent.com/57040617/224812982-64a971fd-d90e-4317-b435-fb8e2d84ee06.png)

4.  Documentación WebApp
Instalación:
Es un proyecto en React.js se debe ejecutar los siguientes comandos npm Si la llave de conexión fue probada con las pruebas y el proyecto  WebApi se está  ejecutando.
•	npm install
•	npm start

Si se genera un error de Cors como el siguiente:

 ![image](https://user-images.githubusercontent.com/57040617/224812999-24792afb-79d8-490d-a255-3c4380ad5b71.png)

     
Para la prueba se puede usar la siguiente extensión de Chrome 
https://chrome.google.com/webstore/detail/moesif-origin-cors-change/digfbfaphojjndkpccljibejjbppifbc
Es solo activarlo para la pruebas y se podría evitar el error visualizando lo siguiente:

 ![image](https://user-images.githubusercontent.com/57040617/224813020-11ce3d6d-67b3-4e57-81e5-09fee7da4446.png)

 ![image](https://user-images.githubusercontent.com/57040617/224813028-1ba24ae7-83e5-4e9e-b887-5650100d2327.png)


Me falto terminar el funcionamiento del formulario de New Order, solo esta la maquetación como se ve en la imagen siguiente:
 
     
5. Graficando con D3

https://codepen.io/gerardoramos89/pen/RwYMwMB
