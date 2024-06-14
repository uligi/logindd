namespace loginregistermenu.Models
{
    public class Carrito
    {
        public int CarritoID { get; set; }
        public int ClienteID { get; set; }
        public Usuario Cliente { get; set; } = new Usuario();
    }
}
