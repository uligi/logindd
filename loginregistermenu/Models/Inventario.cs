namespace loginregistermenu.Models
{
    public class Inventario
    {
        public int InventarioID { get; set; }
        public int ProductoID { get; set; }
        public Producto Producto { get; set; } = new Producto();
        public int Cantidad { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public int TipoTransaccionID { get; set; }
        public Tipo_Transaccion TipoTransaccion { get; set; } = new Tipo_Transaccion();
        public int EmpleadoID { get; set; }
        public Empleado Empleado { get; set; } = new Empleado();
    }
}
