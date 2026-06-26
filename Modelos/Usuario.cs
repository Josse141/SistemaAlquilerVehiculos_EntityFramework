using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAlquilerVehiculos.Modelos
{
    // Representa a una persona con acceso al sistema.
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "El nombre completo es obligatorio.")]
        [StringLength(150)]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio.")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo válido.")]
        [Index("IX_Usuario_Correo", IsUnique = true)]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [StringLength(50)]
        [Index("IX_Usuario_NombreUsuario", IsUnique = true)]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(255)]
        public string Contrasenia { get; set; }

        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; }

        [ForeignKey("Rol")]
        public int IdRol { get; set; }

        // Relación: cada usuario pertenece a un rol.
        public virtual Rol Rol { get; set; }

        public Usuario()
        {
            Estado = true;
            FechaRegistro = DateTime.Now;
        }
    }
}
