using System.ComponentModel.DataAnnotations;

namespace loginregistermenu.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }
    }
}
