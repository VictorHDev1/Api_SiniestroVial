# API de Registro de Siniestros Viales - .NET 8

## Descripción

Esta solución implementa una API REST para registrar y consultar siniestros viales por:

- Departamento
- Rango de fechas
- Combinación de filtros
- Paginación

La solución fue desarrollada en **.NET 8** utilizando:

- Clean Architecture
- Domain Driven Design (DDD)
- CQRS
- Repository Pattern
- MediatR
- EF Core
- SQL Server
- Unit Tests
-  Docker & Docker Compose

---

## Arquitectura

```
La solución sigue Clean Architecture separando responsabilidades:

API (Controllers)
↓
Application (CQRS)
↓
Domain (Reglas de negocio)
↓
Infrastructure (Persistencia)

```

---

## Estructura del Proyecto

```
├── API_SiniestroVial/
│   ├── Controllers/
│   │   └── SiniestrosController.cs    # API endpoints
│   ├── Program.cs
├── Siniestros.Application/
│   |   ├── Commands/
│   │   |    └── RegistrarSiniestro/
│   |	|	  ├──RegistrarSiniestroCommand.cs
│   |   |	  └──RegistrarSiniestroHandler.cs
│   |   ├── Common/
│   │   |    └── PagedResult.cs
│   |   ├── DTOs/
│   │   |    ├── SiniestroDto.cs
│   │   |    └── VehiculoDto.cs
│   │   ├── Interfaces/
│   │   |    ├── ISiniestroReadRepository.cs
│   │   |    └── ISiniestroRepository.cs
│   │   ├── Queries/
│   │   |    └── RegistrarSiniestro/
│   |	|	  ├──ConsultarSiniestrosHandler.cs
│   |   |	  └──ConsultarSiniestrosQuery.cs
├──Siniestros.Domain/
│   │   ├── Entities/
│   │   |    ├── Siniestro.cs   
│   │   |    └── Vehiculo.cs   
│   │   ├── Enums/
│   │   |    └── TipoSiniestro.cs
├──Siniestros.Infrastructure/
│   │   ├── Persistence/
│   │   |    └── Configurations/
│   |   |    |  └──SiniestroConfiguration.cs
│   │   |    └──Repositories/
│   |	|	  ├──SiniestroReadRepository.cs
│   |   |	  └──SiniestroRepository.cs
│   │   ├── SiniestrosDbContext.cs
│   │   ├── DependencyInjection.cs
├──Siniestros.Tests/
│   │   |    ├── Application/
│   |	|    |	  ├──Commands/
│   |   |    |	  |    └──RegistrarSiniestroHandlerTests.cs
│   |   |    |    └──Queries/
│   |   |    |	  |    └──ConsultarSiniestrosHandlerTests.cs
│   │   |    └──Domain/
│   |	|    |	  ├──Entities/
│   |   |    |	  |    └──SiniestroTests.cs
├──docker-compose.yml
├──Dockerfile
├──init.sql
└── README.md
```
---

## ⚙️ Tecnologías utilizadas

- .NET 8
- -  ASP.NET Core
- -  EF Core
- -  SQ Server
- -  MeiatR
- -  xUnit
- -  Moq
- -  FluentAssertions
- -  Swagger
- - Docker & Docker Compose

---

## ▶️ Ejecución del proyecto

### 1. Clonar repositorio

git clone <repo>


---

### 2. Configurar cadena de conexión

Editar:

appsettings.json


Ejemplo:

```json

{
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost,1433;Database=SiniestrosVialesBD;User Id=sa;Password=Password123!;TrustServerCertificate=True;"
 }
```

3. Ejecutar migraciones
```bash
# Create a new migration
dotnet ef migrations add MigrationName

# Apply migrations
dotnet ef database update

# Remove last migration
dotnet ef migrations remove

```

5. Ejecutar API
```
dotnet run
Swagger disponible en:

https://localhost:<puerto>/swagger
```
5. Ejecutar tests
```
dotnet test
```
## API Endpoints

| Method | Endpoint | Descripcion |
|--------|----------|-------------|
| POST| `/api/sinisestros`| Refgistro de siniestos |
| GET | `/api/siniestros/consultarsiniestros` | consulta siniestos, fltros y paginacion|


### Ejemplo: Registrar Siniestro
```json
POST /api/sinisestros
{
  "fechaHora": "2026-02-02T15:33:50.193Z",
  "departamento": "Antioquia",
  "ciudad": "Medellin",
  "tipo": 2,
  "numeroVictimas": 1,
  "descripcion": "Accidente vehiculo particular",
  "vehiculos": [
    {
      "tipo": "TractoCamion",
      "placa": "SPO022"
    }
  ]
}
```
Tests incluidos
```
Se prueban:

Creación de entidad

Asociación de vehículos

```


