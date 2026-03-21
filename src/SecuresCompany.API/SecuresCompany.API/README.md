# SecuresCompany API - Sistema de Gestión de Aseguradora

## Descripción
API REST desarrollada en ASP.NET Core que implementa operaciones CRUD para la gestión 
de empleados y clientes de una compañía aseguradora.
Los procesos CRUD no son más que: C=create, R=read U=update, D=delete.

## Tecnologías Utilizadas
- ASP.NET Core Web API (.NET 9.0)
- Entity Framework Core
- SQL Server
- C#

## Estructura del Proyecto
```
SecuresCompany.API/
├── Controllers/          # Controladores de la API
│   ├── ClientesController.cs
│   └── EmpleadosController.cs
├── Data/
│   ├── Context/         # DbContext de Entity Framework
│   └── Entities/        # Modelos de base de datos
├── Dtos/                # Data Transfer Objects
├── Models/              # Modelos adicionales
└── Program.cs           # Configuración de la aplicación
```

## Características
-  CRUD completo de Empleados
-  CRUD completo de Clientes
-  Conexión a base de datos SQL Server
-  DTOs para separar modelos de datos
-  Entity Framework Core para acceso a datos
-  Swagger para documentación de API

## Endpoints Principales

### Empleados
- `GET /api/empleados` - Obtener todos los empleados
- `GET /api/empleados/{id}` - Obtener empleado por ID
- `POST /api/empleados` - Crear nuevo empleado
- `PUT /api/empleados/{id}` - Actualizar empleado
- `DELETE /api/empleados/{id}` - Eliminar empleado

### Clientes
- `GET /api/clientes` - Obtener todos los clientes
- `GET /api/clientes/{id}` - Obtener cliente por ID
- `POST /api/clientes` - Crear nuevo cliente
- `PUT /api/clientes/{id}` - Actualizar cliente
- `DELETE /api/clientes/{id}` - Eliminar cliente

## Configuración

### Prerrequisitos
- .NET 9 SDK
- SQL Server (LocalDB o Express)
- Visual Studio 2022

### Instalación

1. Clonar el repositorio
```bash
git clone https://github.com/Angelslebron/ITLAPracticesTuesdayC1.git
```

2. Configurar la cadena de conexión en `appsettings.json`
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\MSSQLSERVER01;Database=SecureCompany;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

3. Ejecutar las migraciones
```bash
dotnet ef database update
```

4. Ejecutar la aplicación
```bash
dotnet run
```

## Uso con Swagger
Al ejecutar el proyecto, Swagger se abrirá automáticamente en:
```
https://localhost:[puerto]/swagger
```

## Autor
Angel Duarte Montero Lebrón
Programación II - ITLA
Fecha: Sat. Febraury 14th, 2026

## Notas
- Proyecto desarrollado como parte de la Tarea 2 de Programación II.
- Este es el Issue 2 de nuestro proyecto final.
- Implementa conceptos de POO y arquitectura de API REST.
```

