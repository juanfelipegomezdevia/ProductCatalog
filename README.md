# Product Catalog API

## Descripción

Este proyecto corresponde a una prueba técnica desarrollada en **.NET 10** utilizando **ASP.NET Core Web API**, **Entity Framework Core Code First** y **SQL Server**.

La aplicación permite administrar un catálogo de productos mediante una API REST, implementando operaciones CRUD, búsquedas, ordenamientos, eliminación lógica y manejo global de errores.

---

# Tecnologías utilizadas

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core (Code First)
- SQL Server
- Swagger (OpenAPI)
- Serilog
- Git / GitHub

---

# Arquitectura del proyecto

El proyecto está organizado en una arquitectura de tres capas.

```
ProductCatalog
│
├── ProductCatalog.Api
│   ├── Controllers
│   ├── Middlewares
│   ├── Logs
│   └── Program.cs
│
├── ProductCatalog.Domain
│   ├── Entities
│   └── Interfaces
│
└── ProductCatalog.Infrastructure
    ├── Context
    ├── Repositories
    └── Migrations
```

---

# Funcionalidades

- Crear productos
- Consultar todos los productos
- Consultar producto por Id
- Actualizar productos
- Eliminación lógica
- Buscar por nombre
- Buscar por categoría
- Ordenar por nombre
- Ordenar por fecha de registro
- Documentación con Swagger
- Manejo global de excepciones
- Registro de logs con Serilog

---

# Modelo de datos

La entidad Product contiene los siguientes campos:

| Campo | Tipo |
|--------|------|
| Id | int |
| Nombre | nvarchar(100) |
| Descripcion | nvarchar(250) |
| Categoria | nvarchar(100) |
| Estado | bit |
| FechaRegistro | datetime |

---

# Requisitos

Antes de ejecutar el proyecto es necesario contar con:

- Visual Studio 2022
- .NET 10 SDK
- SQL Server Express o superior
- Git

---

# Configuración

## 1. Clonar el repositorio

```bash
git clone https://github.com/TU_USUARIO/ProductCatalog.git
```

## 2. Abrir la solución

Abrir el archivo:

```
ProductCatalog.sln
```

## 3. Configurar la cadena de conexión

Modificar el archivo:

```
appsettings.json
```

Ejemplo:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SERVIDOR\\SQLEXPRESS;Database=ProductCatalogDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

## 4. Crear la base de datos

Abrir la **Package Manager Console** y ejecutar:

```powershell
Update-Database
```

## 5. Ejecutar la aplicación

Presionar **F5** en Visual Studio.

La documentación estará disponible en:

```
https://localhost:7114/swagger
```

---

# Endpoints

| Método | Endpoint | Descripción |
|---------|----------|-------------|
| GET | /api/products | Obtener todos los productos |
| GET | /api/products/{id} | Obtener producto por Id |
| POST | /api/products | Crear producto |
| PUT | /api/products/{id} | Actualizar producto |
| DELETE | /api/products/{id} | Eliminación lógica |
| GET | /api/products/search?name= | Buscar por nombre |
| GET | /api/products/category?category= | Buscar por categoría |
| GET | /api/products/order/name | Ordenar por nombre |
| GET | /api/products/order/date | Ordenar por fecha |

---

# Características implementadas

- Entity Framework Core Code First
- Arquitectura de tres capas
- Patrón Repository
- Inyección de dependencias
- Logging con Serilog
- Middleware para manejo global de excepciones
- Validaciones mediante Data Annotations
- Documentación OpenAPI (Swagger)

---

# Entregables

- Código fuente en GitHub
- Script/Migraciones de Base de Datos
- Colección de Postman
- Modelo Entidad Relación (MER)

---

# Autor

Juan Felipe Gómez Devia

Prueba Técnica – API REST Catálogo de Productos
