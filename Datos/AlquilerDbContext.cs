using System.Data.Entity;
using SistemaAlquilerVehiculos.Modelos;

namespace SistemaAlquilerVehiculos.Datos
{
    // Contexto principal de Entity Framework para el Sistema de Alquiler de Vehículos.
    public class AlquilerDbContext : DbContext
    {
        public AlquilerDbContext()
            : base("name=AlquilerVehiculosDB")
        {
        }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Define precisión para campos monetarios.
            modelBuilder.Entity<Vehiculo>()
                .Property(v => v.TarifaDiaria)
                .HasPrecision(12, 2);

            // Evita eliminaciones en cascada que puedan afectar información histórica.
            modelBuilder.Conventions.Remove<
                System.Data.Entity.ModelConfiguration.Conventions.OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
