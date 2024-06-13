namespace loginregistermenu.Models
{
    public class Detalle_Correo
    {
        public int DetalleCorreoID { get; set; }  // Esta es la clave primaria
        public int CorreoID { get; set; }
        public string Detalle { get; set; } = string.Empty;
        public bool Activo { get; set; }

        public Correo Correo { get; set; } = new Correo();
    }
}
