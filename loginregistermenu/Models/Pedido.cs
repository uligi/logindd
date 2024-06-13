namespace loginregistermenu.Models
{
    public class Pedido
    {
        public int PedidoID { get; set; }
        public int ClienteID { get; set; }
        public Usuario Cliente { get; set; } = new Usuario();
        public DateTime FechaPedido { get; set; }
        public int EstadoPedidoID { get; set; }
        public Estado_Pedido EstadoPedido { get; set; } = new Estado_Pedido();
        public decimal TotalPedido { get; set; }
        public int DireccionEnvioID { get; set; }
        public Direccion DireccionEnvio { get; set; } = new Direccion();
        public int MetodoPagoID { get; set; }
        public Metodo_Pago MetodoPago { get; set; } = new Metodo_Pago();
    }
}
