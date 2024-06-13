namespace loginregistermenu.Models
{
    public class Carrito
    {
        public int CarritoID { get; set; }
        public int UsuarioID { get; set; }
        public Usuario Cliente { get; set; } = new Usuario();  // Inicializar Cliente
    }
}
