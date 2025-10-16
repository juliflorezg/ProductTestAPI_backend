# ProductAPI_backend

API para manejar productos, construida con **ASP.NET Core 8.0**.

## Tecnologías utilizadas

- .NET 8.0
- ASP.NET Core Web API
- C# 12
- FluentValidation
- Entity Framework Core
- Swagger para documentación de endpoints

## Clonando el proyecto

1. Clonar el repositorio:

```bash
git clone https://github.com/TU_USUARIO/ProductAPI_backend.git
```

2. Entrar al directorio del proyecto

```bash
cd ProductAPI_backend
```

## Ejecutando la API localmente

### Requisitos
* Tener instalado .NET 8.0 SDK
* Visual Studio 2022 o VS Code (opcional, pero recomendado)

### Ejecutar desde terminal
1. Restaurar paquetes NuGet:
```bash
dotnet restore
```

2. Compilar el proyecto:

```bash
dotnet build
```

3. Ejecutar la API:

```bash
dotnet run --project ProductAPI_backend
```

Por defecto, la API correrá en https://localhost:7287 y http://localhost:5297.

### Probar la API
* Abrir el navegador o Postman y dirigirse a:

http://localhost:5297/swagger/index.html


* Allí se podrán ver todos los endpoints documentados con Swagger y probarlos directamente.

##Variables de configuración

El proyecto utiliza por defecto esta string de conexión a base de datos para desarrollo en el archivo appsettings.json

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433; DataBase=Products; User Id=sa; Password=ProductsAPI1234!; Trust Server Certificate=True"
}
```

para poder levantar la base de datos es importante lo siguiente:\
* Tener Docker instalado localmente.
* Con Docker instalado, ejecutar el siguiente comando:
```bash
docker run -e "ACCEPT_EULA=Y" \ -e "SA_PASSWORD=ProductsAPI1234!" \
    -p 1433:1433 --name sqlserverproducts  \
    -d mcr.microsoft.com/mssql/server:2022-latest 
```

* Luego es importante ejecutar la migración de la base de datos con el siguiente comando:

```bash
dotnet ef database update
```

o también puede ejecutar el siguiente desde la consola del gestor de paquetes NuGet:
```bash
Update-Database
```

* Una vez ejecutado debería tener una instancia de base de datos SQL Server, la puede visualizar desde SQL Management Studio

## Despliegue en Azure  
Como paso adicional hice la creación de un servicio de ***App Service*** de Azure, el cual se puede visitar en el siguiente enlace

https://dotnetproductsapi1234.azurewebsites.net/api/products

aunque cabe mencionar que no tuve oportunidad de crear el servicio para la base de datos de SQL Server, lo cual quedaría como un paso adicional necesario para la prueba en el despliegue