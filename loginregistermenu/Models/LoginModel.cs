using System.ComponentModel.DataAnnotations;

namespace loginregistermenu.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "El campo correo o nombre de usuario es obligatorio.")]
        public string CorreoONombreUsuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "El campo contraseña es obligatorio.")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; } = string.Empty;
    }
}
