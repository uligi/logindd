using System.ComponentModel.DataAnnotations;

namespace loginregistermenu.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Cedula { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Correo { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Contrasena { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Rol { get; set; }

        public int PersonaID { get; set; }
        public Persona Persona { get; set; } = new Persona();
        public ICollection<Direccion> Direcciones { get; set; } = new List<Direccion>();
        public ICollection<Telefono> Telefonos { get; set; } = new List<Telefono>();
        public ICollection<Correo> Correos { get; set; } = new List<Correo>();
    }
}
