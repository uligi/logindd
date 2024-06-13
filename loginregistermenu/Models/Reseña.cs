namespace loginregistermenu.Models
{
    public class Reseña
    {
        public int ReseñaID { get; set; }
        public int ProductoID { get; set; }
        public Producto Producto { get; set; } = new Producto();
        public int ClienteID { get; set; }
        public Usuario Cliente { get; set; } = new Usuario();
        public int Calificacion { get; set; }
        public string Comentario { get; set; } = string.Empty;
        public DateTime FechaReseña { get; set; }
    }
}
