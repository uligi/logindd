using System.ComponentModel.DataAnnotations;

namespace loginregistermenu.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; } = string.Empty;
    }
}
