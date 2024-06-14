using loginregistermenu.Models;
using System.ComponentModel.DataAnnotations;

public class Usuario
{
    public int UsuarioID { get; set; }

    [Required]
    [StringLength(100)]
    public string NombreUsuario { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Correo { get; set; } = string.Empty;

    [Required]
    [StringLength(255)]
    public string Contrasena { get; set; } = string.Empty;

    [Required]
    public int TipoUsuarioID { get; set; } // Este es el FK hacia Tipo_Usuario

    public int PersonaID { get; set; }
    public Persona Persona { get; set; } = new Persona();
    public Tipo_Usuario Tipo_Usuario { get; set; } = new Tipo_Usuario(); // Esta es la propiedad de navegación
    public ICollection<Direccion> Direcciones { get; set; } = new List<Direccion>();
    public ICollection<Telefono> Telefonos { get; set; } = new List<Telefono>();
    public ICollection<Correo> Correos { get; set; } = new List<Correo>();
}
