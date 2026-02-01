# Architecture Decision Records (ADR)

Este documento describe las principales decisiones arquitectónicas tomadas durante el desarrollo de la solución.

## ADR 001 — Uso de Clean Architecture

### Contexto
Se requiere una separación clara de responsabilidades entre capas, permitiendo independencia de frameworks y facilidad de mantenimiento.

### Decisión
Adoptar **Clean Architecture**, separando la solución en capas:
- API
- Application
- Domain
- Infrastructure

### Consecuencias
- Mayor mantenibilidad y escalabilidad.
- Dependencias dirigidas hacia el dominio.
- Mayor esfuerzo inicial de diseño.
---

## ADR 002 — Uso de CQRS

**Estado:** Aceptado
### Contexto
La separación entre operaciones de lectura y escritura mejora la claridad del código y facilita la evolución del sistema.

### Decisión
Implementar **CQRS** utilizando **MediatR**, separando:
- Commands (escritura)
- Queries (lectura)

### Consecuencias
- Handlers pequeños, claros y altamente testeables.
- Incremento moderado en la cantidad de clases.
- Facilita optimizaciones independientes para lectura y escritura.

---

## ADR 003 — Uso de Entity Framework Core

**Estado:** Aceptado

### Contexto
Se requiere una solución ORM moderna, soportada oficialmente por .NET y compatible con SQL Server.

### Decisión
Utilizar **Entity Framework Core** como ORM principal.

### Consecuencias
- Facilita el manejo de migraciones.
- Reduce código boilerplate.
- Ligero acoplamiento a EF mitigado mediante repositorios.

---

## ADR 004 — Uso de Repository Pattern

**Estado:** Aceptado

### Contexto
Evitar el acoplamiento directo entre la capa de aplicación y la infraestructura de persistencia.

### Decisión
Implementar **Repository Pattern** para el acceso a datos.

### Consecuencias
- Facilita el testing mediante mocks.
- Mejora el desacoplamiento.
- Mayor claridad en los contratos de persistencia.
