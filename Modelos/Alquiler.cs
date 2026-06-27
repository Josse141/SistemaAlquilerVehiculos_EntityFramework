using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAlquilerVehiculos.Modelos
{
    // Representa el alquiler de un vehículo realizado por un usuario.
    public class Alquiler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAlquiler { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }

        [ForeignKey("Vehiculo")]
        public int IdVehiculo { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaDevolucionEsperada { get; set; }

        public DateTime? FechaDevolucionReal { get; set; }

        [StringLength(20)]
        public string Estado { get; set; }

        public bool Danios { get; set; }

        [StringLength(200)]
        public string Observaciones { get; set; }

        public DateTime FechaRegistro { get; set; }

        // Relación con Usuario
        public virtual Usuario Usuario { get; set; }

        // Relación con Vehículo
        public virtual Vehiculo Vehiculo { get; set; }

        public Alquiler()
        {
            Estado = "PENDIENTE";
            Danios = false;
            FechaRegistro = DateTime.Now;
        }
    }
}