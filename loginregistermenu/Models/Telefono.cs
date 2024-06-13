namespace loginregistermenu.Models
{
    public class Telefono
    {
        public int TelefonoID { get; set; }
        public int? PersonaID { get; set; }
        public Persona Persona { get; set; } = new Persona();
        public string NumeroTelefono { get; set; } = string.Empty;
        public int? TipoTelefonoID { get; set; }
        public Tipo_Telefono TipoTelefono { get; set; } = new Tipo_Telefono();
    }
}
