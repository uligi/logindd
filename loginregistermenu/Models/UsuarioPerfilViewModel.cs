namespace loginregistermenu.Models
{
    public class UsuarioPerfilViewModel
    {
        public Usuario Usuario { get; set; } = new Usuario();
        public Persona Persona { get; set; } = new Persona();
        public List<Direccion> Direcciones { get; set; } = new List<Direccion>();
        public List<Telefono> Telefonos { get; set; } = new List<Telefono>();
        public List<Genero> Genero { get; set; } = new List<Genero>();
    }
}
