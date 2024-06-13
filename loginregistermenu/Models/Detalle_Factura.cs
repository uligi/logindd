namespace loginregistermenu.Models
{
    public class Detalle_Factura
    {
        public int DetalleFacturaID { get; set; }
        public int FacturaID { get; set; }
        public Factura Factura { get; set; } = new Factura();
        public int ProductoID { get; set; }
        public Producto Producto { get; set; } = new Producto();
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
