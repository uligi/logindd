namespace loginregistermenu.Models
{
    public class Direccion
    {
        public int DireccionID { get; set; }
        public int? UsuarioID { get; set; }
        public Usuario Usuario { get; set; } = new Usuario();
        public string DireccionDetalle { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string CodigoPostal { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;
        public int? TipoDireccionID { get; set; }
        public Tipo_Direccion TipoDireccion { get; set; } = new Tipo_Direccion();
    }
}
