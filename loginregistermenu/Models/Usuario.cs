using System.ComponentModel.DataAnnotations;

namespace loginregistermenu.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty; // Mantener el campo Email

        [Required]
        [StringLength(255)]
        public string Contraseña { get; set; } = string.Empty;

        [Required]
        public int TipoUsuarioID { get; set; } // Este es el FK hacia Tipo_Usuario

        public int PersonaID { get; set; }
        public Persona Persona { get; set; } = new Persona();
        public Tipo_Usuario Tipo_Usuario { get; set; } = new Tipo_Usuario(); // Esta es la propiedad de navegación
        public ICollection<Direccion> Direccion { get; set; } = new List<Direccion>();
        public ICollection<Telefono> Telefono { get; set; } = new List<Telefono>();
        public ICollection<Correo> Correos { get; set; } = new List<Correo>();
    }
}
