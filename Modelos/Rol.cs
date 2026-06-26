using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAlquilerVehiculos.Modelos
{
    // Representa los roles habilitados en el sistema: Administrador y Cliente.
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "El nombre del rol es obligatorio.")]
        [StringLength(30)]
        [Index("IX_Rol_NombreRol", IsUnique = true)]
        public string NombreRol { get; set; }

        public bool Estado { get; set; }

        // Relación: un rol puede estar asociado a varios usuarios.
        public virtual ICollection<Usuario> Usuarios { get; set; }

        public Rol()
        {
            Estado = true;
            Usuarios = new HashSet<Usuario>();
        }
    }
}
