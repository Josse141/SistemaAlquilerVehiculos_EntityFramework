using System.Data.Entity;
using SistemaAlquilerVehiculos.Modelos;
using SistemaAlquilerVehiculos.Utilidades;

namespace SistemaAlquilerVehiculos.Datos
{
    // Crea los roles y el usuario administrador cuando la base se genera por primera vez.
    public class InicializadorBaseDatos : CreateDatabaseIfNotExists<AlquilerDbContext>
    {
        protected override void Seed(AlquilerDbContext contexto)
        {
            Rol administrador = new Rol
            {
                NombreRol = "ADMINISTRADOR",
                Estado = true
            };

            Rol cliente = new Rol
            {
                NombreRol = "CLIENTE",
                Estado = true
            };

            contexto.Roles.Add(administrador);
            contexto.Roles.Add(cliente);
            contexto.SaveChanges();

            Usuario usuarioAdministrador = new Usuario
            {
                NombreCompleto = "Administrador del Sistema",
                Correo = "admin@alquiler.com",
                NombreUsuario = "admin",
                Contrasenia = Seguridad.Encriptar("Admin123"),
                Estado = true,
                IdRol = administrador.IdRol
            };

            contexto.Usuarios.Add(usuarioAdministrador);
            contexto.SaveChanges();

            base.Seed(contexto);
        }
    }
}
