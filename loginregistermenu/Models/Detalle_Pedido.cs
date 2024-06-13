namespace loginregistermenu.Models
{
    public class Detalle_Pedido
    {
        public int DetallePedidoID { get; set; }
        public int PedidoID { get; set; }
        public Pedido Pedido { get; set; }
        public int ProductoID { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
