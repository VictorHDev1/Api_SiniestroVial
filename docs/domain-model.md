# Modelo de Dominio

## Contexto del dominio

El dominio modela el registro y consulta de siniestros viales ocurridos en diferentes departamentos y ciudades, permitiendo su análisis por fechas y características del evento.
---

## Entidades principales

### Siniestro

Representa un evento vial ocurrido en una fecha y ubicación determinada.

**Propiedades:**
- Id (long)
- FechaHora (DateTime)
- Departamento (string)
- Ciudad (string)
- Tipo (int)
- NumeroVictimas (int)
- Descripcion (string)

**Reglas de negocio:**
- La fecha del siniestro no puede ser futura.
- El número de víctimas no puede ser negativo.
- Un siniestro debe tener al menos un vehículo asociado.

**Relaciones:**
- Un Siniestro puede contener uno o más Vehículos.
---

### Vehiculo

Representa un vehículo involucrado en un siniestro vial.

**Propiedades:**
- Id (long)
- Tipo (string)
- Placa (string)

**Reglas de negocio:**
- La placa es obligatoria.
- El tipo de vehículo debe ser válido dentro del contexto del dominio.

---

## Agregados

- **Siniestro** actúa como Aggregate Root.
- **Vehiculo** es una entidad dependiente del agregado Siniestro.

---

## Invariantes del dominio

- Un vehículo no puede existir sin un siniestro.
- Todas las modificaciones del agregado deben realizarse a través del Siniestro.
