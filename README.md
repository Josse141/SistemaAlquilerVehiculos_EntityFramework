# Sistema de Alquiler de Vehículos — Persona 1

Proyecto base desarrollado con **C# Windows Forms**, **.NET Framework 4.7.2** y **Entity Framework 6.5.2 (Code First)**.

## Alcance incluido

- Registro de clientes.
- Inicio y cierre de sesión.
- Roles: `ADMINISTRADOR` y `CLIENTE`.
- Restricción de acceso en menús y formularios administrativos.
- Administración de usuarios: crear, editar y activar/desactivar.
- Administración de vehículos: crear, editar, activar/desactivar y definir estado, tipo y tarifa diaria.
- Base de datos creada automáticamente por Entity Framework cuando se ejecuta la aplicación por primera vez.

## Credenciales iniciales

| Campo | Valor |
|---|---|
| Usuario | `admin` |
| Contraseña | `Admin123` |
| Rol | `ADMINISTRADOR` |

## Abrir y ejecutar

1. Abra `SistemaAlquilerVehiculos.sln` en Visual Studio 2019 o 2022.
2. Verifique que tenga instalado el componente **.NET desktop development** y el **.NET Framework 4.7.2 Developer Pack**.
3. Revise `App.config`.
4. Ejecute el proyecto con **F5**.
5. Entity Framework generará la base `DB_AlquilerVehiculos` en `(localdb)\MSSQLLocalDB`.

## Cambiar la conexión a SQL Server Express o SQL Server local

Edite la entrada `AlquilerVehiculosDB` de `App.config`. Ejemplo para SQL Server Express:

```xml
<add name="AlquilerVehiculosDB"
     connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=DB_AlquilerVehiculos;Integrated Security=True;MultipleActiveResultSets=True"
     providerName="System.Data.SqlClient" />
```

## Nota sobre la contraseña

Las contraseñas se guardan mediante hash SHA-256. Por tanto, no deben insertarse contraseñas directamente desde SQL Server como texto simple: para registrar usuarios utilice los formularios del sistema.

## Próxima integración del grupo

Las Personas 2 y 3 deberán agregar las entidades `Alquiler`, `Pago` y `Multa` al mismo `AlquilerDbContext`. Deben usar `IdUsuario` e `IdVehiculo` como claves foráneas, y no eliminar físicamente usuarios ni vehículos que tengan información histórica relacionada.
