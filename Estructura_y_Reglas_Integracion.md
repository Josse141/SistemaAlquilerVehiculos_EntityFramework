# Reglas de integración del proyecto grupal

## Entidades entregadas por Persona 1

- `Rol`
- `Usuario`
- `Vehiculo`

## Estados de vehículo

- `DISPONIBLE`: puede ser solicitado para alquiler.
- `ALQUILADO`: posee un alquiler aprobado y activo.
- `MANTENIMIENTO`: no debe aparecer como opción disponible.

## Reglas para Persona 2 — Alquileres y devoluciones

1. Solo debe permitir solicitudes para vehículos donde `Activo == true` y `EstadoVehiculo == "DISPONIBLE"`.
2. Cuando un administrador apruebe un alquiler, debe cambiar `EstadoVehiculo` a `ALQUILADO`.
3. Al registrar la devolución, debe cambiar el vehículo a `DISPONIBLE` o `MANTENIMIENTO`, según corresponda.
4. El alquiler debe tener las llaves foráneas `IdUsuario` e `IdVehiculo`.

## Reglas para Persona 3 — Pagos, multas y reportes

1. Pagos y multas deben depender de un alquiler; no deben alterar registros históricos de usuarios ni vehículos.
2. Para bloquear un cliente con deudas, valide las relaciones de alquiler, pagos y multas antes de permitir una nueva solicitud.
3. Los reportes deben considerar vehículos inactivos cuando se trate de información histórica.
