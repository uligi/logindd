namespace loginregistermenu.Models
{
    public class Correo
    {
        public int CorreoID { get; set; }
        public int PersonaID { get; set; }
        public Persona Persona { get; set; } = new Persona();
        public string DireccionCorreo { get; set; } = string.Empty;
        public int TipoCorreoID { get; set; }
        public Tipo_Correo TipoCorreo { get; set; } = new Tipo_Correo();
    }
}
