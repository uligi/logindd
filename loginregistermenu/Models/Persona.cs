using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace loginregistermenu.Models
{
    public class Persona
    {
        public int PersonaID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; } = string.Empty;

        public DateTime FechaNacimiento { get; set; }

        public int GeneroID { get; set; }
        public Genero Genero { get; set; } = new Genero();

        public int EstadoCivilID { get; set; }
        public Estado_Civil EstadoCivil { get; set; } = new Estado_Civil();

        public int EstadoPersonaID { get; set; }
        public Estado_Persona EstadoPersona { get; set; } = new Estado_Persona();

        public ICollection<Telefono> Telefonos { get; set; } = new List<Telefono>();
        public ICollection<Correo> Correos { get; set; } = new List<Correo>();
    }
}
