# Product Catalog API

Prueba técnica desarrollada en .NET 10.

## Tecnologías

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger
- Serilog

## Arquitectura

- ProductCatalog.Api
- ProductCatalog.Domain
- ProductCatalog.Infrastructure

## Requisitos

- Visual Studio 2026
- .NET 10 SDK
- SQL Server Express o superior

## Configuración

1. Clonar el repositorio

```bash
git clone https://github.com/juanfelipegomezdevia/ProductCatalog.git
```

2. Abrir `ProductCatalog.sln`.

3. Modificar la cadena de conexión en `appsettings.json`.

4. Ejecutar las migraciones:

```powershell
Update-Database
```

5. Ejecutar el proyecto.

Swagger estará disponible en:

```
https://localhost:7114/swagger
```
