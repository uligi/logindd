namespace loginregistermenu.Models
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string Nombre { get; set; } = string.Empty;  // Inicializar Nombre
        public string Descripcion { get; set; } = string.Empty;  // Inicializar Descripcion
    }
}
