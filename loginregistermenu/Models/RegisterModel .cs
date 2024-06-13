using System.ComponentModel.DataAnnotations;

namespace loginregistermenu.Models
{
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Cedula { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
