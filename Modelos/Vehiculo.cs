using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAlquilerVehiculos.Modelos
{
    // Representa un vehículo que puede ser administrado y alquilado.
    public class Vehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVehiculo { get; set; }

        [Required(ErrorMessage = "La placa es obligatoria.")]
        [StringLength(20)]
        [Index("IX_Vehiculo_Placa", IsUnique = true)]
        public string Placa { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria.")]
        [StringLength(50)]
        public string Marca { get; set; }

        [Required(ErrorMessage = "El modelo es obligatorio.")]
        [StringLength(50)]
        public string Modelo { get; set; }

        [Range(1900, 2100, ErrorMessage = "Debe ingresar un año válido.")]
        public int Anio { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un tipo de vehículo.")]
        [StringLength(30)]
        public string TipoVehiculo { get; set; }

        [Range(typeof(decimal), "0.01", "999999999", ErrorMessage = "La tarifa diaria debe ser mayor a cero.")]
        public decimal TarifaDiaria { get; set; }

        [Required(ErrorMessage = "Debe indicar el estado del vehículo.")]
        [StringLength(20)]
        public string EstadoVehiculo { get; set; }

        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }

        public Vehiculo()
        {
            EstadoVehiculo = "DISPONIBLE";
            Activo = true;
            FechaRegistro = DateTime.Now;
        }
    }
}
