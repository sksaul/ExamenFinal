a) Las estrucuturas de datos utilizadas en estre proyecto son, colas, arrays y listas.






b)El proceso generalmente comienza instalando la herramienta dotnet-ef mediante el comando dotnet tool install --global dotnet-ef y agregando los paquetes necesarios como Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Design, Microsoft.EntityFrameworkCore.Tools y el proveedor correspondiente, por ejemplo SQL Server o PostgreSQL. Posteriormente se crea una clase que herede de DbContext, donde se definen los DbSet que representan las tablas de la base de datos, y se registra dicho contexto en Program.cs utilizando la cadena de conexión adecuada. Una vez configurado el contexto, se genera la primera migración mediante el comando dotnet ef migrations add InitialCreate --project Infrastructure --startup-project Api, lo que crea una carpeta llamada Migrations con los archivos necesarios para representar los cambios en la base de datos. Después se aplica la migración utilizando dotnet ef database update --project Infrastructure --startup-project Api, lo que genera físicamente las tablas y estructuras correspondientes en la base de datos. Cuando se realizan cambios en las entidades, como agregar nuevas propiedades o crear nuevas clases, se debe generar una nueva migración con dotnet ef migrations add NombreMigracion y posteriormente aplicarla nuevamente con dotnet ef database update. También es posible consultar las migraciones existentes mediante dotnet ef migrations list, eliminar la última migración no aplicada con dotnet ef migrations remove, revertir todas las migraciones con dotnet ef database update 0 o generar un script SQL utilizando dotnet ef migrations script. En un flujo de trabajo típico, el desarrollador crea las entidades, configura el DbContext, registra el contexto en la aplicación, genera una migración, la aplica a la base de datos y, cada vez que modifica la estructura de las entidades, repite el proceso creando nuevas migraciones y actualizando la base de datos para mantener sincronizados el código y la estructura física de almacenamiento.






c) los comandos de docker son:
docker ps
docker-compose up
docker-compose down






d)las partes creadas manualmente son:

* contenedores de docker, digramas, y pedidos en swagger,
las ayudas de la ia fueron:
creacion de la api y conexion a la base de datos.

