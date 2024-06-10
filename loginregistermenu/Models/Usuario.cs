using System.ComponentModel.DataAnnotations;

namespace loginregistermenu.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Cedula { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Correo { get; set; }

        [Required]
        [StringLength(255)]
        public string Contrasena { get; set; }

        [Required]
        [StringLength(50)]
        public string Rol { get; set; }
    }
}
